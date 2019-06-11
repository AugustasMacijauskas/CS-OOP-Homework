using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Studentai_GUI_List
{
    class Studentas
    {
        public string PavVrd { get; set; }
        public int Pazym { get; set; }
        public string Lytis { get; set; }

        public Studentas(string pavv, int pazym, string lytis)
        {
            PavVrd = pavv;
            Pazym = pazym;
            this.Lytis = lytis;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}     {1, 2}", PavVrd, Pazym);
            return eilute;
        }
    }
}
