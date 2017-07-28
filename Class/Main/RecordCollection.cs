using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.ComponentModel;

namespace FilmCollection
{
    /// <summary>Класс управления коллекцией фильмотеки, состоящей из фильмов (CombineList) и актеров (ActorList)</summary>
    public class RecordCollection : ICloneable
    {
        [XmlElement]
        public RecordOptions Options { get; set; } = new RecordOptions();
        public RecordCollectionMaintenance Maintenance { get; set; } = new RecordCollectionMaintenance();


        private static RecordCollection _recordCollection;
        public static RecordCollection GetInstance()
        {
            if (_recordCollection == null)
                _recordCollection = Load();
            return _recordCollection;
        }

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
            catch (ApplicationException ex) { MessageBox.Show(ex.Message); }
        }


        public List<Combine> CombineList { get; }
        public void Add(Combine cm) => CombineList.Add(cm);
        public void Remove(Combine cm) => CombineList.Remove(cm);
        public void ClearCombine() => CombineList.Clear();


        public List<Actor> ActorList { get; }                  // Объявление списка        
        public void Add(Actor actor) => ActorList.Add(actor);
        public void Remove(Actor actor)
        {
            foreach (var cm in CombineList)
            {
                if (cm.media.ActorList.Exists(x => x == actor))
                {
                    cm.media.ActorList.Remove(actor);
                }

                if (cm.media.ActorListID.Exists(x => x == actor.id))
                {
                    cm.media.ActorListID.Remove(actor.id);
                }
            }
            ActorList.Remove(actor);
        }

        public void ClearActor() => ActorList.Clear();              // Очистить коллекцию


        private static int MediaID { get; set; }               // Идентификатор Media


        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetMediaID { get { return ++MediaID; } } 
        public static int GetMediaID() => ++MediaID;           // создание следующего номера


        public static void ResetMediaID() => MediaID = 0;      // обнуление идентификатора
        public static void SetMediaID(int value) => MediaID = value;


        private static int ActorID { get; set; }               // Идентификатор актеров

        /// <summary>Метод создает и присваивает следующий номер.</summary>
        /// 

        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetActorID { get { return ++ActorID; } } 
        public static int GetActorID() => ++ActorID;        // Генерация идентификатора  // return ++ActorID;
        public static void ResetActorID() => ActorID = 0;      // обнуление идентификатора
        public static void SetActorID(int value) => ActorID = value;
        
        #region Сериализация

        /// <summary>Сохранение (Сериализация) коллекции в MemoryStream</summary>
        public void Save() => XmlSerializeHelper.SerializeAndSaveToMemory(this);

        /// <summary>Сохранение (Сериализация) коллекции в файл XML</summary>
        public void SaveToFile() => XmlSerializeHelper.FromMemoryToSaveToFile();




        /// <summary>Загрузка (деСериализация) объектов из файла XML</summary>
        /// <returns>Возвращает коллекцию RecordCollection</returns>
        public static RecordCollection Load(bool fromFile = false)
        {
            RecordCollection result;
            try
            {
                if (fromFile)
                {
                    result = RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>();
                }
                else
                {
                    result = XmlSerializeHelper.LoadAndDeserializeMemory<RecordCollection>();
                }

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
                throw new ApplicationException("Ошибка на этапе загрузки файла базы. \n" + ex.Message);
                //return new RecordCollection();
            }

            _recordCollection = result;
            return result;
        }

        //RecordCollection VideoCollection = (RecordCollection)videoCollection.Clone();
        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}

        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
