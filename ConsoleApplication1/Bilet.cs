using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Bilet
    {
        protected double cena;
        abstract public void ObliczCene(RodzajBiletu rodzaj);

        public Bilet() { }

        public double PodajCene()
        {
            return cena;
        }

        abstract public void Drukuj();
    }
}