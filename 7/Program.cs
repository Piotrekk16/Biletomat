using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication70
{
    enum RodzajBiletu { N, U }
    class Program
    {  
        static void Main(string[] args)
        {
            Console.WriteLine(RodzajBiletu.N);
            BiletA bilet = new BiletA();
            bilet.ObliczCene(RodzajBiletu.N);
            bilet.ObliczCene(RodzajBiletu.U);
            BiletK bilet1 = new BiletK(50);
            bilet1.ObliczCene(RodzajBiletu.N);
            BiletK bilet2 = new BiletK(120);
            bilet2.ObliczCene(RodzajBiletu.U);
            Console.WriteLine("Dzien dobry");
            Console.WriteLine("Określ rodzaj biletu");
  //          Console.WriteLine("A-autobusowe",)






            Console.ReadKey();

        }
    }
}
