using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// 
    /// </summary>
    class Krepsininkai
    {
        const int Max = 500;
        private Krepsininkas[] Krep;
        public int Kiek { get; set; }

        public Krepsininkai()
        {
            Kiek = 0;
            Krep = new Krepsininkas[Max];
        }

        /// <summary>
        /// Grąžina atitinkamo indekso vietoje esantį krepšininko objektą;
        /// </summary>
        /// <returns>Krepsin</returns>
        public Krepsininkas ImtiKrepsininka(int i)
        {
            return Krep[i];
        }

        /// <summary>
        /// Papildo krepšininkų masyvą
        /// </summary>
        public void DetiStudenta(Krepsininkas ob)
        {
            Krep[Kiek++] = ob;
        }

        public void Rikiuoti()
        {
            for (int i = 0; i < Kiek - 1; i++)
            {
                Krepsininkas pagalb = Krep[i];
                int ind = i;
                for (int j = i + 1; j < Kiek; j++)
                {
                    if (Krep[j] <= pagalb)
                    {
                        pagalb = Krep[j];
                        ind = j;
                    }
                }
                Krep[ind] = Krep[i];
                Krep[i] = pagalb;
            }
        }

        public void Šalinti(int amz)
        {
            for (int i = 0; i < Kiek; i++)
            {
                if (Krep[i].Amžius > amz)
                {
                    for (int j = i; j < Kiek - 1; j++)
                    {
                        Krep[j] = Krep[j + 1];
                    }
                    Kiek--;
                    i--;
                }
            }
        }
    }
}
