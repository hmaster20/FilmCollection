using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FilmCollection
{
    /// <summary>
    /// Класс содержит информацию о произведениях: фильма, сериалах, мультфильмах и т.д.
    /// </summary>
    public class Media
    {
        [XmlIgnore]
        public List<Actor> ActorList { get; set; }

        public Media()
        {
            ActorListID = new List<int>();      // Создание списка ID актеров, играющих в картине
            ActorList = new List<Actor>();
        }

        public override string ToString() => Name;  // return Name;
    

        public string Name { get; set; }        // Название произведения

        /// <summary>Уникальный идентификатор объекта Media.</summary>
        public int Id { get; set; }

        public string Pic { get; set; } = "";   // если заполнен значит есть Изображение (Постер)
        public string Description { get; set; } = "";  // Описание файла (сюжет)

        private int _year;                      // Год выпуска
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }
        

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

    }
}