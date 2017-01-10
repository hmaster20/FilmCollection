using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FilmCollection
{
    public class ThumbnailImageEventArgs : EventArgs
    {
        public ThumbnailImageEventArgs(int size)
        {
            this.Size = size;
        }

        public int Size;
    }

    public delegate void ThumbnailImageEventHandler(object sender, ThumbnailImageEventArgs e);



    public class ThumbnailControllerEventArgs : EventArgs
    {
        public ThumbnailControllerEventArgs(string imageFilename)
        {
            this.ImageFilename = imageFilename;
        }

        public string ImageFilename;
    }


    public delegate void ThumbnailControllerEventHandler(object sender, ThumbnailControllerEventArgs e);

    public class ThumbnailController
    {
        private bool m_CancelScanning;
        static readonly object cancelScanningLock = new object();

        public bool CancelScanning
        {
            get
            {
                lock (cancelScanningLock)
                {
                    return m_CancelScanning;
                }
            }
            set
            {
                lock (cancelScanningLock)
                {
                    m_CancelScanning = value;
                }
            }
        }

        public event ThumbnailControllerEventHandler OnStart;
        public event ThumbnailControllerEventHandler OnAdd;
        public event ThumbnailControllerEventHandler OnEnd;

        public ThumbnailController()
        {

        }

        public void AddFolder(string folderPath)
        {
            CancelScanning = false;

            Thread thread = new Thread(new ParameterizedThreadStart(AddFolder));
            thread.IsBackground = true;
            thread.Start(folderPath);
        }

        private void AddFolder(object folderPath)
        {
            string path = (string)folderPath;
            this.OnStart?.Invoke(this, new ThumbnailControllerEventArgs(null));
            this.AddFolderIntern(path);
            this.OnEnd?.Invoke(this, new ThumbnailControllerEventArgs(null));
            CancelScanning = false;
        }

        private void AddFolderIntern(string folderPath)
        {
            if (CancelScanning) return;

            // not using AllDirectories
            //string[] files = Directory.GetFiles(folderPath);

            List<string> files = new List<string>(Directory.GetFiles(folderPath));

            string PicsNo = Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "noPic.jpg");            
            files.Remove(PicsNo);

            foreach (string file in files)
            {
                if (CancelScanning) break;


                Image img = null;

                try
                {
                    img = Image.FromFile(file);
                }
                catch
                {
                    // do nothing
                }

                if (img != null)
                {
                    this.OnAdd(this, new ThumbnailControllerEventArgs(file));

                    img.Dispose();
                }
            }

            // not using AllDirectories
            string[] directories = Directory.GetDirectories(folderPath);
            foreach (string dir in directories)
            {
                if (CancelScanning) break;

                AddFolderIntern(dir);
            }
        }
    }
}
