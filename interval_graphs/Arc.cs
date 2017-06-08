using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interval_graphs
{
    public class Arc
    {
        Sommet depart;
        Sommet arrive;

        public Sommet SommetDepart
        {
            get { return this.depart; }
            private set { this.depart = value; }
        }

        public Sommet SommetArrive
        {
            get { return this.arrive; }
            private set { this.arrive = value; }
        }


        public Arc(Sommet a, Sommet b)
        {
            SommetDepart = a;
            SommetArrive = b;
        }
    }
}

