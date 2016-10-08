using System;
using System.Linq;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Record
    {
        public string Name { get; set; }        // Название Фильма

        private int _year;                      // Год выпуска
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }

        public string Country { get; set; }     // Страна выпуска

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

        public string FileName { get; set; }    // Название файла

        public string DirName { get; set; }     // Название папки в которой расположен файл

        public string Extension { get; set; }   // Расширение (тип) файла (avi, mkv, mpeg)

        public string Path { get; set; }        // Путь к файлу



        #region Обработка Жанра
        private GenreVideo _genreVideo = GenreVideo.Unknown;   // Жанр
        [XmlIgnore]
        public GenreVideo GenreVideo
        {
            get { return _genreVideo; }
            set { _genreVideo = value; }
        }

        public string GenreString         //используется для вывода значения в таблицу
        {
            get { return GenreToString(GenreVideo); }
            set { GenreVideo = StringToGenre(value); }
        }

        public static string GenreToString(GenreVideo genretype)
        {
            GenreVideo_Rus _genretype = (GenreVideo_Rus)((int)genretype);
            return _genretype.ToString();

            // GenreVideo genretype = (GenreVideo)cBoxTypeVideo.SelectedIndex;
            //return (GenreVideo) genretype = Enum.GetValues(typeof(GenreVideo));
            //switch (genretype)
            //{
            //    case GenreVideo.Action: return "Боевик";
            //    case GenreVideo.Vestern: return "Вестерн";
            //    case GenreVideo.Comedy: return "Комедия";
            //    case GenreVideo.Unknown: return "Прочее";
            //    default: return "Прочее";
            //}
        }

        public static GenreVideo StringToGenre(string type)
        {
            GenreVideo _type = (GenreVideo)(Enum.Parse(typeof(GenreVideo_Rus), type));
            return _type;

            //switch (type)
            //{
            //    case "Боевик": return GenreVideo.Action;
            //    case "Вестерн": return GenreVideo.Vestern;
            //    case "Комедия": return GenreVideo.Comedy;
            //    case "Прочее": return GenreVideo.Unknown;
            //    default: return GenreVideo.Unknown;
            //}
        }
        #endregion


        #region Обработка Категории
        private CategoryVideo _category = CategoryVideo.Unknown;   // Категория
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
            CategoryVideo_Rus _category = (CategoryVideo_Rus)((int)category);
            return _category.ToString();

            //switch (category)
            //{
            //    case CategoryVideo.Film: return "Фильм";
            //    case CategoryVideo.Series: return "Сериал";
            //    case CategoryVideo.Cartoon: return "Мультфильм";
            //    case CategoryVideo.Unknown: return "Прочее";
            //    default: return "Прочее";
            //}
        }

        public static CategoryVideo StringToCategory(string category)
        {
            CategoryVideo _category = (CategoryVideo)(Enum.Parse(typeof(CategoryVideo_Rus), category));
            return _category;

            //switch (category)
            //{
            //    case "Фильм": return CategoryVideo.Film;
            //    case "Сериал": return CategoryVideo.Series;
            //    case "Мультфильм": return CategoryVideo.Cartoon;
            //    case "Прочее": return CategoryVideo.Unknown;
            //    default: return CategoryVideo.Unknown;
            //}
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

        public static int CompareByName(Record a, Record b)     // Сравнение по названию
        {
            return string.Compare(a.Name, b.Name);
        }

        public static int CompareByCatalog(Record a, Record b)  // Сравнение по каталогу
        {
            return string.Compare(a.DirName, b.DirName);
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

        public static int CompareByTime(Record a, Record b)     // Сравнение по времени записи
        {
            if (a.Time == b.Time)
                return CompareByName(a, b);
            return (int)((b.Time - a.Time) * 100);
        }

        //public static int CompareByYear(Record a, Record b)     // Сравнение по году
        //{
        //    if (a.Year != "" && b.Year != "")
        //    {
        //        string aYearString = a.Year.Substring(0, 4);
        //        string bYearString = b.Year.Substring(0, 4);

        //        if (aYearString == bYearString)
        //            return CompareByName(a, b);
        //        int aYear = 0;
        //        int bYear = 0;
        //        if (int.TryParse(aYearString, out aYear) && int.TryParse(bYearString, out bYear))
        //            return (int)((bYear - aYear) * 100);
        //    }
        //    return CompareByName(a, b);
        //}


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
    }
}