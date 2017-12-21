using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FC.Provider
{
    /// <summary>Источник файлов (коллекции) - по сути путь к каталогу базы</summary>
    public class Sources
    {
        public int Id { get; set; }
        public string Source { get; set; }
    }
}