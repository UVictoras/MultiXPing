using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Utilitaries
{
    class Parser
    {
        public static void CSVParser(string fileName)
        {
            StreamReader csv = new StreamReader(fileName);

            string line = csv.ReadLine();
        }
    }
}
