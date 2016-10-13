using System;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordOptions
    {
        private static string fileName = "VideoList.xml";       // Файл базы коллекции
        [XmlIgnore]
        public static string BaseName { get { return fileName; } }

        public string Source { get; set; }          // Путь к корневой папке

        public int ID { get; set; }

        public int scMainSplitter { get; set; }     // Сохранение параметров сплиттеров
        public int scTabFilmSplitter { get; set; }

        public string ColumnsWidth { get; set; }   // Поле сохранения параметра ширины колонок

        [XmlAttribute]
        public string FormState { get; set; }       // Поле сохранения состояния главной формы



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
