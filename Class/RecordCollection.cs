using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordCollection
    {
        private static string fileName = "VideoList.xml";       // Файл базы
        [XmlIgnore]
        public static string BaseName
        {
            get { return fileName; }
        }

        private List<Record> _videoList;
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

        private string _source = "";                            // Расположение фильмов
        [XmlAttribute("source")]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public RecordCollection()
        {
            VideoList = new List<Record>();
        }

        public void Save()
        {
            XmlSerializeHelper.SerializeAndSave(fileName, this);
        }

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

        public void Add(Record record)
        {
            VideoList.Add(record);
        }

        public void Clear()
        {
            VideoList.Clear();
        }

        public void Remove(Record record)
        {
            VideoList.Remove(record);
        }




        private string _txt = "";                               // тестовый элемент   
        [XmlElement]
        public string Txt
        {
            get { return _txt; }
            set { _txt = value; }
        }

        private int _splitter1;                               // тестовый элемент   
        [XmlAttribute]
        public int scMainSplitter
        {
            get { return _splitter1; }
            set { _splitter1 = value; }
        }

        private int _splitter2;                               // тестовый элемент   
        [XmlAttribute]
        public int scTabFilmSplitter
        {
            get { return _splitter2; }
            set { _splitter2 = value; }
        }


        private string _columnsWidth;                          // тестовый элемент   
        [XmlAttribute]
        public string ColumnsWidth
        {
            get { return _columnsWidth; }
            set { _columnsWidth = value; }
        }


        private string _formState;                          // тестовый элемент   
        [XmlAttribute]
        public string FormState
        {
            get { return _formState; }
            set { _formState = value; }
        }


    }
}
