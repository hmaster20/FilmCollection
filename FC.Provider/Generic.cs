using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Provider
{
    /// <summary>Класс формирующий информацию о файле базы</summary>
    public static class Generic
    {
        /// <summary>Файл базы коллекции по умолчанию "VideoList.xml"</summary>
        private static string baseName = "VideoList.xml";

        public static void SetBaseName(string name)
        {
            //if (string.IsNullOrWhiteSpace(name))
            //    baseName = "Unknown";
            //else
            //    baseName = name;

            if (!string.IsNullOrWhiteSpace(name))
            {
                baseName = name;
            }
        }

        /// <summary>Метод извлекает имя базы</summary>
        public static string GetBaseName()
        {
            return baseName;
        }
    }
}
