using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class BiletA : Bilet
    {
        private RodzajBiletu rodzajBiletu;

        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (rodzaj == RodzajBiletu.N)
                base.cena = 2.90;
            else
                base.cena = 1.45;

           // Console.WriteLine(String.Format("{0}", cena)); - po co to?
        }

        public BiletA() { }

        public BiletA(RodzajBiletu rodzajBiletu)
        {
           
            this.rodzajBiletu = rodzajBiletu;
            
        }

        public override void Drukuj()
        {
            Directory.CreateDirectory("Autobus");
                        
            int licznikA=0;
            string nazwaA = @"Autobus\A" + licznikA + ".txt";
            while(File.Exists(nazwaA))
            {
                licznikA++;
                nazwaA = @"Autobus\A" + licznikA + ".txt";
            }

            using (StreamWriter sw = new StreamWriter(nazwaA))
            {
                string data = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();
                sw.WriteLine(data);
            }
        }


    }
}