using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace FilmCollection
{
    /// <summary>Параметры настроек программы</summary>
    public class RecordOptions
    {
        public static bool isDebug { get; set; } =
#if DEBUG
            true;
#else
            false;
#endif

        /// <summary>Файл базы коллекции "VideoList.xml"</summary>
        [XmlIgnore]
        //public static string BaseName { get; } = "VideoList.xml";
        //static readonly string BaseName = "VideoList.xml";
        public const string BaseName = "VideoList.xml";

        /// <summary>Метод генерирует массив вида ".avi", ".mkv", ".mp4", ".wmv", ".webm", ".rm", ".mpg", ".mpeg", ".flv", ".divx"</summary>
        public static List<string> FormatAdd()
        {
            List<string> FormatAdd = new List<string>();
            foreach (var item in Enum.GetValues(typeof(MediaFormat)))
            {
                FormatAdd.Add("." + item.ToString());
            }
            return FormatAdd;
        }

        /// <summary>Метод генерирует строку вида "Видео (*.avi, *.mkv, *.mp4, ..)|*.avi;*.mkv;*.mp4;*.wmv;*.webm;*.rm;*.mpg;*.flv;*.divx|Все файлы (*.*) | *.*"</summary>
        public static string FormatOpen()
        {
            string FormatOpen = "Видео(*.avi, *.mkv, *.mp4, ..) |";
            foreach (var item in Enum.GetValues(typeof(MediaFormat)))
            {
                FormatOpen = FormatOpen + "*." + item.ToString() + ";";
            }
            FormatOpen = FormatOpen.Remove(FormatOpen.Length - 1, 1) + "|Все файлы (*.*) | *.*";
            return FormatOpen;
        }

        /// <summary>Каталог изображений</summary>
        public static string PicsFolder()
        {
            return  Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics");
        }

        /// <summary>Путь к корневой папке</summary>
        public string Source { get; set; } 

        public int scMainSplitter { get; set; }     // Сохранение параметров сплиттеров
        public int scTabFilmSplitter { get; set; }

        public string ColumnsWidth { get; set; }   // Поле сохранения параметра ширины колонок

        [XmlAttribute]
        public string FormState { get; set; }       // Поле сохранения состояния главной формы

        public static bool ToTray { get; set; }


        // Тестовое ПОЛЕ
        private string _txt = "";
        [XmlElement]
        public string Txt
        {
            get { return _txt; }
            set { _txt = value; }
        }
    }
}
