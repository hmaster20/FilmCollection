using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace FilmCollection
{

    public class RecordCollection
    {
        public RecordCollection()               // Конструктор
        {
            VideoList = new List<Record>();     // Создание списка фильмов
            ActorList = new List<Actor>();      // Создание списка актеров
        }


        private RecordOptions _options = new RecordOptions();   // Параметры настройки
        [XmlElement]
        public RecordOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }

        #region Список фильмов

        private List<Record> _videoList;                        // Объявление списка
        public List<Record> VideoList
        {
            get { return _videoList; }
            set { _videoList = value; }
        } 

        public void Add(Record record)                          // Добавление записи
        {
            VideoList.Add(record);
        }

        public void Remove(Record record)                       // Удаление записи
        {
            VideoList.Remove(record);
        }
        
        public void ClearVideo()                                     // Очистить коллекцию
        {
            VideoList.Clear();
        }

        #endregion


        #region Список актеров

        private List<Actor> _actorList;                        // Объявление списка
        public List<Actor> ActorList
        {
            get { return _actorList; }
            set { _actorList = value; }
        }

        public void Add(Actor actor)                          // Добавление актера
        {
            ActorList.Add(actor);
        }

        public void Remove(Actor actor)                       // Удаление актера
        {
            ActorList.Remove(actor);
        }

        public void ClearActor()                                     // Очистить коллекцию
        {
            ActorList.Clear();
        }

        #endregion


        #region Сериализация

        public void Save()                                      // Сохранение
        {
            XmlSerializeHelper.SerializeAndSave(RecordOptions.BaseName, this);
        }

        public static RecordCollection Load()                   // Загрузка
        {
            RecordCollection result;
            try
            {
                result = RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return new RecordCollection();
            }
            return result;
        }

        #endregion
    }
}
