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
        private TypeVideo _types = TypeVideo.Unknown;   // Тип записи (Фильм. Сериал, Мультфильм)
        [XmlIgnore]
        public TypeVideo Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public string TypesString
        {
            get { return TypeToString(Types); }
            set { Types = StringToType(value); }
        }

        public static string TypeToString(TypeVideo type)
        {
            switch (type)
            {
                case TypeVideo.Film: return "Фильм";
                case TypeVideo.Series: return "Сериал";
                case TypeVideo.Cartoon: return "Мультфильм";
                default: return "Прочее";
            }
        }

        public static TypeVideo StringToType(string type)
        {
            switch (type)
            {
                case "Фильм": return TypeVideo.Film;
                case "Сериал": return TypeVideo.Series;
                case "Мультфильм": return TypeVideo.Cartoon;
                default: return TypeVideo.Unknown;
            }
        }
        #endregion

    }

    public enum TypeVideo
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
