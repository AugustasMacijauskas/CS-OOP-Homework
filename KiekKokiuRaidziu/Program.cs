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
        private Dictionary<char, int> r;
        //private List<KeyValuePair<char, int>> r;
        static string abc = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž";
        static string ABCD = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
        public string eil { get; set; }

        public Raides()
        {
            eil = "";
            r = new Dictionary<char, int>();
            for (int i = 0; i < abc.Length; i++)
            {
                //r.Add(new KeyValuePair<char, int>(abc[i], 0));
                r.Add(abc[i], 0);
                r.Add(ABCD[i], 0);
            }
        }

        public int Imti(char sim)
        {
            return r[sim];
            //return r.Find(x => x.Key == sim).Value;
        }

        public void Kiek()
        {
            for (int i = 0; i < eil.Length; i++)
            {
                if (('a' <= eil[i] && eil[i] <= 'ž') || ('A' <= eil[i] && eil[i] <= 'Ž'))
                    r[eil[i]]++;
            }
        }

        public void Spausdinti()
        {
            foreach (KeyValuePair<char, int> pora in r.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("{0} {1}", pora.Key, pora.Value);
            }
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
                while((line = reader.ReadLine()) != null)
                {
                    eil.eil = line;
                    eil.Kiek();
                }
            }
        }
    }
}

//foreach (char sim in abc)
//    Console.WriteLine(sim + " ");\

//foreach (char sim in abc)
//Console.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", sim, eil.Imti(sim), Char.ToUpper(sim), eil.Imti(Char.ToUpper(sim)));


//string abc = "abcdefgh...";
//List<char> abc = new List<char>() { 'a', 'ą', 'b', 'c', 'č', 'd', 'e', 'ę', 'ė', 'f', 'g', 'h', 'i', 'į', 'y', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 'š', 't', 'u', 'ų', 'ū', 'v', 'z', 'ž',
//                                    'A', 'Ą', 'B', 'C', 'Č', 'D', 'E', 'Ę', 'Ė', 'F', 'G', 'H', 'I', 'Į', 'Y', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'Š', 'T', 'U', 'Ų', 'Ū', 'V', 'Z', 'Ž'};

//static void Rikiuoti(Raides eil, List<char> abc)
//{

//    int maxInd;
//    char pag = ' ';

//    for (int i = 0; i < abc.Count - 1; i++)
//    {
//        maxInd = i;

//        for (int j = i + 1; j < abc.Count; j++)
//        {
//            if (eil.Imti(abc[i]) < eil.Imti(abc[j]))
//                maxInd = j;
//        }

//        pag = abc[i];
//        abc[i] = abc[maxInd];
//        abc[maxInd] = pag;
//    }
//}

//static void Spausdinti(Raides eil, List<char> abc)
//{
//    for (int i = 0; i < abc.Count / 2; i++)
//    {
//        Console.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", abc[i], eil.Imti(abc[i]), abc[i + 32], eil.Imti(abc[i + 32]));
//    }
//}

//public void Rikiuoti()
//{
//    r.OrderByDescending(x => x.Value);
//}