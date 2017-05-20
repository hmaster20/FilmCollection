using System;
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
            return false;
        }


        public static void CreateBackup()
        {
            using (ZipFile zip = new ZipFile())
            {
                // add this map file into the "images" directory in the zip archive
                //zip.AddFile("c:\\images\\personal\\7440-N49th.png", "images");

                zip.AddFile(RecordOptions.BaseName);
                zip.Save("Base_" + DateTime.Now.ToString("yyyy.M.dd") + ".zip");
            }
        }
    }
}
