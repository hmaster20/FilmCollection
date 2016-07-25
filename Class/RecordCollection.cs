using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordCollection : RecCollection
    {
        // Поле содержащее путь к корневой папке
        private string _source = "";                            
        [XmlAttribute("source")]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }


        // Тестовое ПОЛЕ
        private string _txt = "";                               
        [XmlElement]
        public string Txt
        {
            get { return _txt; }
            set { _txt = value; }
        }


        // Поле сохранения параметра сплиттера
        private int _splitter1;                              
        [XmlAttribute]
        public int scMainSplitter
        {
            get { return _splitter1; }
            set { _splitter1 = value; }
        }


        // Поле сохранения параметра сплиттера
        private int _splitter2;                               
        [XmlAttribute]
        public int scTabFilmSplitter
        {
            get { return _splitter2; }
            set { _splitter2 = value; }
        }


        // Поле сохранения параметра ширины колонок
        private string _columnsWidth;                             
        [XmlAttribute]
        public string ColumnsWidth
        {
            get { return _columnsWidth; }
            set { _columnsWidth = value; }
        }


        // Поле сохранения состояния главной формы
        private string _formState;                         
        [XmlAttribute]
        public string FormState
        {
            get { return _formState; }
            set { _formState = value; }
        }
    }
}
