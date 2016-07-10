using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecordCollection
    {
        private static string fileName = "VideoList.xml";

        private List<Record> _videoList;
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

        private string _source = ""; // Ресурс
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
    }
}
