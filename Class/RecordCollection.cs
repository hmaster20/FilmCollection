using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Linq;

namespace FilmCollection
{
    /// <summary>
    /// Класс управления коллекцией фильмотеки
    /// </summary>
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


        public List<Actor> ActorList { get; set; }                  // Объявление списка        
        public void Add(Actor actor) => ActorList.Add(actor);       // Добавление актера
        public void Remove(Actor actor) => ActorList.Remove(actor); // Удаление актера
        public void ClearActor() => ActorList.Clear();              // Очистить коллекцию


        private static int MediaID { get; set; }               // Идентификатор Media
        public static int GetMediaID() => ++MediaID;           // создание следующего номера
        public static void ResetMediaID() => MediaID = 0;      // обнуление идентификатора
        public static void SetMediaID(int value) => MediaID = value;


        private static int ActorID { get; set; }               // Идентификатор актеров
        public static int GetActorID() => ++ActorID;           // Генерация идентификатора  // return ++ActorID;
        public static void ResetActorID() => ActorID = 0;      // обнуление идентификатора
        public static void SetActorID(int value) => ActorID = value;




        #region Сериализация

        public void Save() => XmlSerializeHelper.SerializeAndSave(RecordOptions.BaseName, this);    // Сохранение

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

                Dictionary<int, Actor> actorDic = new Dictionary<int, Actor>();
                //result.ActorList.ForEach(act => actorDic.Add(act.id, act));  

                foreach (Actor actor in result.ActorList)
                {
                    actorDic.Add(actor.id, actor);
                    foreach (int videoID in actor.VideoID)
                    {
                        if (combineDic.ContainsKey(videoID))
                        {
                            actor.CombineList.Add(combineDic[videoID]);
                            combineDic[videoID].media.ActorList.Add(actor);
                        }
                    }
                }

                if (actorDic.Count > 0) SetActorID(actorDic.Keys.Max());
                if (combineDic.Count > 0) SetMediaID(combineDic.Keys.Max());

            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка на этапе загрузки файла базы. \n" + ex.Message);
                //return new RecordCollection();
            }
            return result;
        }

        #endregion
    }
}
