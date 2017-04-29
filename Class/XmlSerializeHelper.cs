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
        //static MemoryStream streamCollection = new MemoryStream();
        static MemoryStream streamCollection { get; set; }

        #region Сохранение путем сериализации

        /// <summary>Сериализация (сохранение объекта) в файл</summary>
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            try
            {
                FileStream stream = NewMethod(filename);
                {
                    new XmlSerializer(objectToSerialize.GetType()).Serialize(stream, objectToSerialize);
                }
                stream.Dispose();

                // SerializeAndSaveMemory(objectToSerialize);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        static object lockr = new object();
        private static FileStream NewMethod(string filename)
        {
            lock (lockr)
            {
                return new FileStream((Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename)), FileMode.Create);
            }
        }

        public static void SerializeAndSaveMemory(object obj)
        {
            try
            {
                streamCollection = new MemoryStream();
                new XmlSerializer(obj.GetType()).Serialize(streamCollection, obj);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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








        //static AutoResetEvent autoEvent;

        //static void DoWork()
        //{
        //    Console.WriteLine("   worker thread started, now waiting on event...");//save to Memory
        //    autoEvent.WaitOne();
        //    Console.WriteLine("   worker thread reactivated, now exiting...");
        //}

        //static void Run()
        //{
        //    autoEvent = new AutoResetEvent(false);

        //    Console.WriteLine("main thread starting worker thread...");//Сохранение
        //    Thread t = new Thread(DoWork);
        //    t.Start();

        //    Console.WriteLine("main thread sleeping for 1 second...");

        //    Thread.Sleep(1000);

        //    Console.WriteLine("main thread signaling worker thread...");
        //    autoEvent.Set();
        //}





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
