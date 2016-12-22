using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace FilmCollection
{
    public class RecordCollection
    {
        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();   // Параметры настройки

        public RecordCollection()
        {
            ActorList = new List<Actor>();      // Создание списка актеров
            CombineList = new List<Combine>();  // Создание смешанного списка Record & Media
        }

        public void Clear()
        {
            try
            {
                ClearActor();
                ClearCombine();
                ResetMediaID();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        

        public List<Combine> CombineList { get; set; }
        public void Add(Combine cm) => CombineList.Add(cm);
        public void Remove(Combine cm) => CombineList.Remove(cm);
        public void ClearCombine() => CombineList.Clear();



        private int MediaID { get; set; }               // нумератор
        public int GetMediaID() => ++MediaID;           // создание следующего номера
        public void ResetMediaID() => MediaID = 0;      // обнуление идентификатора



        private int ActorID { get; set; }               // Идентификатор актеров
        public int GetActorID() => ++ActorID;           // Генерация идентификатора  // return ++ActorID;
        public void ResetActorID() => ActorID = 0;      // обнуление идентификатора



        public List<Actor> ActorList { get; set; } // Объявление списка        
        public void Add(Actor actor) => ActorList.Add(actor);       // Добавление актера
        public void Remove(Actor actor) => ActorList.Remove(actor); // Удаление актера
        public void ClearActor() => ActorList.Clear();              // Очистить коллекцию

        
        

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
