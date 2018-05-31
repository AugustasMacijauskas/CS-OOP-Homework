using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2
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

        public static bool operator <=(Krepsininkas k1, Krepsininkas k2)
        {
            int p = String.Compare(k1.VP, k2.VP, StringComparison.CurrentCulture);

            return ((k1.Amžius < k2.Amžius) || (k1.Amžius == k2.Amžius && p < 0));
        }

        public static bool operator >=(Krepsininkas k1, Krepsininkas k2)
        {
            int p = String.Compare(k1.VP, k2.VP, StringComparison.CurrentCulture);

            return ((k1.Amžius > k2.Amžius) || (k1.Amžius == k2.Amžius && p > 0));
        }

        public static bool operator ==(Krepsininkas k1, Krepsininkas k2)
        {
            int p = String.Compare(k1.VP, k2.VP, StringComparison.CurrentCulture);

            return (p == 0 && k1.Amžius == k2.Amžius && k1.Ūgis == k2.Ūgis);
        }

        public static bool operator !=(Krepsininkas k1, Krepsininkas k2)
        {
            int p = String.Compare(k1.VP, k2.VP, StringComparison.CurrentCulture);

            return (p != 0 || k1.Amžius != k2.Amžius || k1.Ūgis != k2.Ūgis);
        }
    }
}
