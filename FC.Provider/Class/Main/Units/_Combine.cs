using System;
using System.Collections.Generic;

namespace FC.Provider.Class.Main.Units
{
    /// <summary>Связывающий класс для объединения Media (информации о фильме) и Record (самого файла видео)</summary>
    public class Combine
    {
        public Media media { get; set; }
        public List<Record> recordList { get; set; }

        public Combine()
        {
            media = new Media();                // создание объекта Media
            recordList = new List<Record>();    // хранение файлов принадлежащих Media
        }

        public void DeleteOldRecord()    // удаление помеченных фильмов
        {
            foreach (Record record in recordList.FindAll(x => x.Visible == false))
                recordList.Remove(record);
        }

        public void invisibleRecord()
        {
            foreach (Record record in recordList)
                record.Visible = false;
        }
    }
}