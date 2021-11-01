using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("lift.txt");
            List<Adat> adatok = new List<Adat>();
            foreach (string  sor in sorok)
            {
                adatok.Add(new Adat(sor));
            }

            /* 3 hányszor használták a liftet?*/
            int adatokSzama = adatok.Count();
            Console.WriteLine($"3. feladat: {adatokSzama}-szor használták a liftet az időszakban");

            /* 4 írja ki, hogy a vizsgált időszak mettől-meddig tartott */
            
            Console.WriteLine($"4. feladat, a vizsgálat {adatok.First().Idopont.Year}.{adatok.First().Idopont.Month}." +
                $"{adatok.First().Idopont.Day} -től/tól " +
                $"{adatok.Last().Idopont.Year}.{adatok.Last().Idopont.Month}.{adatok.Last().Idopont.Day} -ig tartott");

            int emeletSzam = 0;
            /* 5 melyik emelet volt a legmagasabb amire mentek ebben az időszakban? */
            for (int i = 0; i < adatokSzama; i++)
            {
                
                if (emeletSzam < adatok[i].Celszint)
                {
                    emeletSzam = adatok[i].Celszint;
                }
            }
            Console.WriteLine($"5. feladat; a legnagyobb szint a vizsgált időszakban, a(z): {emeletSzam}");

            /* 6 - kérjen be egy kártya számot és egy célszintet
                 - szövegesként kérje be, majd konvertálja át numerikussá
                 - hiba esetén az 5-ös számú kártya, és 5-ös számú célszint legyen beállítva*/
            Console.WriteLine("Adj meg egy kártyaszámot: ");
            string kartyaszam = Console.ReadLine();

            Console.WriteLine("Adj meg egy célszintet: ");
            string celszint = Console.ReadLine();

            int kartya = 0;
            int celszintszama = 0;
            try
            {
                kartya = int.Parse(kartyaszam);
                celszintszama = int.Parse(celszint);
            }
            catch
            {
                 kartya = 5;
                 celszintszama = 5; 
            }
            Console.WriteLine($"6. feladat: \t\n kártya száma: {kartya} \t\n Célszint száma {celszintszama}");


            /* 7 */
            int k = 0;
            //bool benneVan = false;                //igaz, hogy ez nem igaz
            while (k < adatokSzama && !(adatok[k].Celszint == celszintszama)) //ha nem egyenlő akkor megy tovább
            {
                //ha egyenlő, akkor -> true while->> igaz ÉS nem igaz hogy NEM egyenlő
                k++;
                

            }
            Console.WriteLine("7. feladat: ");
            bool utaztak = k < adatokSzama; //vhol megált, mert talált olyat amire nem volt igaz
            if (utaztak)
            {
                Console.WriteLine($"A(z) {kartya} számú kártyával utaztak az {celszintszama}. emeletre");
            }
            else
            {
                Console.WriteLine($"A(z) {kartya} számú kártyával nem utaztak az {celszintszama}. emeletre");
            }


            Dictionary<string, int> lista = new Dictionary<string, int>();
            foreach (Adat adat in adatok)
            {
                string kulcs = adat.Idopont.Year.ToString();
                kulcs += $".0{adat.Idopont.Month.ToString()}";
                kulcs += $".{adat.Idopont.Day.ToString()}";
                
                if (lista.ContainsKey(kulcs))
                {
                    lista[kulcs]++;
                }
                else
                {
                    lista.Add(kulcs,1);
                }
            }
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Key} - {item.Value}x");
            }

            Console.ReadLine();
        }
    }
}
