using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace FC.Provider.Class.Main.Units
{
    /// <summary>Класс содержит информацию об актерах</summary>
    public class Actor : IComparable<Actor>
    {
        public Actor()
        {
            VideoID = new List<int>();     // Создание списка ID
            CombineList = new List<Combine>();
        }

        public Actor(string fio = "") : this ()
        {
            if (!string.IsNullOrWhiteSpace(fio)) { FIO = fio; }
        }

        /// <summary>Уникальный идентификатор объекта Actor</summary>
        public int id { get; set; }

        /// <summary>Ф.И.О.</summary>
        public string FIO { get; set; }

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

        public override string ToString() => FIO;
        

        [XmlIgnore]
        public List<Combine> CombineList { get; }


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

        private List<int> _videoID;
        /// <summary>Список ID фильмов</summary>
        public List<int> VideoID
        {
            get { return _videoID; }
            private set { _videoID = value; }
        }


        /// <summary>Этот метод проверяет наличие элемента в списке, если его нет, то выполняется добавление id.</summary>
        /// <param name="id">Идентификатор фильма (Media.id)</param>
        public void VideoID_Add(int id)
        {
            if (!VideoID.Contains(id)) _videoID.Add(id);
        }

        /// <summary>Этот метод проверяет наличие элемента в списке, если элемент есть, то выполняется удаление.</summary>
        /// <param name="id">Идентификатор фильма (Media)</param>
        public void VideoID_Remove(int id)
        {
            if (VideoID.Contains(id)) _videoID.Remove(id);
        }

        /// <summary>Этот метод выполняет очистку списка идентификаторов фильмов.</summary>
        public void VideoID_Clear() => _videoID.Clear();

        #endregion


        #region Сравнения

        public bool Equals(Actor act)
        {
            if (act != null)
            {
                return (act.FIO == this.FIO) ? true : false;
            }
            return false;
        }

        public int CompareTo(Actor compareObject) // Реализовать интерфейс IComparable<T>, т.е. получить возможность сортировки методом .Sort();
        {
            if (compareObject == null)
                throw new ArgumentNullException("compareObject", "compareObject cannot be a null");
            return FIO.CompareTo(compareObject.FIO);
        }

        public static int CompareByName(Actor actorA, Actor actorB)     // Сравнение по названию
        {
            if (actorA == null || actorB == null)
                throw new ArgumentNullException("actorA", "actorA and actorB cannot be a null");
            return string.Compare(actorA.FIO, actorB.FIO, StringComparison.OrdinalIgnoreCase);
        }

        public static int CompareByCountry(Actor actorA, Actor actorB)  // Сравнение по стране
        {
            if (actorA == null || actorB == null)
                throw new ArgumentNullException("actorA", "actorA and actorB cannot be a null");
            return string.Compare(actorA.CountryString, actorB.CountryString);
        }


        public static int CompareByDateOfBirth(Actor actorA, Actor actorB)  // Сравнение по дате рождения
        {
            if (actorA == null || actorB == null)
                throw new ArgumentNullException("actorA", "actorA and actorB cannot be a null");
            return string.Compare(actorA.DateOfBirth, actorB.DateOfBirth);
        }

        public static int CompareByDateOfDeath(Actor actorA, Actor actorB)  // Сравнение по дате смерти
        {
            if (actorA == null || actorB == null)
                throw new ArgumentNullException("actorA", "actorA and actorB cannot be a null");
            return string.Compare(actorA.DateOfDeath, actorB.DateOfDeath);
        }

        #endregion


        #region CA1036
        // CA1036: переопределяйте методы в сравнимых типах
        // msdn.microsoft.com/library/ms182163.aspx

        public static int Compare(Actor actorA, Actor actorB)
        {
            if (object.ReferenceEquals(actorA, actorB))
            {
                return 0;
            }
            if (object.ReferenceEquals(actorA, null))
            {
                return -1;
            }
            return actorA.CompareTo(actorB);
        }

        public override bool Equals(object obj)
        {
            Actor other = obj as Actor;
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            char[] c = this.FIO.ToCharArray();
            return (int)c[0];
        }

        public static bool operator ==(Actor actorA, Actor actorB)
        {
            if (object.ReferenceEquals(actorA, null))
            {
                return object.ReferenceEquals(actorB, null);
            }
            return actorA.Equals(actorB);
        }
        public static bool operator !=(Actor actorA, Actor actorB)
        {
            return !(actorA == actorB);
        }
        public static bool operator <(Actor actorA, Actor actorB)
        {
            return (Compare(actorA, actorB) < 0);
        }
        public static bool operator >(Actor actorA, Actor actorB)
        {
            return (Compare(actorA, actorB) > 0);
        }
        #endregion
    }
}
