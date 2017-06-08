using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interval_graphs
{
    public class Sommet
    {
        private Graphe _graph;
        private List<Arc> _arcs = new List<Arc>();

        private List<Sommet> _voisins = new List<Sommet>();

        string name;

        private int degre = 0;

        public int Degre
        {
            get
            {
                if (this.degre == 0)
                {
                    this.degre = _voisins.Count;
                }
                return this.degre;
            }
            private set
            {
                this.degre = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public List<Arc> GetArcs
        {
            get { return this._arcs; }
        }

        public List<Sommet> GetVoisins
        {
            get { return this._voisins; }
        }

        public void AddArc(Sommet destination)
        {
            _arcs.Add(new Arc(this, destination));
            _voisins.Add(_arcs[_arcs.Count - 1].SommetArrive);
        }

        public void AddArcs(params Sommet[] liaisons)
        {
            foreach (Sommet s in liaisons)
            {
                _arcs.Add(new Arc(this, s));
                _voisins.Add(_arcs[_arcs.Count - 1].SommetArrive);
            }
        }

        public Arc GetArc(int index)
        {
            return this._arcs[index];
        }

        public Sommet()
        {
            this.name = "Default";
        }

        public Sommet(string name)
        {
            this.name = name;
        }

        public Sommet(string name, Graphe graph)
        {
            this.name = name;
            this._graph = graph;
        }

        /*
        public bool IsWayExisting(Sommet b)
        {
            return _voisins.Exists(s => s.Name == b.Name);
        }

        public bool IsOneOfNeightborsConnectedToParent(Sommet parent)
        {
            foreach(Sommet v in GetVoisins)
            {
                if (v.GetVoisins.Exists(s => s.Name == parent.Name))
                    return true;
            }
            return false;
        }


        List<bool> connectedNeightborsResults = new List<bool>(); 
        public bool AreMyNeightborsConnectedToEachOthers()
        {
            foreach(Sommet s in GetVoisins)
            {
                if (s.IsConnectedToOneOfThem(GetVoisins))
                    connectedNeightborsResults.Add(true);
                else
                    connectedNeightborsResults.Add(false);
            }

            if (connectedNeightborsResults.Exists(b => b == false))
                return false;
            else
                return true;
        }

        public bool IsConnectedToOneOfThem(List<Sommet> sommets)
        {
            foreach(Sommet s in sommets)
            {
                if (GetVoisins.Exists(t => t.Name == s.Name))
                    return true;
            }
            return false;
        }*/

        public bool IsConnectedToAll(List<Sommet> voisins)
        {
            List<Sommet> temp = new List<Sommet>(voisins);
            temp.Remove(this);

            foreach (Sommet s in temp)
            {
                if (!GetVoisins.Contains(s))
                {
                    return false;
                }
            }
            return true;
        }
        //
        public List<Sommet> validSommet = new List<Sommet>();
        /*

        public bool IsSimplicial()
        {

            foreach (Sommet s in GetVoisins)
            {
                // Get les sommets communs a this et (current) s
                var connectedSommets = from pNeighbor in GetVoisins join cNeighbor in s.GetVoisins on pNeighbor.Name equals cNeighbor.Name select cNeighbor;
                //var items = GetVoisins.Where(p => s.GetVoisins.Any(p2 => p2.Name == p.Name));

                if (connectedSommets != null && connectedSommets.Count() > 0)
                {
                    validSommet.Add(s);
                }
            }

            if (validSommet.Count == GetVoisins.Count)
                return true;

            return false;
        }*/

        public void CheckNeighbors()
        {

            foreach (Sommet s in GetVoisins)
            {
                if (s.Degre == 1) { Degre -= 1; }
                if (Degre > 1)
                {
                    if (s.Degre > 1)
                    {
                        var commonNeighbors = s.GetVoisins.Intersect(GetVoisins);
                        if (commonNeighbors.Count() < 1)
                        {
                            _graph.failedSommets.Add(this);
                        }
                    }
                }
                /*
                else if (Degre >= 4)
                {
                    if (s.Degre > 1)
                    {
                        var commonNeighbors = s.GetVoisins.Intersect(GetVoisins);
                        if (commonNeighbors.Count() < 2)
                        {
                            _graph.failedSommets.Add(this);
                        }
                    }
                }*/
                else
                {
                    return;
                }


            }
        }


    }
}
