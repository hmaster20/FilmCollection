using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Windows;
using System.Windows.Forms;

namespace FilmCollection
{
   static class BinSerializeHelper
    {


        // Convert an object to a byte array
        public static bool SerializeAndSaveToByte(Object obj)
        {
            try
            {
                ObjectToByteArray(obj);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }



        public static bool SerializeAndSave(object objectToSerialize)
        {
            try
            {
                string file = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Films.dat");

                BinaryFormatter formatter = new BinaryFormatter();                   // создаем объект BinaryFormatter                
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))  // получаем поток, куда будем записывать сериализованный объект
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
            //BinaryFormatter binFormat = new BinaryFormatter();
            // Прочитать JamesBondCar из двоичного файла.
            using (Stream fStream = File.OpenRead(fileName))
            {
                //J carFromDisk = (J)binFormat.Deserialize(fStream);
            }
        }





        // Convert an object to a byte array
        public static byte[] ObjectToByteArrays(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        // Convert a byte array to an Object
        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }



        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }



        private static byte[] arrBytes;

        public static void test()
        {
            //You can use:
            File.WriteAllBytes("Foo.txt", arrBytes); // Requires System.IO
            //If you have an enumerable and not an array, you can use:
            //File.WriteAllBytes("Foo.txt", arrBytes.ToArray()); // Requires System.Linq
        }











    }



    public class MyClass
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] Serialize()
        {
            using (MemoryStream m = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(m))
                {
                    writer.Write(Id);
                    writer.Write(Name);
                }
                return m.ToArray();
            }
        }

        public static MyClass Desserialize(byte[] data)
        {
            MyClass result = new MyClass();
            using (MemoryStream m = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(m))
                {
                    result.Id = reader.ReadInt32();
                    result.Name = reader.ReadString();
                }
            }
            return result;
        }

    }
}



