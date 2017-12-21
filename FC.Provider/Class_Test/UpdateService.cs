using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;


namespace FC.Provider
{
    public class WebClientWithTimeout : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.Timeout = 5000; // timeout in milliseconds (ms)
            return wr;
        }
    }

    class upd
    {
       static void downdloadwithTimeout()
        {
            string somestring;
            try
            {
                using (WebClient wc = new WebClientWithTimeout())
                {
                    //The web server may return 500(Internal Server Error) if the user agent header is missing.
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
                    somestring = wc.DownloadString("http://www.example.com/somefile.txt");
                }
            }
            catch (WebException we)
            {
                // add some kind of error processing
                MessageBox.Show(we.ToString());
            }
        }
    }





    public class UpdateService
    {
       static void getUpdate()
        {
            string remoteUri = "http://www.contoso.com/library/homepage/images/";
            string fileName = "ms-banner.gif", myStringWebResource = null;

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;

            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.

            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);

            // альтернатива загрузки 1
            using (WebClient client = new WebClient())
            {
                myStringWebResource = remoteUri + fileName;
                // Download the Web resource and save it into the current filesystem folder.
                client.DownloadFile(myStringWebResource, fileName);
            }

            // альтернатива загрузки 2
            using (WebClient client = new WebClient())
            {
                // Download the Web resource and save it into the current filesystem folder.
                client.DownloadFileAsync(new Uri(remoteUri), fileName);
            }
        }





        private void btnDownload_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri("http://mysite.com/myfile.txt"), @"c:\myfile.txt");
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // tsProgressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }




        //static readonly string remoteUri = "http://it-enginer.ru/wp-content/uploads/FilmCollection.zip";
        //static readonly string fileName = "FilmCollection.zip";

        const string remoteUri = "http://it-enginer.ru/wp-content/uploads/FilmCollection.zip";
        const string fileName = "FilmCollection.zip";

        public static void download()
        {
            ClearTemp();

            // string remoteUri = "http://it-enginer.ru/wp-content/uploads/FilmCollection.zip";
            // string fileName = "FilmCollection.zip";

            using (WebClient client = new WebClient())
            {
                // Download the Web resource and save it into the current filesystem folder.
                //client.DownloadFileAsync(new Uri(remoteUri), fileName);
                client.DownloadFile(new Uri(remoteUri), fileName);
            }
        }


        public static void unzipFile()
        {
            // string fileName = "FilmCollection.zip";
            if (File.Exists(fileName))
            {
                using (ZipFile zipFile = new ZipFile(fileName))
                {
                    zipFile.ExtractAll(Path.Combine(Application.StartupPath, "Extract"));
                }
            }
        }


        static Version getVersion()
        {
            Version ver = null;
            //string filePath = Path.Combine(Path.Combine(Application.StartupPath, "Extract"), "FilmCollection.exe");
            string filePath = Path.Combine(Path.Combine(Application.StartupPath, "Extract"), fileName);
            if (File.Exists(filePath))
            {
                Assembly assembly = Assembly.Load(File.ReadAllBytes(filePath));
                ver = assembly.GetName().Version;
                assembly = null;
            }
            return ver;
        }

        public static void compareVersion()
        {
            Version verNew = getVersion();
            Version verCurrent = Assembly.GetExecutingAssembly().GetName().Version;

            string notification = "";
            bool isUpdate = false;

            if (verNew > verCurrent)
            {
                notification = "Получено новое обновление: " + verNew;
                isUpdate = true;
            }
            else
            {
                notification = "Обновление не требуется";
            }

            if (isUpdate)
            {
                DialogResult dialog = MessageBox.Show(notification, "Уведомление", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    Updat();
                }
                if (dialog == DialogResult.Cancel)
                {
                    ClearTemp();
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show(notification, "Уведомление");
                if (dialog == DialogResult.OK)
                {
                    ClearTemp();
                }
            }
        }


        private static void ClearTemp()
        {
            //string filePath = Path.Combine(Path.Combine(Application.StartupPath, "Extract"), "FilmCollection.exe");
            string file = "FilmCollection.zip";
            string directory = Path.Combine(Application.StartupPath, "Extract");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }

        static void Updat()
        {
            MessageBox.Show("Test");
            ClearTemp();
        }

        static void runProcess()
        {
            // запустить процесс и забыть о нем 
            Process.Start("cRename.exe");
        }
    }
}
