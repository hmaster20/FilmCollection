﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;

namespace FilmCollection
{
    public static class ZipArc
    {
        public static string BackFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Bak");

        public static bool FindCurrentArchive()
        {
            if (!Directory.Exists(BackFolder))
            {
                Directory.CreateDirectory(BackFolder);
                return true;
            }
            else
            {
                return true;
            }
        }


        public static void CreateBackup()
        {
            string zipName = Path.Combine(BackFolder, "Base_" + DateTime.Now.ToString("yyyy.M.dd") + ".zip");

            if (FindCurrentArchive() && !File.Exists(zipName))
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(RecordOptions.BaseName);
                    zip.Save(zipName);
                }
            }

        }
    }
}
