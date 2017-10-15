using Shell32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FilmCollection
{
    public static class FileDetails
    {
        public static string GetTime(Record record)
        {
            string value = "";

            if (record != null)
            {
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(record.FilePath);
                foreach (FolderItem2 _file in folder.Items())
                {
                    if (_file.Name == record.FileName.Remove(record.FileName.LastIndexOf(record.FileExt) - 1, record.FileExt.Length + 1))
                    {
                        double nanoseconds;
                        double.TryParse(Convert.ToString(_file.ExtendedProperty("System.Media.Duration")), out nanoseconds);
                        if (nanoseconds > 0)
                            value = TimeSpan.FromSeconds(nanoseconds / 10000000).ToString();
                    }
                }
                Marshal.ReleaseComObject(folder);
                Marshal.ReleaseComObject(shell);
            }
            return value;
        }

    }
}
