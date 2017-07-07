using System;
using System.Xml.Serialization;

namespace FilmCollection
{
    /// <summary>Класс содержит информацию о физических файлах.</summary>
    public class Record
    {
        public bool Visible { get; set; }       // Видимость записи
        public string Name { get; set; }        // Название Фильма
        public string FileName { get; set; }    // Название файла
        public string DirName { get; set; }     // Название папки в которой расположен файл
        public string Extension { get; set; }   // Расширение (тип) файла (avi, mkv, mpeg)
        public string Path { get; set; }        // Путь к файлу


        #region Для отображения в таблице
        [XmlIgnore]
        public Combine combineLink { get; set; }
        private bool check() { return (combineLink == null || combineLink.media == null) ? true : false; }
        [XmlIgnore]
        public string mName { get { return (check()) ? "" : combineLink.media.Name; } }
        [XmlIgnore]
        public string mDescription { get { return (check()) ? "" : combineLink.media.Description; } }
        [XmlIgnore]
        public string mPic { get { return (check()) ? "" : combineLink.media.Pic; } }
        [XmlIgnore]
        public string mCountry { get { return (check()) ? "" : combineLink.media.CountryString; } }
        [XmlIgnore]
        public string mGenre { get { return (check()) ? "" : combineLink.media.GenreString; } }
        [XmlIgnore]
        public string mCategory { get { return (check()) ? "" : combineLink.media.CategoryString; } }
        [XmlIgnore]
        public int mYear { get { return (check()) ? -1 : combineLink.media.Year; } }
        #endregion


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


        #region Сравнения

        public bool Equals(Record rec)
        {
            if (rec != null)
            {
                //Record temp;
                //temp = (Record)rec;
                //if (temp.FileName == this.FileName
                //&& temp.Path == this.Path)

                if (rec.FileName == this.FileName && rec.Path == this.Path)
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

        public static int CompareByName(Record recordA, Record recordB)     // Сравнение по названию
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            return string.Compare(recordA.Name, recordB.Name);
        }

        public static int CompareByCatalog(Record recordA, Record recordB)  // Сравнение по каталогу
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            return string.Compare(recordA.DirName, recordB.DirName);
        }

        public static int CompareByYear(Record recordA, Record recordB)
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            if (recordA.mYear == recordB.mYear)
                return CompareByName(recordA, recordB);
            return (recordA.mYear - recordB.mYear);
        }

        public static int CompareByCountry(Record recordA, Record recordB)  // Сравнение по стране
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            return string.Compare(recordA.mCountry, recordB.mCountry);
        }

        public static int CompareByGenre(Record recordA, Record recordB) // Сравнение по жанру
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            return string.Compare(recordA.mGenre, recordB.mGenre);
        }

        public static int CompareByCategory(Record recordA, Record recordB) // Сравнение по категории
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            if (recordA.mCategory == recordB.mCategory)
                return CompareByName(recordA, recordB);
            if (recordA.mCategory == CategoryVideo.Film.ToString())
                return -1;
            if (recordB.mCategory == CategoryVideo.Film.ToString())
                return 1;
            if (recordA.mCategory == CategoryVideo.Cartoon.ToString())
                return -1;
            if (recordB.mCategory == CategoryVideo.Cartoon.ToString())
                return 1;
            if (recordA.mCategory == CategoryVideo.Series.ToString())
                return -1;
            if (recordB.mCategory == CategoryVideo.Series.ToString())
                return 1;
            if (recordA.mCategory == CategoryVideo.Unknown.ToString())
                return -1;
            if (recordB.mCategory == CategoryVideo.Unknown.ToString())
                return 1;
            return 0;
        }

        public static int CompareByTime(Record recordA, Record recordB)     // Сравнение по времени записи
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            if (recordA.TimeVideoSpan >= recordB.TimeVideoSpan)
                return 1;
            else if (recordA.TimeVideoSpan <= recordB.TimeVideoSpan)
                return -1;
            else
                return 0;
        }

        public static int CompareByFileName(Record recordA, Record recordB) // Сравнение по файлу
        {
            if (recordA == null || recordB == null)
                throw new ArgumentNullException("recordA", "recordA и recordB не может содержать null");
            return string.Compare(recordA.FileName, recordB.FileName);
        }

        #endregion

    }
}
