using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        static MemoryStream streamCollection = new MemoryStream();


        #region Сохранение путем сериализации

        /// <summary>Сериализация (сохранение объекта) в файл</summary>
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            try
            {
                using (FileStream stream = new FileStream((Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename)), FileMode.Create))
                {
                    new XmlSerializer(objectToSerialize.GetType()).Serialize(stream, objectToSerialize);
                }
                SerializeAndSaveMemory(objectToSerialize);
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
                streamCollection.Position = 0;
                new XmlSerializer(objectToSerialize.GetType()).Serialize(streamCollection, objectToSerialize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        #endregion


        #region Загрузка путем десериализации

        /// <summary>Селектор загрузки</summary>
        public static RecordCollection LoadSelector()
        {
            if (streamCollection != null && streamCollection.Length != 0)
            {
                return LoadAndDeserializeMemory<RecordCollection>();
            }
            else
            {
                return LoadAndDeserialize<RecordCollection>(RecordOptions.BaseName);
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


            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                streamCollection.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(streamCollection);
            }
            catch (Exception ex) { throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message); }
        }
        #endregion

    }
}
