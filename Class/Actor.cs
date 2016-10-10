using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Actor
    {
        public string FIO { get; set; }     // Ф.И.О.

        public int LifeTime { get; set; }   // Период жизни

        #region Обработка Страны
        private Country_Rus _country = Country_Rus.Россия;   // Страна
        [XmlIgnore]
        public Country_Rus Country
        {
            get { return _country; }
            set { _country = value; }
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
