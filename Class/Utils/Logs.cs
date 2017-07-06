using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace FilmCollection
{
    public static class Logs
    {
        public static void Log(string message, Exception ex)
        {
            if (ex != null)
            {
                MessageBox.Show(ex.Message);

                File.AppendAllText("log.txt", "\r\n-------------------");
                File.AppendAllText("log.txt", (string.Format($"\r\n{DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss")}\r\n")));
                File.AppendAllText("log.txt", message);
                File.AppendAllText("log.txt", "\r\n");
                //File.AppendAllText("log.txt", ex.Message);
                File.AppendAllText("log.txt", ex.ToString());

                // Почитать habrahabr.ru/post/98638/
            }
        }
    }
}
