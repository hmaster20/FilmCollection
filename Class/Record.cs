using System;

namespace FilmCollection
{
    public class Record
    {
        private string _name = "";                // Название Фильма
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _year = "";                // Год выпуска
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }
        
        private string _country = "";             // Страна выпуска
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
  
        private string _genre = "";               // Жанр (комедия, боевик, вестерн)
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        private string _time = "";               // Время (в минутах)
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private string _description = "";        // Описание Фильма
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _type = "";              // Тип файла
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _path = "";            // Путь к файлу
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }

    public enum TypeVideo
    {
        Film,
        Series,
        Cartoon,
        Unknown
    }
}
