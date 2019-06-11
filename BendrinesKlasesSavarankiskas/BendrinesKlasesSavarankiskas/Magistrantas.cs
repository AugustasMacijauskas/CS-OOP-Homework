using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BendrinesKlasesSavarankiskas
{
    class Magistrantas : Studentas
    {
        public string Tema { get; set; }

        public Magistrantas() { }

        public Magistrantas(string var, string pav, string paz, double vid, string stat, string tema) : base(var, pav, paz, vid, stat) {
            this.Tema = tema;
        }
    }
}
