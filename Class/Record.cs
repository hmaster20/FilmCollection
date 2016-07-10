using System;
using System.Collections.Generic;
using System.Text;

namespace FilmCollection
{
    public class Record
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _year = "";
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _type = "";
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _path = "";
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
