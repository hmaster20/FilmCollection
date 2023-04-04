using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace FC.Provider
{
    /// <summary>Класс для форматирования ошибок и соохраннеия в текстовый файл</summary>
    public static class Logs
    {
        /// <summary>Указываем имя лог файла</summary>
        private static string logFile = "log.txt";

        public static void Log(string message, Exception ex)
        {
            if (ex != null)
            {
                // Почитать habrahabr.ru/post/98638/
                MessageBox.Show(ex.Message);

                File.AppendAllText(logFile, "\r\n-------------------");
                File.AppendAllText(logFile, (string.Format($"\r\n{DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss")}\r\n")));
                File.AppendAllText(logFile, message);
                File.AppendAllText(logFile, "\r\n");
                File.AppendAllText(logFile, ex.ToString());
            }
            else
            {
                File.AppendAllText(logFile, "\r\n-------------------");
                File.AppendAllText(logFile, (string.Format($"\r\n{DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss")}\r\n")));
                File.AppendAllText(logFile, message);
                File.AppendAllText(logFile, "\r\n");
            }
        }
    }
}
