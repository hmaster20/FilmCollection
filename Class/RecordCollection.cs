using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordCollection
    {


        private List<Record> _videoList;
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

        // Создание списка коллекции типа Record
        public RecordCollection()
        {
            VideoList = new List<Record>();
        }


        // Добавить запись
        public void Add(Record record)
        {
            VideoList.Add(record);
        }


        // Удалить запись
        public void Remove(Record record)
        {
            VideoList.Remove(record);
        }

        // Очистить коллекцию
        public void Clear()
        {
            VideoList.Clear();
        }


        // Файл базы коллекции
        private static string fileName = "VideoList.xml";       // Файл базы
        [XmlIgnore]
        public static string BaseName
        {
            get { return fileName; }
        }


        // Загрузка коллекции
        public static RecordCollection Load()
        {
            RecordCollection result;
            try
            {
                result = fileName.LoadAndDeserialize<RecordCollection>();
            }
            catch
            {
                return new RecordCollection();
            }

            return result;
        }


        // Сохранение коллекции
        public void Save()
        {
            XmlSerializeHelper.SerializeAndSave(fileName, this);
        }












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
