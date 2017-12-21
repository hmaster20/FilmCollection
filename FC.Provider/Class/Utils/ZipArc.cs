using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FC.Provider
{
    public static class ZipArc
    {
        private static string BackFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Bak");

        public static bool FindCurrentArchive()
        {
            if (!Directory.Exists(BackFolder))
            {
                Directory.CreateDirectory(BackFolder);
                //Debug.Print("Directory.Exists(BackFolder) = " + Directory.Exists(BackFolder));
                return true;
            }
            else
            {
                //Debug.Print("Directory.Exists(BackFolder) = " + Directory.Exists(BackFolder));
                return true;
            }
        }


        public static void CreateBackup()
        {
            string zipName = Path.Combine(BackFolder, "Base_" + DateTime.Now.ToString("yyyy.M.dd") + ".zip");
            //FindCurrentArchive();
            //Debug.Print("BackFolder = " + BackFolder);
            //Debug.Print("Generic.GetBaseName() = " + Generic.GetBaseName());
            //Debug.Print("zipName = " + zipName);

            if (!File.Exists(Generic.GetBaseName()))
            {
                Logs.Log("Ошибка. Отсутствует файл базы (" + Generic.GetBaseName() + ") !", null);
                return;
            }

            if (FindCurrentArchive() && !File.Exists(zipName))
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(Generic.GetBaseName());
                    zip.Save(zipName);
                }
            }

        }
    }
}
