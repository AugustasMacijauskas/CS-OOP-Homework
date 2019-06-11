using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mokinys
{

    class Mokinys
    {
        string vardas;
        string pavarde;
        bool arVyras;
        int amzius;
        string klase;
        double pazVidurkis;

        public Mokinys()
        {

        }

        public Mokinys(string v, string pv, bool arVyras, int amzius, string kl, double pazV)
        {
            vardas = v;
            pavarde = pv;
            this.arVyras = arVyras;
            this.amzius = amzius;
            klase = kl;
            pazVidurkis = pazV;
        }

        public static bool operator <=(Mokinys m1, Mokinys m2)
        {
            int poz1 = String.Compare(m1.pavarde, m2.pavarde, StringComparison.CurrentCulture);
            int poz2 = String.Compare(m1.vardas, m2.vardas, StringComparison.CurrentCulture);

            return ((m1.pazVidurkis > m2.pazVidurkis) || (m1.pazVidurkis == m2.pazVidurkis && poz1 > 0) || (m1.pazVidurkis == m2.pazVidurkis && poz1 == 0 && poz2 > 0));
        }

        public static bool operator >=(Mokinys m1, Mokinys m2)
        {
            int poz1 = String.Compare(m1.pavarde, m2.pavarde, StringComparison.CurrentCulture);
            int poz2 = String.Compare(m1.vardas, m2.vardas, StringComparison.CurrentCulture);

            return ((m1.pazVidurkis < m2.pazVidurkis) || (m1.pazVidurkis == m2.pazVidurkis && poz1 < 0) || (m1.pazVidurkis == m2.pazVidurkis && poz1 == 0 && poz2 < 0));
        }
    }

    class MokiniuKonteineris
    {
        const int max = 100;
        int n = 0;
        Mokinys[] mok;
        
        public MokiniuKonteineris()
        {
            mok = new Mokinys[max];
        }

        public int KoksMax() { return max; }

        public int Imti() { return n; }

        public void Deti(Mokinys ob) { mok[n++] = ob; }

        public Mokinys Imti(int k) { return mok[k]; }
    }

    class Program
    {

        const string duom = "..\\..\\Mokinys.txt";
        static void Main(string[] args)
        {
        }

        static void Skaityti()
        {

        }
    }
}
