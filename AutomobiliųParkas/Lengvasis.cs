using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliųParkas
{
    class Lengvasis : Transportas, IComparable<Lengvasis>
    {
        public double OdometroRodmenys { get; set; }

        public Lengvasis(string valstNr, string gam, string mod, DateTime pag, DateTime tech, string kur, double vid, double odom) : base(valstNr, gam, mod, pag, tech, kur, vid)
        {
            this.OdometroRodmenys = odom;
        }

        public override double PapildomasRodiklis()
        {
            return this.OdometroRodmenys;
        }

        public override string ToString()
        {
            return base.ToString() + $"{OdometroRodmenys}";
        }

        public int CompareTo(Lengvasis other)
        {
            return -OdometroRodmenys.CompareTo(other.OdometroRodmenys);
        }
    }
}
