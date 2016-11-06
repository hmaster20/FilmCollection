using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FilmCollection
{
   


    public class Record
    {
        public bool Visible { get; set; }       // Видимость записи

        public string Name { get; set; }        // Название Фильма

        public int linkID { get; set; } = 0;        // идентификатор MediaID

        public string FileName { get; set; }    // Название файла

        public string DirName { get; set; }     // Название папки в которой расположен файл

        public string Extension { get; set; }   // Расширение (тип) файла (avi, mkv, mpeg)

        public string Path { get; set; }        // Путь к файлу




        #region Обработка времени
        private TimeSpan _timeVideoSpan;

        [XmlIgnore]
        public TimeSpan TimeVideoSpan
        {
            get { return _timeVideoSpan; }
            set { _timeVideoSpan = value; }
        }

        public string TimeString         //используется для вывода значения в таблицу
        {
            get { return TimeVideoSpan.ToString(); }
            set { TimeVideoSpan = TimeSpan.Parse(value); }
        }
        #endregion


        #region Обработка Жанра
        private GenreVideo _genreVideo;   // Жанр
        [XmlIgnore]
        public GenreVideo GenreVideo
        {
            get { return _genreVideo; }
            set { _genreVideo = (value < 0) ? GenreVideo.Unknown : value; }
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
        private CategoryVideo _category;   // Категория
        [XmlIgnore]
        public CategoryVideo Category
        {
            get { return _category; }
            set { _category = (value < 0) ? CategoryVideo.Unknown : value; }
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
        }

        public static CategoryVideo StringToCategory(string category)
        {
            CategoryVideo _category = (CategoryVideo)(Enum.Parse(typeof(CategoryVideo_Rus), category));
            return _category;
        }
        #endregion


        //#region Обработка Страны
        //private Country_Rus _country;   // Страна
        //[XmlIgnore]
        //public Country_Rus Country
        //{
        //    get { return _country; }
        //    set { _country = (value < 0) ? Country_Rus.Россия : value; }
        //}

        //public string CountryString
        //{
        //    get { return CountryToString(Country); }
        //    set { Country = StringToCountry(value); }
        //}

        //public static string CountryToString(Country_Rus country)
        //{
        //    Country_Rus _category = (Country_Rus)((int)country);
        //    return _category.ToString();
        //}

        //public static Country_Rus StringToCountry(string country)
        //{
        //    Country_Rus _category = (Country_Rus)(Enum.Parse(typeof(Country_Rus), country));
        //    return _category;
        //}
        //#endregion

        
        #region Сравнения

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

        //public static int CompareByCountry(Record a, Record b)  // Сравнение по стране
        //{
        //    return string.Compare(a.CountryString, b.CountryString);
        //}

        public static int CompareByGenre(Record a, Record b) // Сравнение по жанру
        {
            return string.Compare(a.GenreString, b.GenreString);
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
        
        public static int CompareByFileName(Record a, Record b) // Сравнение по файлу
        {
            return string.Compare(a.FileName, b.FileName);
        }
        

        #endregion
    }
}


//public Record()
//{
//    //ActorID = new List<int>();          // Создание списка ID
//}

// public int Id { get; set; }             // Уникальный идентификатор


//private int _year;                      // Год выпуска
//public int Year
//{
//    get { return _year; }
//    set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
//}


//private int _time;                      // Время (в минутах)
//public int Time
//{
//    get { return _time; }
//    set { _time = (value < 0) ? 0 : value; }
//}

// public string Description { get; set; } = ""; // Описание файла (сюжет)        
// public string Pic { get; set; } = "";


//#region Список ID актеров

//private List<int> _actorID;     // Объявление ID актеров
//public List<int> ActorID
//{
//    get { return _actorID; }
//    set { _actorID = value; }
//}


//public void Add(int id)
//{
//    ActorID.Add(id);
//}

//public void Remove(int id)
//{
//    ActorID.Remove(id);
//}

//public void ClearID()
//{
//    ActorID.Clear();
//}

//#endregion



//public static int CompareByYear(Record a, Record b)
//{
//    if (a.Year == b.Year)
//        return CompareByName(a, b);
//    return (a.Year - b.Year);
//}



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


//public static int CompareByTime(Record a, Record b)     // Сравнение по времени записи
//{
//    if (a.Time == b.Time)
//        return CompareByName(a, b);
//    return (int)((b.Time - a.Time) * 100);
//}