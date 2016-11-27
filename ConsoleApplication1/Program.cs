using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum RodzajBiletu { N, U }

    class Program
    {
        static void Main(string[] args)
        {
            //kod do usunięcie, po to mamy stworzoną klase aplikacja na wywołania

            Aplikacja nowe = new Aplikacja();
            nowe.WczytajKlawisz1();
            
            Console.WriteLine("Do widzenia!");
            Console.ReadKey();






        }
    }
}