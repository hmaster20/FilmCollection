// Информация о произведениях: фильма, сериалах, мультфильмах и т.д.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Media
    {
        public Media()
        {
            ActorListID = new List<int>();          // Создание списка ID актеров, играющих в картине
        }

        public string Name { get; set; }        // Название произведения
        public int Id { get; set; }             // Уникальный идентификатор (возможно заменить на GUID ?)
        public string Pic { get; set; } = "";   // если заполнен значит есть Изображение (Постер)
        public string Description { get; set; } = "";  // Описание файла (сюжет)

        private int _year;                      // Год выпуска
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }
        

        [XmlIgnore]
        public List<Actor> ActorList { get; set; } // TEST

        
        #region Список ID актеров

        private List<int> _actorID;     // Объявление ID актеров
        public List<int> ActorListID
        {
            get { return _actorID; }
            set { _actorID = value; }
        }

        public void Add(int id) => ActorListID.Add(id);
        public void Remove(int id) => ActorListID.Remove(id);
        public void ClearID() => ActorListID.Clear();


        #endregion
        

        #region Обработка Страны
        private Country_Rus _country;   // Страна
        [XmlIgnore]
        public Country_Rus Country
        {
            get { return _country; }
            set { _country = (value < 0) ? Country_Rus.Россия : value; }
        }

        public string CountryString
        {
            get { return CountryToString(Country); }
            set { Country = StringToCountry(value); }
        }

        public static string CountryToString(Country_Rus country)
        {
            Country_Rus _category = (Country_Rus)((int)country);
            return _category.ToString();
        }

        public static Country_Rus StringToCountry(string country)
        {
            Country_Rus _category = (Country_Rus)(Enum.Parse(typeof(Country_Rus), country));
            return _category;
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



        //public static int CompareByCountry(Record a, Record b)  // Сравнение по стране
        //{
        //    return string.Compare(a.CountryString, b.CountryString);
        //}

        public static int CompareByName(Media a, Media b)     // Сравнение по названию
        {
            return string.Compare(a.Name, b.Name);
        }

        public static int CompareByGenre(Media a, Media b) // Сравнение по жанру
        {
            return string.Compare(a.GenreString, b.GenreString);
        }

        public static int CompareByCategory(Media a, Media b) // Сравнение по категории
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


    }
}