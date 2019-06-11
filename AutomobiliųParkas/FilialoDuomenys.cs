using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    class FilialoDuomenys
    {
        private string miestoPavadinimas;
        private string adresas;
        private string elPastas;

        public FilialoDuomenys(string miestas, string adresas, string pastas)
        {
            this.miestoPavadinimas = miestas;
            this.adresas = adresas;
            this.elPastas = pastas;
        }

        public override string ToString()
        {
            return $"{miestoPavadinimas}\n{adresas}\n{elPastas}\n";
        }
    }
}
