using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        static MemoryStream streamCollection = new MemoryStream();

        /// <summary>Сериализация (сохранение объекта) в файл</summary>
        /// <param name="filename">Имя файла RecordOptions.BaseName</param>
        /// <param name="objectToSerialize">Класс RecordCollection</param>
        /// <returns></returns>
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            try
            {
                string FileWithPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename);

                using (FileStream stream = new FileStream(FileWithPath, FileMode.Create))
                {
                    serializer.Serialize(stream, objectToSerialize);
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
            // MemoryStream streamCollection = SerializeToStream(objectToSerialize);

            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            try
            {
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    serializer.Serialize(stream, objectToSerialize);
                //}
               streamCollection.Position = 0;
                serializer.Serialize(streamCollection, objectToSerialize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public static RecordCollection LoadSelector()
        {
            if (streamCollection != null || streamCollection.Length!= 0)
            {
                return LoadAndDeserializeMemory<RecordCollection>(); 
               // RecordCollection RC = (RecordCollection)DeserializeFromStream(streamCollection);
               // return RC;
            }
            else
            {
                return LoadAndDeserialize<RecordCollection>("");
            }
        }


        public static T LoadAndDeserialize<T>(this string filename)
        {
            if (!File.Exists(filename))
                throw new Exception("File not exist");
            //long length = new FileInfo(filename).Length;
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
            catch (Exception ex)
            {
                //throw new Exception("Error during deserializing");
                throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message);
            }
        }


        //public static T LoadAndDeserializeMemory<T>(MemoryStream streamCollection)
        public static T LoadAndDeserializeMemory<T>()
        {
            if (streamCollection == null)
            {
                throw new Exception("Некорректный поток");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            try
            {
                //streamCollection.Position = 0;
                streamCollection.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(streamCollection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\nПричина: " + ex.InnerException.Message + "\nLoadAndDeserializeMemory");
            }
        }





        public static MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }

        public static object DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return o;
        }


    }
}

