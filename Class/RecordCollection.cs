﻿using System.Collections.Generic;
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

        private string _txt = "";                               // тестовый элемент   
        [XmlElement]
        public string Txt
        {
            get { return _txt; }
            set { _txt = value; }
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
