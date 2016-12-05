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
            recordList = new List<Record>();
            media = new Media();
        }

        public Media media { get; set; }
        public List<Record> recordList { get; set; }





        public string FileName { get { return "test"; } }
        public string mediaName
        {
            get
            {
                if (media == null)
                {
                    return "";
                }
                return media.Name; } }


        // создаем количество файлов и меди поровну
        // как только находим сериал, то создаем отдельный медиа и в него добавляем файлы, остальные медиа уничтожаем.


    }
}
