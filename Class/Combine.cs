// Класс для объединения Media (информации о фильме)  и Record (самого фала видео)
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
            Record = new List<Record>();
        }

        public Media media { get; set; }
        public List<Record> Record { get; set; }



        //public string FileName { get { return "test"; } }

        //public string Name { get { return media.Name; } }


        // создаем количество файлов и меди поровну
        // как только находим сериал, то создаем отдельный медиа и в него добавляем файлы, остальные медиа уничтожаем.


    }
}
