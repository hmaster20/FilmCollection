using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace FilmCollection
{

    public class RecordCollection
    {
        public RecordCollection()
        {
            ActorList = new List<Actor>();      // Создание списка актеров
            CombineList = new List<Combine>();  // Создание смешанного списка Record & Media
        }

        public int MediaID { get; set; }            // нумератор
        public int getMediaID() => ++MediaID;       // создание следующего номера
        public void ClearMediaID() => MediaID = 0;    // обнуление идентификатора


        public List<Combine> CombineList { get; set; }
        public void Add(Combine cm) => CombineList.Add(cm);
        public void Remove(Combine cm) => CombineList.Remove(cm);
        public void ClearCombine() => CombineList.Clear();


        public void Clear()
        {
            try
            {
                ClearActor();
                ClearCombine();
                ClearMediaID();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();   // Параметры настройки

        #region Список мультимедиа (База)

        //public int MediaID { get; set; }      // Идентификатор
        //public int getMediaID() => ++MediaID;         // Генерация идентификатора
        //public void clearMediaID() => MediaID = 0;    // обнуление идентификатора


        //public List<Media> MediaList { get; set; } // Объявление списка        
        //public void Add(Media media) => MediaList.Add(media);       // Добавление
        //public void Remove(Media media) => MediaList.Remove(media); // Удаление
        //public void ClearMedia() => MediaList.Clear();              // Очистить

        #endregion


        #region Список

        //public int RecordID { get; set; }      // Идентификатор фильмов
        //public int getRecordID() => ++RecordID;         // Генерация идентификатора  //return ++RecordID;   
        //public void clearRecordID() => RecordID = 0;    // обнуление идентификатора  // RecordID = 0;

        //public List<Record> VideoList { get; set; } // Объявление списка
        //public void Add(Record record) => VideoList.Add(record);        // Добавление записи
        //public void Remove(Record record) => VideoList.Remove(record);  // Удаление записи  
        //public void ClearVideo()
        //{
        //    try
        //    {
        //        VideoList.Clear();                  // Очистить коллекцию
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //    }
        //}





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

                Dictionary<int, Combine> combineDic = new Dictionary<int, Combine>();

                foreach (Combine com in result.CombineList)
                {
                    combineDic.Add(com.media.Id, com);
                    foreach (var record in com.recordList)
                        record.combineLink = com;           // привязываем record.combineLink к родителю
                }

                foreach (Actor actor in result.ActorList)
                    foreach (int videoID in actor.VideoID)
                    {
                        if (combineDic.ContainsKey(videoID))
                        {
                            actor.CombineList.Add(combineDic[videoID]);
                            combineDic[videoID].media.ActorList.Add(actor);
                        }
                    }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка на этапе загрузки файла базы. " + ex.Message);
                //return new RecordCollection();
            }


            return result;
        }

        #endregion
    }
}
