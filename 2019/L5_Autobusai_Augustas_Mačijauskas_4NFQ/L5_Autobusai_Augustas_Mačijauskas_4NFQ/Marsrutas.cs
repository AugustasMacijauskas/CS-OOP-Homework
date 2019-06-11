using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5_Autobusai_Augustas_Mačijauskas_4NFQ
{
    class Marsrutas
    {
        public int MarsrutoNumeris { get; private set; }
        public SavaitesDienos SavaitesDiena { get; private set; }
        public DateTime IsvykimoLaikas { get; private set; }
        public double Kaina { get; private set; }

        public Marsrutas(int nr = -1, SavaitesDienos diena = SavaitesDienos.Undefined, DateTime laikas = default(DateTime), double kaina = 0.0)
        {
            this.MarsrutoNumeris = nr;
            this.SavaitesDiena = diena;
            this.IsvykimoLaikas = laikas;
            this.Kaina = kaina;
        }

        public override string ToString()
        {
            return string.Format($" {MarsrutoNumeris,4} {SavaitesDiena, -20} {IsvykimoLaikas:HH:mm}{"", -15} {Kaina, 7:f2}");
        }

        public static readonly string Divider = "--------------------------------------------------------";

        public static readonly string Header = Divider + "\r\n" +
                                              $" {"Nr.",4} {"Savaitės diena",-20} {"Išvykimo laikas",-20} {"Kaina",7}\r\n" +
                                               Divider;
    }
}
