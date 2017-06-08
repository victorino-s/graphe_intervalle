using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interval_graphs
{
    public class Graphe
    {
        public List<Sommet> sommets = new List<Sommet>();
        public List<Sommet> failedSommets = new List<Sommet>();
        public List<Sommet> validSommets = new List<Sommet>();
    }
}
