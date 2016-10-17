using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Actor
    {
        public Actor()
        {
            VideoID = new List<int>();     // Создание списка ID
        }

        public int Id { get; set; }         // Уникальный идентификатор

        public string FIO { get; set; }     // Ф.И.О.

        public string DateOfBirth { get; set; }   // дата рождения
        public string DateOfDeath { get; set; }   // дата смерти

        public override string ToString()
        {
            return FIO;
        }

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


        #region Список ID фильмов

        private List<int> _videoID;     // Объявление ID фильмов
        public List<int> VideoID
        {
            get { return _videoID; }
            set { _videoID = value; }
        }

        public void Add(int id)
        {
            VideoID.Add(id);
        }

        public void Remove(int id)
        {
            VideoID.Remove(id);
        }

        public void ClearID()
        {
            VideoID.Clear();
        }

        #endregion


        #region Сравнения

        public bool Equals(Actor act)
        {
            if (act is Actor && act != null)
            {
                Actor temp = (Actor)act;
                return (temp.FIO == this.FIO) ? true : false;
            }
            return false;
        }

        #endregion
    }
}
