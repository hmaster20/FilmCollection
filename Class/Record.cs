using System.Xml.Serialization;

namespace FilmCollection
{
    public class Record
    {
        public string Name { get; set; }

        //private string _name = "";              // Название Фильма
        //public string Name { get { return _name; } set { _name = value; }}

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

        private string _dirname = "";         // Название папки в которой расположен файл
        public string DirName
        {
            get { return _dirname; }
            set { _dirname = value; }
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
        private GenreVideo _genreVideo = GenreVideo.Unknown;   // Тип  жанра (комедия, боевик, вестерн)
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
                case GenreVideo.Unknown: return "Прочее";
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
                case "Прочее": return GenreVideo.Unknown;
                default: return GenreVideo.Unknown;
            }
        }
        #endregion




        #region Обработка категории записи (Фильм. Сериал, Мультфильм)
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
                case CategoryVideo.Unknown: return "Прочее";
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
                case "Прочее": return CategoryVideo.Unknown;
                default: return CategoryVideo.Unknown;
            }
        }
        #endregion



        public bool Equals(Record rec)
        {
            if (rec is Record && rec != null)
            {
                Record temp;
                temp = (Record)rec;
                if (temp.FileName == this.FileName
                && temp.Path == this.Path)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



        public static int CompareByName(Record a, Record b) // Сравнение по названию
        {
            return string.Compare(a.Name, b.Name);
        }

        public static int CompareByCategory(Record a, Record b) // Сравнение по категории
        {
            if (a.Category == b.Category)
                return CompareByName(a, b);
            if (a.Category == CategoryVideo.Film)
                return -1;
            if (b.Category == CategoryVideo.Film)
                return 1;
            if (a.Category == CategoryVideo.Cartoon)
                return -1;
            if (b.Category == CategoryVideo.Cartoon)
                return 1;
            if (a.Category == CategoryVideo.Series)
                return -1;
            if (b.Category == CategoryVideo.Series)
                return 1;
            if (a.Category == CategoryVideo.Unknown)
                return -1;
            if (b.Category == CategoryVideo.Unknown)
                return 1;
            return 0;
        }

        //public static int CompareByScore(Record a, Record b)
        //{
        //    if (a.Score == b.Score)
        //        return CompareByName(a, b);
        //    return (int)((b.Score - a.Score) * 100);
        //}

        //public static int CompareByUserScore(VideoRecord a, VideoRecord b)
        //{
        //    if (a.UserScore == b.UserScore)
        //        return CompareByName(a, b);
        //    return (int)((b.UserScore - a.UserScore) * 100);
        //}

        public static int CompareByTime(Record a, Record b) // Сравнение по времени записи
        {
            if (a.Time == b.Time)
                return CompareByName(a, b);
            return (int)((b.Time - a.Time) * 100);
        }

        public static int CompareByYear(Record a, Record b) // Сравнение по году
        {
            if (a.Year != "" && b.Year != "") { 
            string aYearString = a.Year.Substring(0, 4);
            string bYearString = b.Year.Substring(0, 4);

            if (aYearString == bYearString)
                return CompareByName(a, b);
            int aYear = 0;
            int bYear = 0;
            if (int.TryParse(aYearString, out aYear) && int.TryParse(bYearString, out bYear))
                return (int)((bYear - aYear) * 100);
            }
            return CompareByName(a, b);
        }

    }

}
