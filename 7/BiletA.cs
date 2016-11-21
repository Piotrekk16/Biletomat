using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication70
{
    class BiletA:Bilet
    {
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (rodzaj==RodzajBiletu.N)
                base.cena=2.90;
            else
                base.cena=1.45;

            Console.WriteLine(String.Format("{0}", cena));
        }
    }
}
