using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ConsoleApplication1
{
    class Aplikacja
    {
        private char klawisz1;
        private char klawisz2;
        private Bilet bilecik;

        public void WczytajKlawisz1()
        {
            Console.WriteLine("Określ rodzaj biletu");
            Console.WriteLine("A- autobusowe");
            Console.WriteLine("K - kolejowe");
            Console.WriteLine("E - koniec");
            klawisz1 = Convert.ToChar(Console.ReadLine());
            while( klawisz1 !='E' && klawisz1 !='e')
            {
                switch (klawisz1)
                {
                    case 'A':
                    case 'a':
                    case 'K':
                    case 'k':
                        {
                            WczytajKlawisz2();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("błędny klawisz! spróbuj jeszcze raz");
                            klawisz1 = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                }
            }       

        }

        public void WczytajKlawisz2()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("Z - Zakup biletu");
            Console.WriteLine("S - Sprawdzenie biletu");
            Console.WriteLine("X- koniec i powrót do początkowego menu");
            klawisz2 = Convert.ToChar(Console.ReadLine());
            while (klawisz2 != 'X' && klawisz2 != 'x')
            {
                switch (klawisz2)
                {
                    case 'Z':
                    case 'z':
                    case 'S':
                    case 's':
                        {
                            WykonajDzialanie();
                            Console.WriteLine("Co chcesz zrobić?");
                            Console.WriteLine("Z - Zakup biletu");
                            Console.WriteLine("S - Sprawdzenie biletu");
                            Console.WriteLine("X- koniec i powrót do początkowego menu");
                            klawisz2 = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("błędny klawisz! spróbuj jeszcze raz");
                            klawisz2 = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                }
                
            }
            WczytajKlawisz1();
            
        }

        public void WykonajDzialanie()
        {
            switch (klawisz2)
                {
                    case 'Z':
                    case 'z':
                        #region instrukcje
                        {
                            Console.WriteLine("Podaj rodzaj ulgi, N- normalny, U-ulgowy");
                            char klawisz3 = Convert.ToChar(Console.ReadLine());
                            if (klawisz3 == 'N' || klawisz3 =='n')
                            {
                                if (klawisz1 == 'A' || klawisz1 == 'a')
                                {
                                    bilecik = new BiletA();
                                    bilecik.ObliczCene(RodzajBiletu.N);
                                    Console.WriteLine("Zakupiono bilet normalny. Cena: {0}", bilecik.PodajCene());
                                    
                                }
                                if (klawisz1 == 'K' || klawisz1 == 'k')
                                {
                                    Console.WriteLine("Podaj dlugosc trasy");
                                    double odlg = Convert.ToDouble(Console.ReadLine());
                                    bilecik = new BiletK(odlg);
                                    bilecik.ObliczCene(RodzajBiletu.N);
                                    Console.WriteLine("Zakupiono bilet normalny. Cena: {0}", bilecik.PodajCene());

                                }
                            }
                            else if (klawisz3 == 'U' || klawisz3 == 'u')
                            {
                                if (klawisz1 == 'A' || klawisz1 == 'a')
                                {
                                    bilecik = new BiletA();
                                    bilecik.ObliczCene(RodzajBiletu.U);
                                    Console.WriteLine("Zakupiono bilet ulgowy. Cena: {0}", bilecik.PodajCene());
                                }
                                if (klawisz1 == 'K' || klawisz1 == 'k')
                                {
                                    Console.WriteLine("Podaj dlugosc trasy");
                                    double odl = Convert.ToDouble(Console.ReadLine());
                                    bilecik = new BiletK(odl);
                                    bilecik.ObliczCene(RodzajBiletu.U);
                                    Console.WriteLine("Zakupiono bilet ulgowy. Cena: {0}", bilecik.PodajCene());

                                }
                            }
                            bilecik.Drukuj();
                            break;

                        }
                        #endregion
                    case 's':
                    case 'S':
                        #region instrukcje sprawdzenia
                        {
                            SprawdzBilet();
                            break;
                        }
                        #endregion
                }
                   

        }

        private void SprawdzBilet()
        {
            Console.WriteLine("Podaj numer biletu");
            string nrBiletu = Console.ReadLine();
            string kod = nrBiletu.Substring(0, 1);
            string nazwaPliku="";
            if (kod == "A")
            {
                nazwaPliku = @"Autobus\" + nrBiletu + ".txt";
            }
            else if (kod == "K")
            {
                nazwaPliku = @"Kolej\" + nrBiletu + ".txt";
            }
            string kodBiletu = File.ReadAllText(nazwaPliku);
            Console.WriteLine("Kod biletu: {0}", kodBiletu);
            int dzien = Convert.ToInt32(kodBiletu.Substring(0, 2));
            int miesiac = Convert.ToInt32(kodBiletu.Substring(2, 2));
            int rok = Convert.ToInt32(kodBiletu.Substring(4, 4));
            int godzina = Convert.ToInt32(kodBiletu.Substring(8, 2));
            int minuty = Convert.ToInt32(kodBiletu.Substring(10, 2));
            int sekundy = Convert.ToInt32(kodBiletu.Substring(12, 2));
            double dlTrasy = Convert.ToDouble(kodBiletu.Substring(14,3));
            DateTime zakup = new DateTime(rok, miesiac, dzien, godzina, minuty, sekundy);

            if (kod == "A")
            {
                if (DateTime.Now.Subtract(zakup).TotalMinutes <= 30)
                {
                    Console.WriteLine("Bilet ważny");
                }
                else
                {
                    Console.WriteLine("Bilet nieważny");
                }
            }
            else if (kod == "K")
            {
                if (dlTrasy <=100)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 3)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
                else if (dlTrasy >100 && dlTrasy <=200)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 12)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
                else if (dlTrasy>100)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 24)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
            }
            
        }

        
        


    }
}