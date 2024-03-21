using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MultiXPing.source.Utilitaries
{
    class Parser
    {
        public static List<List<float>> CSVParser(string filePath)
        {
            List<List<float>> parsedData = new List<List<float>>();
            using (StreamReader csv = new StreamReader(filePath))
            {
                string line;
                while ((line = csv.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(",");
                    List<float> floatLine = new List<float>();

                    foreach (string numberStr in  splitLine)
                    {
                        if (float.TryParse(numberStr, NumberStyles.Float, CultureInfo.InvariantCulture, out float number)) 
                        {
                            floatLine.Add(number);
                        };
                    }
                    parsedData.Add(floatLine);
                }
            }
            return parsedData;
        }
    }
}
