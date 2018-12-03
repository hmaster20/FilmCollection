using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Provider
{
    public static class Generic
    {
        private static string baseName = "Unknown";

        public static void SetBaseName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                baseName = "Unknown";
            }
            else
            {
                baseName = name;
            }
        }

        public static string GetBaseName()
        {
            return baseName;
        }
    }
}
