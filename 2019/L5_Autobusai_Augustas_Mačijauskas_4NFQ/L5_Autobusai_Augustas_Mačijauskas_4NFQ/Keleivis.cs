using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Autobusai_Augustas_Mačijauskas_4NFQ
{
    class Keleivis
    {
        public string Pavarde { get; private set; }
        public string Vardas { get; private set; }
        public SavaitesDienos SavaitesDiena { get; private set; }
        public DateTime IsvykimoLaikas { get; private set; }
        public int MarsrutoNumeris { get; private set; }

        public Keleivis(string p = "", string v = "", SavaitesDienos diena = SavaitesDienos.Undefined, DateTime laikas = default(DateTime), int nr = -1)
        {
            this.Pavarde = p;
            this.Vardas = v;
            this.SavaitesDiena = diena;
            this.IsvykimoLaikas = laikas;
            this.MarsrutoNumeris = nr;
        }

        public override string ToString()
        {
            return string.Format($" {Pavarde,-15} {Vardas,-15} {SavaitesDiena,-20} {IsvykimoLaikas:HH:mm}{"",-15} {MarsrutoNumeris,4}");
        }

        public static readonly string Divider = "--------------------------------------------------------------------------------";

        public static readonly string Header = Divider + "\r\n" +
                                              $" {"Pavardė",-15} {"Vardas",-15} {"Savaitės diena",-20} {"Išvykimo laikas",-20} {"Nr.",4}\r\n" +
                                               Divider;
    }
}
