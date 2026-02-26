using System;
using System.Collections.Generic;

namespace Kontrolltöö
{
    class Alamfunktsioonid
    {
        public static void KytuseKalkulaator()
        {
            Console.Write("Sisesta läbitud km: ");
            if (!double.TryParse(Console.ReadLine(), out double km))
            {
                Console.WriteLine("Vigane sisend!");
                return;
            }

            Console.Write("Sisesta kütusekulu (l/100km): ");
            if (!double.TryParse(Console.ReadLine(), out double kulu))
            {
                Console.WriteLine("Vigane sisend!");
                return;
            }

            Console.Write("Sisesta kütuse hind (€): ");
            if (!double.TryParse(Console.ReadLine(), out double hind))
            {
                Console.WriteLine("Vigane sisend!");
                return;
            }

            double kokkuKulu = (km / 100) * kulu;
            double maksumus = kokkuKulu * hind;

            Console.WriteLine($"Kokku kulus {kokkuKulu:F2} liitrit kütust.");
            Console.WriteLine($"Reisi maksumus on {maksumus:F2} eurot.");
        }

        public static string HindaIsikukood(string isikukood)
        {
            if (isikukood.Length != 11)
                return "Viga: Isikukood peab olema 11 märki pikk.";

            if (!long.TryParse(isikukood, out _))
                return "Viga: Isikukood peab sisaldama ainult numbreid.";

            char esimene = isikukood[0];

            string sugu;
            int sajand;

            if (esimene == '1' || esimene == '3' || esimene == '5')
                sugu = "Mees";
            else if (esimene == '2' || esimene == '4' || esimene == '6')
                sugu = "Naine";
            else
                sugu = "Tundmatu";

            if (esimene == '1' || esimene == '2')
                sajand = 1800;
            else if (esimene == '3' || esimene == '4')
                sajand = 1900;
            else if (esimene == '5' || esimene == '6')
                sajand = 2000;
            else
                sajand = 0;

            string aastaStr = isikukood.Substring(1, 2);
            string kuu = isikukood.Substring(3, 2);
            string paev = isikukood.Substring(5, 2);

            int aasta = sajand + int.Parse(aastaStr);

            return $"Oled {sugu}, sündinud {paev}.{kuu}.{aasta}";
        }

        public static void TaringuMang()
        {
            Random rnd = new Random();
            List<int> summad = new List<int>();

            int duublid = 0;
            int kogusumma = 0;

            for (int i = 0; i < 10; i++)
            {
                int t1 = rnd.Next(1, 7);
                int t2 = rnd.Next(1, 7);

                if (t1 == t2)
                    duublid++;

                int summa = t1 + t2;
                summad.Add(summa);
                kogusumma += summa;
            }

            Console.WriteLine("Visete summad:");
            foreach (int s in summad)
                Console.Write(s + " ");

            Console.WriteLine();
            Console.WriteLine($"Duubleid visati: {duublid}");
            Console.WriteLine($"Kõikide visete kogusumma: {kogusumma}");
        }

        public static Tuple<double, double> ArvutaPalk(double brutopalk)
        {
            double maksuvaba = 0;

            if (brutopalk < 1200)
                maksuvaba = 654;

            double tulumaksuAlus = brutopalk - maksuvaba;
            if (tulumaksuAlus < 0)
                tulumaksuAlus = 0;

            double tulumaks = tulumaksuAlus * 0.20;
            double tootuskindlustus = brutopalk * 0.016;
            double pension = brutopalk * 0.02;

            double netopalk = brutopalk - tulumaks - tootuskindlustus - pension;

            return Tuple.Create(maksuvaba, netopalk);
        }
    }
}