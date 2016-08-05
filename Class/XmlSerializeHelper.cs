using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        public static long Count { get; set; }


        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Create))
                {
                   // MessageBox.Show("Запись потока. Текущая позиция: " + Convert.ToString(stream.Position) + ", длина потока: " + Convert.ToString(stream.Length));
                    serializer.Serialize(stream, objectToSerialize);
                   // MessageBox.Show("Запись потока. Финальная позиция: " + Convert.ToString(stream.Position) + ", длина потока: " + Convert.ToString(stream.Length));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static T LoadAndDeserialize<T>(this string filename)
        {
            if (!File.Exists(filename))
                throw new Exception("File not exist");

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Open))
                {
                    MessageBox.Show("Чтение потока. Текущая позиция: " + Convert.ToString(stream.Position) + 
                        ", длина потока: " + Convert.ToString(stream.Length));

                    var v = serializer.Deserialize(stream);
                    Count = stream.Position;

                    MessageBox.Show("Чтение потока. Финальная позиция: " + Convert.ToString(stream.Position) + 
                        ", длина потока: " + Convert.ToString(stream.Length));

              

           

                    return (T)v;


                    //int data;
                    //long test = 0;
                    //long total = stream.Length;
                    //while ((data = stream.ReadByte()) != -1)
                    //{
                    //  test++;
                    //    if (test % 10000 == 0)
                    //    {
                    //        // WorkerCB.ReportProgress((int)(test * 100 / total));
                    //    }
                    //}
                }
            }
            catch
            {
                throw new Exception("Error during deserializing");
            }
        }
    }
}
