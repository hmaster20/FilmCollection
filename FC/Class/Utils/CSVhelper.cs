using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FilmCollection
{
    static class CSVhelper
    {
        public static void toCSV(RecordCollection RC)
        {
            //Encoding encoding = Encoding.GetEncoding("windows-1251");
            
            string filePath = @"X:\test.csv";

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
            File.WriteAllText(filePath, csvdata.ToString(), Encoding.GetEncoding(1251));
        }
    }
}
