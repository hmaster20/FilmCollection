// хранения медиа
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    class Media
    {
        public int Id { get; set; }             // Уникальный идентификатор
        public string Pic { get; set; } = "";   
        public string Description { get; set; } = "";  // Описание файла (сюжет)

        private int _year;                      // Год выпуска
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }

    }
}
