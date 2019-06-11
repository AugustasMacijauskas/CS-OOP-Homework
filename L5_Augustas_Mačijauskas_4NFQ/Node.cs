using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    sealed class Node
    {
        public Krepsininkas Duomenys { get; set; }
        public Node Next { get; set; }

        public Node (Krepsininkas duom, Node next)
        {
            this.Duomenys = duom;
            this.Next = next;
        }

        public override string ToString()
        {
            return Duomenys.ToString();
        }
    }
}
