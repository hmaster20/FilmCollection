using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{

    public class RecordCollection
    {
        public RecordCollection()               // Конструктор
        {
            VideoList = new List<Record>();         // Создание списка фильмов
            ActorList = new List<Actor>();          // Создание списка актеров
            FileRecordList = new List<FileRecord>();
        }

        // MediaList = new List<Media>();// { new Media() { Name = "", Description = "" , Id=0, Year=2000} };      // Создание списка мультимедиа (Базы)

        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();   // Параметры настройки



        public List<FileRecord> FileRecordList { get; set; } // Объявление списка        
        public void Add(FileRecord _FileRecord) => FileRecordList.Add(_FileRecord);       // Добавление
        public void Remove(FileRecord _FileRecord) => FileRecordList.Remove(_FileRecord); // Удаление
        public void ClearMedia() => FileRecordList.Clear();              // Очистить




        #region Список мультимедиа (База)

        public int MediaID { get; set; }      // Идентификатор
        public int getMediaID() => ++MediaID;         // Генерация идентификатора
        public void clearMediaID() => MediaID = 0;    // обнуление идентификатора


        public List<Media> MediaList { get; set; } // Объявление списка        
        public void Add(Media media) => MediaList.Add(media);       // Добавление
        public void Remove(Media media) => MediaList.Remove(media); // Удаление
        public void ClearMedia() => MediaList.Clear();              // Очистить

        #endregion



        #region Список

        //public int RecordID { get; set; }      // Идентификатор фильмов
        //public int getRecordID() => ++RecordID;         // Генерация идентификатора  //return ++RecordID;   
        //public void clearRecordID() => RecordID = 0;    // обнуление идентификатора  // RecordID = 0;

        public List<Record> VideoList { get; set; } // Объявление списка
        public void Add(Record record) => VideoList.Add(record);        // Добавление записи
        public void Remove(Record record) => VideoList.Remove(record);  // Удаление записи  
        public void ClearVideo() => VideoList.Clear();                  // Очистить коллекцию


        //void max()
        //{
        //    int maxAge = FindMaxAge(VideoList);
        //    //VideoList.Find();
        //}

        //private int FindMaxAge(List<Record> list)
        //{
        //    if (list.Count == 0)
        //    {
        //        throw new InvalidOperationException("Empty list");
        //    }
        //    int maxAge = int.MinValue;
        //    foreach (Record type in list)
        //    {
        //        if (type.Id > maxAge)
        //        {
        //            maxAge = type.Id;
        //        }
        //    }
        //    return maxAge;
        //}
        #endregion


        #region Актеры

        public int ActorID { get; set; }      // Идентификатор актеров
        public int getActorID() => ++ActorID; // Генерация идентификатора  // return ++ActorID;
        public void clearActorID() => ActorID = 0;  // обнуление идентификатора

        // Список актеров
        public List<Actor> ActorList { get; set; } // Объявление списка        
        public void Add(Actor actor) => ActorList.Add(actor);       // Добавление актера
        public void Remove(Actor actor) => ActorList.Remove(actor); // Удаление актера
        public void ClearActor() => ActorList.Clear();              // Очистить коллекцию

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
