using System;
using System.Xml.Serialization;

namespace FilmCollection
{
    [Serializable]
    public class Record
    {
        private string _name = "";              // Название Фильма
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _year = "";              // Год выпуска
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _country = "";           // Страна выпуска
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private int _time = 0;                  // Время (в минутах)
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        private string _description = "";       // Описание файла (сюжет)
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _filename = "";         // Название файла
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }

        private string _extension = "";         // Расширение (тип) файла (avi, mkv, mpeg)
        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        private string _path = "";              // Путь к файлу
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        #region Обработка типа жанра (комедия, боевик, вестерн)
        private GenreVideo _genreVideo = GenreVideo.Unknown;
        [XmlIgnore]
        public GenreVideo GenreVideo
        {
            get { return _genreVideo; }
            set { _genreVideo = value; }
        }

        public string GenreString
        {
            get { return GenreToString(GenreVideo); }
            set { GenreVideo = StringToGenre(value); }
        }

        public static string GenreToString(GenreVideo genretype)
        {
            switch (genretype)
            {
                case GenreVideo.Action: return "Боевик";
                case GenreVideo.Vestern: return "Вестерн";
                case GenreVideo.Comedy: return "Комедия";
                default: return "Прочее";
            }
        }

        public static GenreVideo StringToGenre(string type)
        {
            switch (type)
            {
                case "Боевик": return GenreVideo.Action;
                case "Вестерн": return GenreVideo.Vestern;
                case "Комедия": return GenreVideo.Comedy;
                default: return GenreVideo.Unknown;
            }
        }
        #endregion


        #region Обработка типа записи (Фильм. Сериал, Мультфильм)
        private CategoryVideo _category = CategoryVideo.Unknown;   // Тип записи (Фильм. Сериал, Мультфильм)
        [XmlIgnore]
        public CategoryVideo Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string CategoryString
        {
            get { return CategoryToString(Category); }
            set { Category = StringToCategory(value); }
        }

        public static string CategoryToString(CategoryVideo category)
        {
            switch (category)
            {
                case CategoryVideo.Film: return "Фильм";
                case CategoryVideo.Series: return "Сериал";
                case CategoryVideo.Cartoon: return "Мультфильм";
                default: return "Прочее";
            }
        }

        public static CategoryVideo StringToCategory(string category)
        {
            switch (category)
            {
                case "Фильм": return CategoryVideo.Film;
                case "Сериал": return CategoryVideo.Series;
                case "Мультфильм": return CategoryVideo.Cartoon;
                default: return CategoryVideo.Unknown;
            }
        }
        #endregion

    }

    public enum CategoryVideo
    {
        Film,
        Series,
        Cartoon,
        Unknown
    }

    public enum GenreVideo
    {
        Action,
        Vestern,
        Comedy,
        Unknown
    }

}
