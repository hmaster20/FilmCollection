using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    /// <summary>Класс содержит информацию о произведениях: фильма, сериалах, мультфильмах и т.д.</summary>
    public class Media : ICloneable
    {
        [XmlIgnore]
        public List<Actor> ActorList { get; }

        public Media()
        {
            ActorList = new List<Actor>();
            actorID = new List<int>();      // Создание списка ID актеров, играющих в картине
        }

        public override string ToString() => Name;  // return Name;

        /// <summary>Название произведения</summary>
        public string Name { get; set; }

        /// <summary>Уникальный идентификатор объекта Media</summary>
        public int Id { get; set; }


        private string pic;
        public string Pic
        {
            get
            {
                if (string.IsNullOrEmpty(pic)) pic = "noPic";
                return pic;
            }
            set
            {
                pic = value;
                //if (string.IsNullOrEmpty(pic)) pic = "noPic";
            }
        }

        /// <summary>Описание файла (сюжет)</summary>
        public string Description { get; set; } = "";

        private int _year;
        /// <summary>Год выпуска</summary>
        public int Year
        {
            get { return _year; }
            set { _year = (Enumerable.Range(1800, DateTime.Now.Year).Contains(value)) ? value : DateTime.Now.Year; }
        }


        #region Список ID актеров

        private List<int> actorID;     // Объявление ID актеров
        public List<int> ActorListID
        {
            get { return actorID; }
            //set { _actorID = value; }
        }


        /// <summary>Этот метод проверяет наличие элемента в списке, если его нет, то выполняется добавление id.</summary>
        /// <param name="id">Идентификатор актера (Actor.id)</param>
        public void ActorListID_Add(int id)
        {
            if (!ActorListID.Contains(id)) actorID.Add(id);
        }

        //public void Remove(int id) => ActorListID.Remove(id);

        /// <summary>Очистка списка идентификаторов актеров.</summary>
        public void ActorListID_Clear() => actorID.Clear();


        #endregion


        #region Обработка Страны
        private Country_Rus _country;   // Страна
        [XmlIgnore]
        public Country_Rus Country
        {
            get { return _country; }
            set { _country = (value < 0) ? Country_Rus.Россия : value; }
        }

        /// <summary>Страна (String)</summary>
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

        [XmlIgnore]
        public string GetFilename
        {
            get
            {
                Debug.Print(Pic);
                return Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics"), "" + Pic + ".jpg");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}