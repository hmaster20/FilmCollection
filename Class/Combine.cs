// Класс для объединения Media (информации о фильме)  и Record (самого фала виедо)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    class Combine
    {
        public Combine()
        {
            Record = new List<Record>();
        }

        public Media _Media { get; set; }
        public List<Record> Record { get; set; }



        public string FileName { get { return "test"; } }

        public string Name { get { return _Media.Name; } }
     



    }
}
