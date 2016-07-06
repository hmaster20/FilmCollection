using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
