// Информация об актерах
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Actor : IComparable<Actor>
    {
        public Actor()
        {
            VideoID = new List<int>();     // Создание списка ID
            CombineList = new List<Combine>();
        }

        public int id { get; set; }         // Уникальный идентификатор

        public string FIO { get; set; }     // Ф.И.О.

        private string _dateOfBirth;        // дата рождения
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = (value == "  .  .") ? "20.05.1984" : value; }
        }

        private string _dateOfDeath;        // дата смерти
        public string DateOfDeath
        {
            get { return _dateOfDeath; }
            set { _dateOfDeath = (value == "  .  .") ? "По настоящее время" : value; }
        }

        public string BIO { get; set; }     // ссылка на страницу с биографией

        public override string ToString()
        {
            return FIO;
        }


        [XmlIgnore]
        public List<Combine> CombineList { get; set; } // TEST


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
        public void Add(int id) => VideoID.Add(id);
        public void Remove(int id) => VideoID.Remove(id);
        public void ClearID() => VideoID.Clear();

        #endregion


        #region Сравнения

        public bool Equals(Actor act)
        {
            if (act is Actor && act != null)
            {
                return (act.FIO == this.FIO) ? true : false;
            }
            return false;
        }
                
        public int CompareTo(Actor obj) // Реализовать интерфейс IComparable<T>, т.е. получить возможность сортировки методом .Sort();
        {
            return FIO.CompareTo(obj.FIO);
        }

        public static int CompareByName(Actor a, Actor b)     // Сравнение по названию
        {
            return string.Compare(a.FIO, b.FIO, StringComparison.OrdinalIgnoreCase);
        }

        public static int CompareByCountry(Actor a, Actor b)  // Сравнение по стране
        {
            return string.Compare(a.CountryString, b.CountryString);
        }


        public static int CompareByDateOfBirth(Actor a, Actor b)  // Сравнение по дате рождения
        {
            return string.Compare(a.DateOfBirth, b.DateOfBirth);
        }

        public static int CompareByDateOfDeath(Actor a, Actor b)  // Сравнение по дате смерти
        {
            return string.Compare(a.DateOfDeath, b.DateOfDeath);
        }

        #endregion
    }
}
