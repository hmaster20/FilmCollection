using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FilmCollection
{   
    public class Record
    {
        public Record()
        {
            _FileRecord = new List<FileRecord>();
        }

        public Media _Media { get; set; }

        public List<FileRecord> _FileRecord { get; set; }

        public string FileName { get { return ""; } }








    }
}