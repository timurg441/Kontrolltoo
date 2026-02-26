using System;

namespace Kontrolltöö
{
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
                Console.WriteLine("4 - Palgaarvestus");
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

                    case "4":
                        Console.Write("Sisesta brutopalk: ");
                        if (double.TryParse(Console.ReadLine(), out double brutopalk))
                        {
                            var palk = Alamfunktsioonid.ArvutaPalk(brutopalk);
                            Console.WriteLine($"Maksuvaba tulu: {palk.Item1:F2} €");
                            Console.WriteLine($"Netopalk: {palk.Item2:F2} €");
                        }
                        else
                        {
                            Console.WriteLine("Vigane sisend!");
                        }
                        break;

                    case "0":
                        töötab = false;
                        Console.WriteLine("Programm lõpetas töö.");
                        break;

                    default:
                        Console.WriteLine("Vale valik!");
                        break;
                }
            }
        }
    }
}