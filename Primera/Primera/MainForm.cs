#region Using
using ImageMagick;
using Primera.Functions.Static;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
#endregion

namespace Primera {
    public partial class MainForm : Form {
        #region Enums
        public enum Status {
            ready = 0,
            dragOver,
            converting,
            converted
        }
        #endregion

        #region Local Variables
        DirectoryInformation directory;
        #endregion

        public MainForm() {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = true;
            directory = new DirectoryInformation();
        }
        private void MainForm_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragOver(object sender, DragEventArgs e) {
            setStatus(Status.dragOver);
        }

        private void MainForm_DragLeave(object sender, EventArgs e) {
            setStatus(Status.ready);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            setStatus(Status.converting);

            try {
                FileAttributes attr = File.GetAttributes(files[0]);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    //폴더일 경우
                    Thread processImage = new Thread(delegate () {
                        string resultPath = checkDirectory($"{directory.getLocation()}");
                        DirectoryInfo di = new DirectoryInfo(files[0]);
                        progress_file.Maximum = di.GetFiles().Length;

                        int i = 1;
                        foreach (FileInfo file in di.GetFiles()) {
                            if(file.Extension != ".psd") {
                                MessageBox.Show("PSD 파일만 변환이 가능합니다.", "에러");
                                di = new DirectoryInfo(resultPath);
                                di.Delete();
                                setStatus(Status.ready);
                                return;
                            }
                            PSDToPNG(file.FullName, file.Name.Replace(".psd",""), resultPath);
                            progress_file.Value = i;
                            i++;
                        }

                        setStatus(Status.converted);
                        progress_file.Value = 0;
                        Thread.Sleep(3000);
                        setStatus(Status.ready);
                    });
                    processImage.Start();
                }
                else {
                    // 파일일 경우
                    Thread processImage = new Thread(delegate () {
                        string resultPath = checkDirectory($"{directory.getLocation()}");
                        progress_file.Maximum = files.Length;
                        DirectoryInfo di = new DirectoryInfo(resultPath);
                        int i = 1;
                        foreach (string file in files) {
                            FileInfo info = new FileInfo(file);
                            if (info.Extension != ".psd") {
                                MessageBox.Show("PSD 파일만 변환이 가능합니다.", "에러");
                                di.Delete();
                                setStatus(Status.ready);
                                return;
                            }
                            PSDToPNG(info.FullName, info.Name, resultPath);
                            progress_file.Value = i;
                            i++;
                        }

                        setStatus(Status.converted);
                        progress_file.Value = 0;
                        Thread.Sleep(3000);
                        setStatus(Status.ready);
                    });
                    processImage.Start();
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"변환에 오류가 발생하였습니다.\r\nError : {ex.Message}", "에러");
                setStatus(Status.ready);
            }
        }
        
        #region Functions
        private void PSDToPNG(string psdPath, string fileName, string resultPath) {
            using (MagickImageCollection imgs = new MagickImageCollection(psdPath)) {
                int width = imgs[0].Width;
                int height = imgs[0].Height;

                for (int i = 1; i < imgs.Count; i++) {
                    using (MagickImageCollection result = new MagickImageCollection()) {
                        MagickColor transparent = new MagickColor(0, 0, 0, 0);
                        MagickImage for_coalesce = new MagickImage(transparent, width, height);
                        for_coalesce.BackgroundColor = transparent;

                        result.Add(for_coalesce);
                        result.Add(imgs[i]);

                        result.Coalesce();
                        result[1].Write($"{resultPath}\\{fileName}.png");
                    }

                    if (i % 20 == 0) {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();
                    }
                }
            }
        }

        private string checkDirectory(string path) {
            DateTime today = DateTime.Now;
            DirectoryInfo di = new DirectoryInfo($"{path}\\Convert_{string.Format("{0:yyMMddmmss}", today)}");
            if (di.Exists == false) {
                di.Create();
            }

            return di.ToString();
        }

        public void setStatus(Status status) {
            switch (status) {
                case Status.ready:
                picture_drag.Image = Properties.Resources.draghere_file;
                lbl_drag.Text = "여기에 파일 또는 폴더를 드래그 해주세요";
                break;

                case Status.dragOver:
                picture_drag.Image = Properties.Resources.dragover_ok;
                lbl_drag.Text = "좋습니다 !";
                break;

                case Status.converting:
                lbl_drag.Text = "파일을 변환중입니다...";
                break;

                case Status.converted:
                picture_drag.Image = Properties.Resources.equal;
                lbl_drag.Text = "파일 변환이 완료되었습니다";
                break;
            }
        }
        #endregion

    }
}
