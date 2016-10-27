using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FilmCollection
{

    public class RecordCollection
    {
        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();   // Параметры настройки


        public RecordCollection()               // Конструктор
        {
            VideoList = new List<Record>();     // Создание списка фильмов
            ActorList = new List<Actor>();      // Создание списка актеров
        }
        
        public int RecordID { get; set; }      // Идентификатор фильмов
        public int getRecordID() => ++RecordID;         // return ++RecordID;   
        public void clearRecordID() => RecordID = 0;    // RecordID = 0;
        

        public int ActorID { get; set; }      // Идентификатор актеров
        public int getActorID() => ++ActorID; // Идентификатор актеров  // return ++ActorID;
        public void clearActorID() => ActorID = 0;     // ActorID = 0;
        


        #region Список фильмов
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


        #region Список актеров

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
