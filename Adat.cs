using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    class Adat
    {
        //2018.03.06. 11 3 0
        //idopont, kártya sorszám, induló és célemelet  
        public DateTime Idopont { get; set; }
        public int KartyaSorszama { get; set; }
        public int Kezdoszint { get; set; }
        public int Celszint { get; set; }

        public Adat(string sor)
        {
            string[] s = sor.Split(' ');
            Idopont = DateTime.Parse(s[0]);
            KartyaSorszama = int.Parse(s[1]);
            Kezdoszint = int.Parse(s[2]);
            Celszint = int.Parse(s[3]);
        }
    }
}
