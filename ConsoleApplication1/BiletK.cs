using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class BiletK : Bilet

    {
        private double dlugoscTrasy;
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            double cenaN;
            if (dlugoscTrasy <= 100)
                cenaN = dlugoscTrasy * 1.04;
            else
                cenaN = dlugoscTrasy * 0.73;
            if (rodzaj == RodzajBiletu.N)
                base.cena = Math.Round(cenaN,2); //zabezpieczenie na zaokrąglanie zgodnie z poleceniem
            else
                base.cena = Math.Round(cenaN / 2, 2); //zabezpieczenie na zaokrąglanie zgodnie z poleceniem

           // Console.WriteLine(String.Format("{0}", cena)); -po co to?

        }

        public BiletK(double odleglosc)
        {
            this.dlugoscTrasy = odleglosc;
        }

        public override void Drukuj()
        {
            Directory.CreateDirectory("Kolej");

            int licznikk = 0;
            string nazwaK = @"Kolej\K" + licznikk + ".txt";
            while (File.Exists(nazwaK))
            {
                licznikk++;
                nazwaK = @"Kolej\K" + licznikk + ".txt";
            }

            using (StreamWriter sw = new StreamWriter(nazwaK))
            {
                string data = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString()+dlugoscTrasy.ToString(); //uzupełniam kod biletu o dlugosc trasy
                sw.WriteLine(data);
            }


        }
    }
}
