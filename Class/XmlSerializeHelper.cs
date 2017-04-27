using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        //static MemoryStream streamCollection = new MemoryStream();
        static MemoryStream streamCollection;

        #region Сохранение путем сериализации

        /// <summary>Сериализация (сохранение объекта) в файл</summary>
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            try
            {
                Debug.Print("SerializeAndSave : " + DateTime.Now.ToString());
                using (FileStream stream = new FileStream((Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename)), FileMode.Create))
                {
                    new XmlSerializer(objectToSerialize.GetType()).Serialize(stream, objectToSerialize);
                }
                Debug.Print("SerializeAndSave : " + DateTime.Now.ToString());
               // SerializeAndSaveMemory(objectToSerialize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static void SerializeAndSaveMemory(object objectToSerialize)
        {
            try
            {
                Debug.Print("SerializeAndSaveMemory : " + DateTime.Now.ToString());
                streamCollection = new MemoryStream();
                new XmlSerializer(objectToSerialize.GetType()).Serialize(streamCollection, objectToSerialize);
                Debug.Print("SerializeAndSaveMemory : " + DateTime.Now.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        #endregion


        #region Загрузка путем десериализации

        ///// <summary>Селектор загрузки</summary>
        //public static RecordCollection LoadSelector()
        //{
        //    if (streamCollection != null && streamCollection.Length != 0)
        //    {
        //        return LoadAndDeserializeMemory<RecordCollection>();
        //    }
        //    else
        //    {
        //        return LoadAndDeserialize<RecordCollection>(RecordOptions.BaseName);
        //    }
        //}


        static object locker = new object();
        public static void LoadSelector()
        {
            Debug.Print("locker : " + DateTime.Now.ToString());
            lock (locker)
            {
                Debug.Print("LoadSelector : " + DateTime.Now.ToString());
                using (FileStream stream = new FileStream((Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName)), FileMode.Create))
                {
                    streamCollection.Position = 0;
                    streamCollection.CopyTo(stream);
                }
                Debug.Print("LoadSelector : " + DateTime.Now.ToString());
            }
        }


        public static T LoadAndDeserialize<T>(this string filename)
        {
            if (!File.Exists(filename))
                throw new Exception("File not exist");


            if ((new FileInfo(filename).Length) < 200)
                throw new Exception("Некорректный файл XML");


            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Open))
                {
                    var t = (T)serializer.Deserialize(stream);
                    SerializeAndSaveMemory(t);
                    return t;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message); }
        }


        public static T LoadAndDeserializeMemory<T>()
        {
            if (streamCollection == null)
                throw new Exception("Некорректный поток");
            
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                //streamCollection.Seek(0, SeekOrigin.Begin);
                streamCollection.Position = 0;
                return (T)serializer.Deserialize(streamCollection);

               // var t = (T)serializer.Deserialize(streamCollection);
               // return t;
            }
            catch (Exception ex) { throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message); }

        }
        #endregion

    }
}
