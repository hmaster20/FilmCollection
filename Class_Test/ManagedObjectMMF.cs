using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Text;

namespace ManagedMMF
{
    public class Program
    {
       public static void MAIN_()
        {
            // Build a sample object and report records
            HDatabase hData = BuildDatabase(500, 50);
            Console.WriteLine("Dummy database object created with " + hData.hikes.Length + " records.");

            // Write object to MMF
            WriteObjectToMMF("C:\\TEMP\\TEST.MMF", hData);

            // Clear object and report
            hData = null;
            Console.WriteLine("Database object has been destroyed.");

            // Read new object from MMF and report records
            hData = ReadObjectFromMMF("C:\\TEMP\\TEST.MMF") as HDatabase;
            Console.WriteLine("Dummy database object re-loaded from MMF with " + hData.hikes.Length + " records.");

            // Wait for input and terminate
            Console.ReadLine();
        }

        #region Generic MMF read/write object functions

        static void WriteObjectToMMF(string mmfFile, object objectData)
        {
            // Convert .NET object to byte array
            byte[] buffer = ObjectToByteArray(objectData);

            // Create a new memory mapped file
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(mmfFile, FileMode.Create, null, buffer.Length))
            {
                // Create a view accessor into the file to accommmodate binary data size
                using (MemoryMappedViewAccessor mmfWriter = mmf.CreateViewAccessor(0, buffer.Length))
                {
                    // Write the data
                    mmfWriter.WriteArray<byte>(0, buffer, 0, buffer.Length);
                }
            }
        }

        static object ReadObjectFromMMF(string mmfFile)
        {
            // Get a handle to an existing memory mapped file
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(mmfFile, FileMode.Open))
            {
                // Create a view accessor from which to read the data
                using (MemoryMappedViewAccessor mmfReader = mmf.CreateViewAccessor())
                {
                    // Create a data buffer and read entire MMF view into buffer
                    byte[] buffer = new byte[mmfReader.Capacity];
                    mmfReader.ReadArray<byte>(0, buffer, 0, buffer.Length);

                    // Convert the buffer to a .NET object
                    return ByteArrayToObject(buffer);
                }
            }
        }

        #endregion

        #region Object/Binary serialization

        static object ByteArrayToObject(byte[] buffer)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();    // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream(buffer);       // Convert byte array to memory stream, set position to start
            return binaryFormatter.Deserialize(memoryStream);           // Deserializes memory stream into an object and return
        }

        static byte[] ObjectToByteArray(object inputObject)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();    // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream();             // Create target memory stream
            binaryFormatter.Serialize(memoryStream, inputObject);       // Convert object to memory stream
            return memoryStream.ToArray();                              // Return memory stream as byte array
        }

        #endregion

        static HDatabase BuildDatabase(int recordCount, int gpsCoordCount)
        {
            Random rand = new Random();

            HDatabase hData = new HDatabase();
            hData.Description = "My hikes, 2010 to 2012";
            hData.hikes = new Hike[recordCount];
            for (int i = 0; i < hData.hikes.Length; i++)
            {
                hData.hikes[i] = new Hike();
                hData.hikes[i].Description = "This is a description of this particular record. ";
                hData.hikes[i].Date = DateTime.Now.ToLongDateString();
                hData.hikes[i].GPSTrack = new Coord[gpsCoordCount];
                for (int j = 0; j < hData.hikes[i].GPSTrack.Length; j++)
                {
                    hData.hikes[i].GPSTrack[j] = new Coord();
                    hData.hikes[i].GPSTrack[j].x = rand.NextDouble() * 1000000;
                    hData.hikes[i].GPSTrack[j].y = rand.NextDouble() * 1000000;
                    hData.hikes[i].GPSTrack[j].z = rand.NextDouble() * 1000;
                }
            }
            return hData;
        }
    }

    #region Sample object for I/O

    [Serializable]
    public class HDatabase
    {
        public string Description;
        public Hike[] hikes;
    }

    [Serializable]
    public class Hike
    {
        public string Description;
        public string Date;
        public Coord[] GPSTrack;
    }

    [Serializable]
    public class Coord
    {
        public double x;
        public double y;
        public double z;
    }

    #endregion

}
