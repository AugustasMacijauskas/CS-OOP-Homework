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
    }
}
