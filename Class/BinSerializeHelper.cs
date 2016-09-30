using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace FilmCollection
{
    class BinSerializeHelper
    {
        public static bool SerializeAndSave(string filename, object objectToSerialize)
        {
            try
            {
                // создаем объект BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream("Films.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, objectToSerialize);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Прочитать JamesBondCar из двоичного файла.
            using (Stream fStream = File.OpenRead(fileName))
            {
                //J carFromDisk = (J)binFormat.Deserialize(fStream);
            }
        }
    }
}



