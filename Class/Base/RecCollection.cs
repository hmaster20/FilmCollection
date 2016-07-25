using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{
    public class RecCollection
    {
        private List<Record> _videoList;
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

        // Создание списка коллекции типа Record
        public RecCollection()
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
    }
}
