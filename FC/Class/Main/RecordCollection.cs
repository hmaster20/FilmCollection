using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Linq;

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
            try
            {
                if (_recordCollection == null)
                    _recordCollection = Load(true);
                return _recordCollection;
            }
            catch (ApplicationException ex)
            {
                Logs.Log("При загрузки экземпляра коллекции произошла ошибка:", ex);
                return null;
            }
        }

        public static bool status()
        {
            bool status = (_recordCollection == null) ? false : true;
            return status;
        }

        public static void SetInstance(RecordCollection rc)
        {
            if (_recordCollection == null)
                _recordCollection = rc;
        }

        public RecordCollection()
        {
            ActorList = new List<Actor>();      // Создание списка актеров
            CombineList = new List<Combine>();  // Создание смешанного списка Record & Media
            SourceList = new List<Sources>();   // Создание списка источников данных
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

        public object Clone() => this.MemberwiseClone();


        public List<Combine> CombineList { get; }
        public void Add(Combine cm) => CombineList.Add(cm);
        public void Remove(Combine cm) => CombineList.Remove(cm);
        public void ClearCombine() => CombineList.Clear();


        #region Медиа
        private static int MediaID { get; set; }
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetMediaID { get { return ++MediaID; } } 
        public static int GetMediaID() => ++MediaID;           // создание следующего номера        
        public static void ResetMediaID() => MediaID = 0;
        public static void SetMediaID(int value) => MediaID = value;
        #endregion


        #region Актеры
        public List<Actor> ActorList { get; }
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
        public void ClearActor() => ActorList.Clear();
        private static int ActorID { get; set; }               // Идентификатор актеров
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //public int GetActorID { get { return ++ActorID; } } 
        public static int GetActorID() => ++ActorID;        // Генерация идентификатора  // return ++ActorID;
        public static void ResetActorID() => ActorID = 0;      // обнуление идентификатора
        public static void SetActorID(int value) => ActorID = value;
        #endregion


        #region Источники файлов
        public List<Sources> SourceList { get; }
        public int AddSource(string source)
        {
            if (!SourceList.Exists(x => x.Source == source))
            {
                Sources src = new Sources();
                src.Id = GetSourceID();
                src.Source = source;
                SourceList.Add(src);

                //SourceList.Add(new Sources(GetSourceID(), source));
            }
            return SourceList.First(x => x.Source == source).Id;
        }

        private static int SourceID { get; set; }
        public static int GetSourceID() => ++SourceID;
        public static void ResetSourceID() => SourceID = 0;
        public static void SetSourceID(int value) => SourceID = value;
        #endregion


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
                    //result = (RecordCollection)RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>();
                    result = XmlSerializeHelper.LoadAndDeserialize<RecordCollection>();

                }
                else
                {
                    result = XmlSerializeHelper.LoadAndDeserializeMemory<RecordCollection>();
                }

                //result = (fromFile)
                //    ? RecordOptions.BaseName.LoadAndDeserialize<RecordCollection>()
                //    : XmlSerializeHelper.LoadAndDeserializeMemory<RecordCollection>();
            }
            catch (Exception ex) { throw new ApplicationException($"Ошибка на этапе загрузки при десериализации. \n{ex.Message}"); }
            

            Dictionary<int, Combine> combineDic = new Dictionary<int, Combine>();
            try
            {
                foreach (Combine com in result.CombineList)
                {
                    combineDic.Add(com.media.Id, com);
                    foreach (var record in com.recordList)
                        record.combineLink = com;           // привязываем record.combineLink к родителю
                }
            }
            catch (Exception ex) { throw new ApplicationException("Ошибка на этапе загрузки с индексами медиа-файлов. \n" + ex.Message); }
            

            Dictionary<int, Actor> actorDic = new Dictionary<int, Actor>();
            try
            {
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

                // Установка текущего значения счетчика
                if (actorDic.Count > 0) SetActorID(actorDic.Keys.Max());
                if (combineDic.Count > 0) SetMediaID(combineDic.Keys.Max());
                if (result.SourceList.Count > 0) SetSourceID(result.SourceList.Max(x => x.Id) + 1);
            }
            catch (Exception ex) { throw new ApplicationException("Ошибка на этапе загрузки файла базы. \n" + ex.Message); }
            

            _recordCollection = result;
            return result;
        }
        #endregion
    }
}