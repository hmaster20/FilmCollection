using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordOptions
    {
        public string Name { get; set; }

        private string _param = "";      
        public string Param
        {
            get { return _param; }
            set { _param = value; }
        }


        // Тестовое ПОЛЕ
        private string _txt = "";
        [XmlElement]
        public string Txt
        {
            get { return _txt; }
            set { _txt = value; }
        }


        // Файл базы коллекции
        private static string fileName = "VideoList.xml";       // Файл базы
        [XmlIgnore]
        public static string BaseName
        {
            get { return fileName; }
        }



        

        // Поле содержащее путь к корневой папке
        private string _source = "";
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        


        // Поле сохранения параметра сплиттера
        private int _splitter1;
        public int scMainSplitter
        {
            get { return _splitter1; }
            set { _splitter1 = value; }
        }


        // Поле сохранения параметра сплиттера
        private int _splitter2;
        public int scTabFilmSplitter
        {
            get { return _splitter2; }
            set { _splitter2 = value; }
        }


        // Поле сохранения параметра ширины колонок
        private string _columnsWidth;
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
