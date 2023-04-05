using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using FC.Provider.Class.Main.Units;

namespace FC.Provider.Class.Main.Collection
{
    /// <summary>Параметры настроек программы</summary>
    public static class CollectionOptions
    {
        public static bool isDebug { get; set; } =
#if DEBUG
            true;
#else
            false;
#endif

        /// <summary>Метод генерирует массив вида ".avi", ".mkv", ".mp4", ".wmv", ".webm", ".rm", ".mpg", ".mpeg", ".flv", ".divx"</summary>
        public static List<string> getFormat()
        {
            List<string> Format = new List<string>();
            foreach (var item in Enum.GetValues(typeof(MediaFormat)))
            {
                Format.Add("." + item.ToString());
            }
            return Format;
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
        public static string PicsFolder() => Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics");
  
        public static int scMainSplitter { get; set; }     // Сохранение параметров сплиттеров

        public static int scTabFilmSplitter { get; set; }

        public static string ColumnsWidth { get; set; }   // Поле сохранения параметра ширины колонок

        [XmlAttribute]
        public static string FormState { get; set; }       // Поле сохранения состояния главной формы

        public static bool ToTray { get; set; }


        // Тестовое ПОЛЕ
        //private string _txt = "";
        //[XmlElement]
        //public string Txt
        //{
        //    get { return _txt; }
        //    set { _txt = value; }
        //}
    }
}
