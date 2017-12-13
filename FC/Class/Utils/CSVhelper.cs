using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FilmCollection
{
    static class CSVhelper
    {
        private static string fileReport { get; set; }
        public static string Getfolder() => fileReport + "_files";

        public static void toCSV(RecordCollection RC)
        {
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                fileDialog.Filter = "Excel (*.csv)|*.csv";
                fileDialog.Title = "Выберите файл:";
                fileDialog.FileName = "Отчет";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(fileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(fileDialog.FileName);
                        }
                        catch (Exception ex) { Logs.Log("Невозможно удалить файл отчета", ex); }
                    }

                    //Encoding encoding = Encoding.GetEncoding("windows-1251");
                    //string filePath = @"X:\test.csv";

                    List<Record> filtered = new List<Record>();
                    RC.CombineList.ForEach(r => filtered.AddRange(r.recordList));

                    StringBuilder csvdata = new StringBuilder();
                    string head = "Название;Название файла;Полный путь;Описание;Страна;Жанр;Категория;Продолжительность";
                    csvdata.AppendLine(head);

                    foreach (Record rec in filtered)
                    {
                        var newLine = $"{rec.mName};{rec.FileName};{rec.FilePath};{rec.mDescription};{rec.mCountry};{rec.mGenre};{rec.mCategory};{rec.TimeString}";
                        csvdata.AppendLine(newLine);
                    }
                    File.WriteAllText(fileDialog.FileName, csvdata.ToString(), Encoding.GetEncoding(1251));
                    System.Diagnostics.Process.Start(fileDialog.FileName);
                }
            }
        }
    }
}
