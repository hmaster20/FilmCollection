using System.Xml.Serialization;

namespace FilmCollection
{
    public class Record : Rec
    {
   

        public static int CompareByName(Record a, Record b) // Сравнение по названию
        {
            return string.Compare(a.Name, b.Name);
        }

        public static int CompareByCategory(Record a, Record b) // Сравнение по категории
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
            return 0;
        }

        //public static int CompareByScore(Record a, Record b)
        //{
        //    if (a.Score == b.Score)
        //        return CompareByName(a, b);
        //    return (int)((b.Score - a.Score) * 100);
        //}

        //public static int CompareByUserScore(VideoRecord a, VideoRecord b)
        //{
        //    if (a.UserScore == b.UserScore)
        //        return CompareByName(a, b);
        //    return (int)((b.UserScore - a.UserScore) * 100);
        //}

        public static int CompareByTime(Record a, Record b) // Сравнение по времени записи
        {
            if (a.Time == b.Time)
                return CompareByName(a, b);
            return (int)((b.Time - a.Time) * 100);
        }

        public static int CompareByYear(Record a, Record b) // Сравнение по году
        {
            if (a.Year != "" && b.Year != "") { 
            string aYearString = a.Year.Substring(0, 4);
            string bYearString = b.Year.Substring(0, 4);

            if (aYearString == bYearString)
                return CompareByName(a, b);
            int aYear = 0;
            int bYear = 0;
            if (int.TryParse(aYearString, out aYear) && int.TryParse(bYearString, out bYear))
                return (int)((bYear - aYear) * 100);
            }
            return CompareByName(a, b);
        }

    }

}
