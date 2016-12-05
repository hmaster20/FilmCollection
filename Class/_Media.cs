// Класс, содержащий информацию о произведениях: фильмы, мультфильмы и т.д.
//
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



        // TEST ////////////////////////////////////
        [XmlIgnore]
        public List<Actor> alist { get; set; }
        // TEST ////////////////////////////////////



        #region Список ID актеров

        private List<int> _actorID;     // Объявление ID актеров
        public List<int> ActorListID
        {
            get { return _actorID; }
            set { _actorID = value; }
        }

        public void Add(int id)
        {
            ActorListID.Add(id);
        }

        public void Remove(int id)
        {
            ActorListID.Remove(id);
        }

        public void ClearID()
        {
            ActorListID.Clear();
        }

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

    }
}
