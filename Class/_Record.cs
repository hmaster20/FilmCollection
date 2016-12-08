// Информация о физических файлах
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class Record
    {
        public bool Visible { get; set; }       // Видимость записи
        public string Name { get; set; }        // Название Фильма
        public int linkID { get; set; } = 0;    // идентификатор MediaID
        public string FileName { get; set; }    // Название файла
        public string DirName { get; set; }     // Название папки в которой расположен файл
        public string Extension { get; set; }   // Расширение (тип) файла (avi, mkv, mpeg)
        public string Path { get; set; }        // Путь к файлу


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

        

        // информация служит для получения доп. информации при построении таблицы

        // создаем количество файлов и меди поровну
        // как только находим сериал, то создаем отдельный медиа и в него добавляем файлы, остальные медиа уничтожаем.


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

        public static int CompareByYear(Record a, Record b)
        {
            if (a.mYear == b.mYear)
                return CompareByName(a, b);
            return (a.mYear - b.mYear);
        }

        public static int CompareByCountry(Record a, Record b)  // Сравнение по стране
        {
            return string.Compare(a.mCountry, b.mCountry);
        }

        public static int CompareByGenre(Record a, Record b) // Сравнение по жанру
        {
            return string.Compare(a.mGenre, b.mGenre);
        }

        public static int CompareByCategory(Record a, Record b) // Сравнение по категории
        {
            if (a.mCategory == b.mCategory)
                return CompareByName(a, b);
            if (a.mCategory == CategoryVideo.Film.ToString())
                return -1;
            if (b.mCategory == CategoryVideo.Film.ToString())
                return 1;
            if (a.mCategory == CategoryVideo.Cartoon.ToString())
                return -1;
            if (b.mCategory == CategoryVideo.Cartoon.ToString())
                return 1;
            if (a.mCategory == CategoryVideo.Series.ToString())
                return -1;
            if (b.mCategory == CategoryVideo.Series.ToString())
                return 1;
            if (a.mCategory == CategoryVideo.Unknown.ToString())
                return -1;
            if (b.mCategory == CategoryVideo.Unknown.ToString())
                return 1;
            return 0;
        }

        public static int CompareByTime(Record a, Record b)     // Сравнение по времени записи
        {
            if (a.TimeVideoSpan >= b.TimeVideoSpan)
                return 1;
            else if (a.TimeVideoSpan <= b.TimeVideoSpan)
                return -1;
            else
                return 0;
        }

        public static int CompareByFileName(Record a, Record b) // Сравнение по файлу
        {
            return string.Compare(a.FileName, b.FileName);
        }

        #endregion

    }
}
