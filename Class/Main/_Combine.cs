using System;
using System.Collections.Generic;

namespace FilmCollection
{
    /// <summary>Связывающий класс для объединения Media (информации о фильме) и Record (самого файла видео)</summary>
    public class Combine
    {
        public Combine()
        {
            recordList = new List<Record>();
            media = new Media();
        }

        public Media media { get; set; }                // создание объекта Media
        public List<Record> recordList { get; set; }    // хранение файлов принадлежащих Media


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
