using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FilmCollection
{
    public static class XmlSerializeHelper
    {
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            try
            {
                using (FileStream stream = new FileStream(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), filename), FileMode.Create))
                    serializer.Serialize(stream, objectToSerialize);
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
                    // MessageBox.Show("Чтение потока. Финальная позиция: " + Convert.ToString(stream.Position) + ", длина потока: " + Convert.ToString(stream.Length));

                    //int data;
                    //long test = 0;
                    //long total = stream.Length;
                    //while ((data = stream.ReadByte()) != -1)
                    //{
                    //    test++;
                    //    if (test % 1000 == 0)
                    //    {
                    //        MessageBox.Show("Позиция : " + Convert.ToString(stream.Position) + ", Финальная позиция: " + Convert.ToString(stream.Length) + " dd:" + Convert.ToString(((int)(test * 100 / total))));
                    //    }

                    //}



                    return (T)serializer.Deserialize(stream);

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
            //catch
            //{
            //    throw new Exception("Error during deserializing");
            //}
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw new Exception("Error during deserializing");
            }
        }
    }
}
