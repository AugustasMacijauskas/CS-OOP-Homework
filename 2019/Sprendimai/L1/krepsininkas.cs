using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Krepsininkas
    {
        public string VP { get; set; }
        public int Amžius { get; set; }
        public double Ūgis { get; set; }

        public Krepsininkas(string vrdpav, int amz, double ug)
        {
            VP = vrdpav;
            Amžius = amz;
            Ūgis = ug;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format(" {0, -20}    {1, 2}     {2, 5:f}", VP, Amžius, Ūgis);
            return eilute;
        }

        public static bool operator<=(Krepsininkas k1, Krepsininkas k2)
        {
            return k1.Amžius < k2.Amžius;
        }

        public static bool operator>=(Krepsininkas k1, Krepsininkas k2)
        {
            return k1.Amžius > k2.Amžius;
        }
    }
}
