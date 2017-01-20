using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FilmCollection
{
    public delegate void ThumbnailImageEventHandler(object sender, ThumbnailImageEventArgs e);
    public delegate void ThumbnailControllerEventHandler(object sender, ThumbnailControllerEventArgs e);


    public class ThumbnailImageEventArgs : EventArgs
    {
        public ThumbnailImageEventArgs(int _size)
        {
            Size = _size;
        }

        public int Size;
    }

    public class ThumbnailControllerEventArgs : EventArgs
    {
        public ThumbnailControllerEventArgs(string _imageFilename)
        {
            ImageFilename = _imageFilename;
        }

        public string ImageFilename;
    }

    public class ThumbnailController
    {
        public event ThumbnailControllerEventHandler OnStart;
        public event ThumbnailControllerEventHandler OnAdd;
        public event ThumbnailControllerEventHandler OnEnd;

        private bool m_CancelScanning;

        static readonly object cancelScanningLock = new object();

        public ThumbnailController() { }

        public bool CancelScanning
        {
            get { lock (cancelScanningLock) { return m_CancelScanning; } }
            set { lock (cancelScanningLock) { m_CancelScanning = value; } }
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
            OnStart?.Invoke(this, new ThumbnailControllerEventArgs(null));
            AddFolderIntern(path);
            OnEnd?.Invoke(this, new ThumbnailControllerEventArgs(null));
            CancelScanning = false;
        }

        private void AddFolderIntern(string folderPath)
        {
            if (CancelScanning) return;

            // not using AllDirectories
            //string[] files = Directory.GetFiles(folderPath);

            if (!Directory.Exists(folderPath)) return; // решение проблемы при отсутствии папки          

            List<string> files = new List<string>(Directory.GetFiles(folderPath));
            //files.Sort();

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
                    OnAdd(this, new ThumbnailControllerEventArgs(file));

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
