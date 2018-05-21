using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KiekKokiuRaidziu
{
    class Raides
    {
        //private Dictionary<char, int> r;
        private List<KeyValuePair<char, int>> r;
        static string abc = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž";
        static string ABCD = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
        public string eil { get; set; }

        public Raides()
        {
            eil = "";
            //r = new Dictionary<char, int>();
            r = new List<KeyValuePair<char, int>>();
            for (int i = 0; i < abc.Length; i++)
            {
                //r.Add(new KeyValuePair<char, int>(abc[i], 0));
                //r.Add(abc[i], 0);
                //r.Add(ABCD[i], 0);
                r.Add(new KeyValuePair<char, int>(abc[i], 0));
                r.Add(new KeyValuePair<char, int>(ABCD[i], 0));
            }
        }

        public int Imti(char sim)
        {
            //return r[sim];
            return r.Find(x => x.Key == sim).Value;
        }

        public void Kiek()
        {
            for (int i = 0; i < eil.Length; i++)
            {
                if (('a' <= eil[i] && eil[i] <= 'ž') || ('A' <= eil[i] && eil[i] <= 'Ž'))
                {
                    int bam = r.Find(x => x.Key == eil[i]).Value;
                    r.Remove(new KeyValuePair<char, int>(eil[i], r.Find(x => x.Key == eil[i]).Value));
                    r.Add(new KeyValuePair<char, int>(eil[i], bam + 1));
                }
            }
        }

        public void Spausdinti()
        {
            r = r.OrderByDescending(key => key.Value).ToList();
            for (int i = 0; i < r.Count / 2; i++)
                Console.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", r[i].Key, r[i].Value, r[i + 32].Key, r[i + 32].Value);

            //foreach (KeyValuePair<char, int> pora in r.OrderByDescending(key => key.Value))
            //{
            //    Console.WriteLine("{0} {1}", pora.Key, pora.Value);
            //}
        }
    }

    class Program
    {
        const string duom = "..\\..\\duom.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1257);

            Raides eil = new Raides();
            SkaitymasIrDazniuSkaiciavimas(duom, eil);
            eil.Spausdinti();
        }

        static void SkaitymasIrDazniuSkaiciavimas(string duom, Raides eil)
        {
            using (StreamReader reader = new StreamReader(duom))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.Kiek();
                }
            }
        }
    }
}
