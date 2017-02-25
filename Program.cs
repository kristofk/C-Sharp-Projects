using System;
using System.Collections.Generic;

namespace bodek
{
    class Program
    {
        const int bodekSzama = 10; // n*n-es táblára n darab bódé elhelyezése
        static List<int> taroltBodek = new List<int>(); // Itt vannak a bódék tárolva (index: sor, szám: oszlop)

        static bool vertikalisAtfedes(int oszlop)
        {
            return bodek.Contains(oszlop); //TRUE: van átfedés, FLASE: nincs átfedés
        }

        static bool atlosAtfedes(int sor, int oszlop)
        {
            for (int i = 0; i < bodek.Count; i++)
            {
                if (Math.Abs(sor - (i + 1)) == Math.Abs(oszlop - bodek[i]))
                {
                    return true; // Van átlós átfedés
                }
            }
            return false; // Nincs átlós átfedés
        }

        static bool ellenorzes(int sor, int oszlop)
        {
            if (vertikalisAtfedes(oszlop) || atlosAtfedes(sor, oszlop))
            {
                return false; // Talált átfedést
            }
            return true; // Nincs átfedés
        }

        static List<int> bodek = new List<int>();
        static bool elhelyezes(int sor)
        {
            if (sor > bodekSzama)
            {
                foreach (var bode in bodek)
                {
                    taroltBodek.Add(bode);
                }
                return true;
            }
            else
            {
                for (int i = 1; i <= bodekSzama; i++)
                {
                    if (ellenorzes(sor, i))
                    {
                        bodek.Add(i);
                        if (elhelyezes(sor + 1))
                        {
                            return true;
                        }
                        bodek.RemoveAt(bodek.Count - 1);
                    }
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            elhelyezes(1);
            Console.WriteLine(string.Join("\n", taroltBodek));

            Console.WriteLine("\n*END*");
            Console.ReadKey();
        }
    }
}
