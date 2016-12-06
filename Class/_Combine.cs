// Класс для объединения Media (информации о фильме) и Record (самого файла видео)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    public class Combine
    {
        public Combine()
        {
            recordList = new List<Record>();
            media = new Media();
        }

        public Media media { get; set; }                // создание объекта Media
        public List<Record> recordList { get; set; }    // хранение файлов принадлежащих Media
    }
}
