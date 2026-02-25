using Kontrolltöö;
using System;

class StartPage
{
    static void Main(string[] args)
    {
        bool töötab = true;

        while (töötab)
        {
            Console.WriteLine("\nVali tegevus:");
            Console.WriteLine("1 - Kütuse kalkulaator");
            Console.WriteLine("2 - Isikukoodi analüüs");
            Console.WriteLine("3 - Täringumäng");
            Console.WriteLine("0 - Välju");

            Console.Write("Sinu valik: ");
            string valik = Console.ReadLine();

            switch (valik)
            {
                case "1":
                    Alamfunktsioonid.KytuseKalkulaator();
                    break;

                case "2":
                    Console.Write("Sisesta isikukood: ");
                    string ik = Console.ReadLine();
                    string tulemus = Alamfunktsioonid.HindaIsikukood(ik);
                    Console.WriteLine(tulemus);
                    break;

                case "3":
                    Alamfunktsioonid.TaringuMang();
                    break;

                case "0":
                    töötab = false;
                    break;

                default:
                    Console.WriteLine("Vale valik!");
                    break;
            }
        }
    }
}

