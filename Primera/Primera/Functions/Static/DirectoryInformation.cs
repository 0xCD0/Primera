using System;
using System.Collections.Generic;
#region Using

#endregion

namespace Primera.Functions.Static {
    
    [Serializable]
    public class DirectoryInformation {
        private string defaultLocation;

        public DirectoryInformation() {
            setDefaultLocation();
        }

        public void setDefaultLocation() {
            this.defaultLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public void setLocation(string path) {
            this.defaultLocation = path;
        }

        public string getLocation() {
            return defaultLocation;
        }
    }
}
