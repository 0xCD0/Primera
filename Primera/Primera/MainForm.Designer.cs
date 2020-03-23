namespace Primera {
    partial class MainForm {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picture_drag = new System.Windows.Forms.PictureBox();
            this.lbl_drag = new System.Windows.Forms.Label();
            this.progress_file = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.picture_drag)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_drag
            // 
            this.picture_drag.Image = global::Primera.Properties.Resources.draghere_file;
            this.picture_drag.Location = new System.Drawing.Point(104, 19);
            this.picture_drag.Name = "picture_drag";
            this.picture_drag.Size = new System.Drawing.Size(207, 205);
            this.picture_drag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_drag.TabIndex = 1;
            this.picture_drag.TabStop = false;
            // 
            // lbl_drag
            // 
            this.lbl_drag.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_drag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lbl_drag.Location = new System.Drawing.Point(0, 239);
            this.lbl_drag.Name = "lbl_drag";
            this.lbl_drag.Size = new System.Drawing.Size(415, 37);
            this.lbl_drag.TabIndex = 6;
            this.lbl_drag.Text = "여기에 파일 또는 폴더를 드래그 해주세요";
            this.lbl_drag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progress_file
            // 
            this.progress_file.Location = new System.Drawing.Point(0, 289);
            this.progress_file.Name = "progress_file";
            this.progress_file.Size = new System.Drawing.Size(415, 23);
            this.progress_file.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 312);
            this.Controls.Add(this.progress_file);
            this.Controls.Add(this.lbl_drag);
            this.Controls.Add(this.picture_drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Primera - PSD to PNG 이미지 변환 프로그램";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.DragLeave += new System.EventHandler(this.MainForm_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picture_drag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picture_drag;
        private System.Windows.Forms.Label lbl_drag;
        private System.Windows.Forms.ProgressBar progress_file;
    }
}

