using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;

namespace FilmCollection
{

    public class RecordCollection
    {
        private RecordOptions _options = new RecordOptions();   // Параметры настройки
        [XmlElement]
        public RecordOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }

        private List<Record> _videoList;                        // Объявление списка
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        }

        public RecordCollection()                               // Создание списка
        {
            VideoList = new List<Record>();
        }

        public void Add(Record record)                          // Добавление записи
        {
            VideoList.Add(record);
        }

        public void Save()                                      // Сохранение
        {
            XmlSerializeHelper.SerializeAndSave(RecordOptions.BaseName, this);
        }

        public void Remove(Record record)                       // Удаление записи
        {
            VideoList.Remove(record);
        }

        public void Clear()                                     // Очистить коллекцию
        {
            VideoList.Clear();
        }

        public static RecordCollection Load()                   // Загрузка коллекции
        {
            RecordCollection result;
            try
            {
                result = RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>();
            }
            catch
            {
                return new RecordCollection();
            }
            return result;
        }
    }
}