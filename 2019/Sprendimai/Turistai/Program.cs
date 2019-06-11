using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    class Turistai
    {
        int litai;
        int centai;

        public Turistai(int litai, int centai) {
            this.litai = litai;
            this.centai = centai;
        }

        public int kiekLitu() { return litai; }

        public int kiekCentu() { return centai;  }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding UTF8;
            const int maxDuom = 100;
            const string Duom = "...\\...\\Duom.txt";

            int n;

            Turistai[] turistai = new Turistai[maxDuom];

            skaitymas(Duom, turistai, out n);
            Console.WriteLine(n);
            Console.WriteLine("Programa baigė darbą");

        }

        static void skaitymas(string duom, Turistai[] turistai, out int n) {
            int litai, centai;

            using (StreamReader reader = new StreamReader(duom)) {
                string line;
                string[] skaidymas;
                line = reader.ReadLine();
                n = int.Parse(line);
                
                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    skaidymas = line.Split(' ');
                    litai = int.Parse(skaidymas[0]);
                    centai = int.Parse(skaidymas[1]);
                    turistai[i] = new Turistai(litai, centai);
                } 
            }

        }
    }
}
