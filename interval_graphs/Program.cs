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

            /* --- Graph Dunsmore ---*/
            /*
            Sommet anne = new Sommet("Anne");
            Sommet betty = new Sommet("Betty");
            Sommet cynthia = new Sommet("Cynthia");
            Sommet diana = new Sommet("Diana");
            Sommet emily = new Sommet("Emily");
            Sommet felicia = new Sommet("Felicia");
            Sommet georgia = new Sommet("Georgia");
            Sommet helen = new Sommet("Helen");

            anne.AddArc(felicia, emily, cynthia, betty, georgia);
            betty.AddArc(anne, helen, cynthia);
            cynthia.AddArc(anne, betty, helen, diana, emily);
            diana.AddArc(emily, cynthia);
            emily.AddArc(felicia, anne, cynthia, diana);
            felicia.AddArc(anne, emily);
            georgia.AddArc(anne, helen);
            helen.AddArc(georgia, betty, cynthia);
            

            visiteurs.Add(anne);
            visiteurs.Add(betty);
            visiteurs.Add(cynthia);
            visiteurs.Add(diana);
            visiteurs.Add(emily);
            visiteurs.Add(felicia);
            visiteurs.Add(georgia);
            visiteurs.Add(helen);
            */

            /* --- Graphe Simpliciel ---*/
            /*
            Sommet A = new Sommet("A");
            Sommet B = new Sommet("B");
            Sommet C = new Sommet("C");
            Sommet D = new Sommet("D");
            Sommet E = new Sommet("E");
            Sommet F = new Sommet("F");
            Sommet G = new Sommet("G");
            Sommet H = new Sommet("H");

            A.AddArc(B, C);
            B.AddArc(A, F, C, G, E);
            C.AddArc(A, B, D, E);
            D.AddArc(C, E);
            E.AddArc(D, C, B, G, H);
            F.AddArc(B, G);
            G.AddArc(F, B, E, H);
            H.AddArc(G, E);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            visiteurs.Add(E);
            visiteurs.Add(F);
            visiteurs.Add(G);
            visiteurs.Add(H);
            */

            /* Graph non simplicial : exception carré */
            
            /*
            Sommet A = new Sommet("A");
            Sommet B = new Sommet("B");
            Sommet C = new Sommet("C");
            Sommet D = new Sommet("D");

            A.AddArc(B, C);
            B.AddArc(A, D);
            C.AddArc(A, D);
            D.AddArc(B, C);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            
            */

            /* Graph non simplicial : exception hexagone */
            
            Sommet A = new Sommet("A");
            Sommet B = new Sommet("B");
            Sommet C = new Sommet("C");
            Sommet D = new Sommet("D");
            Sommet E = new Sommet("E");
            Sommet F = new Sommet("F");

            A.AddArc(B, F);
            B.AddArc(A, F, D, C);
            C.AddArc(B, D);
            D.AddArc(C, B, F, E);
            E.AddArc(D, F);
            F.AddArc(E, A, B, D);

            visiteurs.Add(A);
            visiteurs.Add(B);
            visiteurs.Add(C);
            visiteurs.Add(D);
            visiteurs.Add(E);
            visiteurs.Add(F);
            


            /* --- Program Start ---*/
            List<Sommet> simpliciaux = new List<Sommet>();
            List<Sommet> non_simpliciaux = new List<Sommet>();

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
            Console.ReadLine();
        }
    }

}
