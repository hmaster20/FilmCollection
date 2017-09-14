using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    public class Sources
    {
        public Sources(int _id, string _source)
        {
            id = _id;
            source = _source;
        }

        //public int Id { get => id; set => id = value; }
        private int id;
        public int Id { get => id; }

        private string source { get; set; }
        public string Source { get => source; }
    }
}
