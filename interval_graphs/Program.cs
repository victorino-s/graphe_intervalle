using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interval_graphs
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Sommet> visiteurs = new List<Sommet>();
            List<Arc> rencontres = new List<Arc>();
            Graphe myGraphe = new Graphe();
            /* --- Graph Dunsmore ---*/
            /*
            Sommet anne = new Sommet("Anne", myGraphe);
            Sommet betty = new Sommet("Betty", myGraphe);
            Sommet cynthia = new Sommet("Cynthia", myGraphe);
            Sommet diana = new Sommet("Diana", myGraphe);
            Sommet emily = new Sommet("Emily", myGraphe);
            Sommet felicia = new Sommet("Felicia", myGraphe);
            Sommet georgia = new Sommet("Georgia", myGraphe);
            Sommet helen = new Sommet("Helen", myGraphe);

            anne.AddArcs(felicia, emily, cynthia, betty, georgia);
            betty.AddArcs(anne, helen, cynthia);
            cynthia.AddArcs(anne, betty, helen, diana, emily);
            diana.AddArcs(emily, cynthia);
            emily.AddArcs(felicia, anne, cynthia, diana);
            felicia.AddArcs(anne, emily);
            georgia.AddArcs(anne, helen);
            helen.AddArcs(georgia, betty, cynthia);
            

            visiteurs.Add(anne);
            visiteurs.Add(betty);
            visiteurs.Add(cynthia);
            visiteurs.Add(diana);
            visiteurs.Add(emily);
            visiteurs.Add(felicia);
            visiteurs.Add(georgia);
            visiteurs.Add(helen);
            */

            /* --- Graphe d'Intervalle ---*/
            /*
            Sommet A = new Sommet("A", myGraphe);
            Sommet B = new Sommet("B", myGraphe);
            Sommet C = new Sommet("C", myGraphe);
            Sommet D = new Sommet("D", myGraphe);
            Sommet E = new Sommet("E", myGraphe);
            Sommet F = new Sommet("F", myGraphe);
            Sommet G = new Sommet("G", myGraphe);
            

            A.AddArc(B);
            B.AddArcs(A, D, E, C);
            C.AddArcs(B, E, G);
            D.AddArcs(B, E, F);
            E.AddArcs(D, F, G, C, B);
            F.AddArcs(D, G, E);
            G.AddArcs(F, C, E);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            visiteurs.Add(E);
            visiteurs.Add(F);
            visiteurs.Add(G);
            */

            /* --- Graphe d'Intervalle 2 --- */
            /*
            Sommet A = new Sommet("A", myGraphe);
            Sommet B = new Sommet("B", myGraphe);
            Sommet C = new Sommet("C", myGraphe);
            Sommet D = new Sommet("D", myGraphe);
            Sommet E = new Sommet("E", myGraphe);
            Sommet F = new Sommet("F", myGraphe);
            Sommet G = new Sommet("G", myGraphe);


            A.AddArcs(B, C, D);
            B.AddArcs(A, C);
            C.AddArcs(B, A, D, F, E);
            D.AddArcs(A, C, F, E);
            E.AddArcs(C, D);
            F.AddArcs(D, C, G);
            G.AddArcs(F);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            visiteurs.Add(E);
            visiteurs.Add(F);
            visiteurs.Add(G);*/
            /* Graph non simplicial : exception carré */
            
            /*
             Sommet A = new Sommet("A", myGraphe);
             Sommet B = new Sommet("B", myGraphe);
             Sommet C = new Sommet("C", myGraphe);
             Sommet D = new Sommet("D", myGraphe);

             A.AddArcs(B, C);
             B.AddArcs(A, D);
             C.AddArcs(A, D);
             D.AddArcs(B, C);

             visiteurs.Add(A);
             visiteurs.Add(B);
             visiteurs.Add(C);
             visiteurs.Add(D);
             */
             

            /* Graph non simplicial : exception hexagone */
            
            Sommet A = new Sommet("A", myGraphe);
            Sommet B = new Sommet("B", myGraphe);
            Sommet C = new Sommet("C", myGraphe);
            Sommet D = new Sommet("D", myGraphe);
            Sommet E = new Sommet("E", myGraphe);
            Sommet F = new Sommet("F", myGraphe);

            A.AddArcs(B, F);
            B.AddArcs(A, F, D, C);
            C.AddArcs(B, D);
            D.AddArcs(C, B, F, E);
            E.AddArcs(D, F);
            F.AddArcs(E, A, B, D);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            visiteurs.Add(E);
            visiteurs.Add(F);
            



            /* --- Program Start ---*/
            List<Sommet> simpliciaux = new List<Sommet>();
            List<Sommet> non_simpliciaux = new List<Sommet>();
            /*
            foreach (Sommet s in visiteurs)
            {
                if(s.IsSimplicial())
                {
                    simpliciaux.Add(s);
                } else
                {
                    non_simpliciaux.Add(s);
                }
            }
            
            if(simpliciaux.Count == visiteurs.Count)
            {
                Console.WriteLine("Graphe Simplicial");
            }
            else
            {
                Console.WriteLine("Graphe Non Simplicial");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Sommet simpliciaux : ");
            foreach(Sommet s in simpliciaux)
            {
                Console.WriteLine(s.Name);
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Sommet non simpliciaux : ");
            foreach (Sommet s in non_simpliciaux)
            {
                Console.WriteLine(s.Name);
            }
            */
            int maxLinks = 0;
            int aloneElements = 0;
            foreach(Sommet s in visiteurs)
            {
                if(s.Degre > maxLinks)
                {
                    maxLinks = s.Degre;
                }

                if(s.Degre == 1)
                {
                    aloneElements += 1;
                }
            }

            if (maxLinks == visiteurs.Count - 1 - aloneElements)
            {
                foreach (Sommet s in visiteurs)
                {
                    s.CheckNeighbors();
                }


                if (myGraphe.failedSommets.Count <= 0)
                {
                    Console.WriteLine("Graphe de type Graphe d intervalle");
                }
                else
                {
                    Console.WriteLine("Graphe pas de type intervalle");
                }
            }
            else
            {
                Console.WriteLine("Graphe pas de type intervalle");
            }
            
            Console.ReadLine();
        }
    }

}
