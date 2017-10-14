using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        static MemoryStream streamCollection { get; set; }


        #region Сохранение путем сериализации
        public static void SerializeAndSaveToMemory(object serializeObject)
        {
            if (serializeObject == null)
                throw new ArgumentNullException("serializeObject", "serializeObject не может быть null");

            try
            {
                streamCollection = new MemoryStream();
                new XmlSerializer(serializeObject.GetType()).Serialize(streamCollection, serializeObject);
            }
            catch (Exception ex) { throw new ArgumentException(ex.Message + "\nПричина: " + ex.InnerException.Message); }
        }


        static object locker = new object();
        public static void FromMemoryToSaveToFile()
        {
            lock (locker)
            {
                using (FileStream stream = new FileStream((Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), RecordOptions.BaseName)), FileMode.Create))
                {
                    streamCollection.Position = 0;
                    streamCollection.CopyTo(stream);
                }
            }
        }
        #endregion


        #region Загрузка путем десериализации
        public static T LoadAndDeserialize<T>(this string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("Файл базы не существует!");

            if ((new FileInfo(fileName).Length) < 200)
                throw new ArgumentException("Некорректный файл XML");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), fileName), FileMode.Open))
                {
                    var t = (T)serializer.Deserialize(stream);
                    SerializeAndSaveToMemory(t);
                    return t;
                }
            }
            catch (Exception ex) { throw new ArgumentException(ex.Message + "\nПричина: " + ex.InnerException.Message); }
        }


        public static T LoadAndDeserializeMemory<T>()
        {
            if (streamCollection == null)
                throw new ArgumentException("Некорректный поток");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                streamCollection.Position = 0;
                return (T)serializer.Deserialize(streamCollection);
            }
            catch (Exception ex) { throw new ArgumentException(ex.Message + "\nПричина: " + ex.InnerException.Message); }

        }
        #endregion

    }
}
