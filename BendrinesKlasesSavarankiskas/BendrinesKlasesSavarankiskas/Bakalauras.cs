using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BendrinesKlasesSavarankiskas
{
    class Bakalauras : Studentas
    {
        public Bakalauras() { }

        public Bakalauras(string var, string pav, string paz, double vid, string stat) : base(var, pav, paz, vid, stat) { }
    }
}
