using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace StatisticalAnalysis
{
    class Program
    {
        static List<double> degisken1 = new List<double>();
        static List<double> degisken2 = new List<double>();
        static List<double> degisken3 = new List<double>();

        static void Main(string[] args)
        {
            if (!File.Exists("veriler.txt"))
            {
                VeriSetiOlustur();
            }

            DosyadanOku();

            while (true)
            {
                Console.WriteLine("\n1. Verileri Göster");
                Console.WriteLine("2. Veri Ekle");
                Console.WriteLine("3. Veri Sil");
                Console.WriteLine("4. İstatistikleri Hesapla");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        VerileriGoster();
                        break;
                    case "2":
                        VeriEkle();
                        break;
                    case "3":
                        VeriSil();
                        break;
                    case "4":
                        IstatistikleriHesapla();
                        break;
                    case "5":
                        return;
                }
            }
        }

        static void VeriSetiOlustur()
        {
            using (StreamWriter sw = new StreamWriter("veriler.txt"))
            {
                sw.WriteLine("Degisken1\tDegisken2\tDegisken3");
                Random rnd = new Random();
                for (int i = 0; i < 120; i++)
                {
                    double d1 = rnd.Next(1, 100) + rnd.NextDouble();
                    double d2 = rnd.Next(1, 100) + rnd.NextDouble();
                    double d3 = rnd.Next(1, 100) + rnd.NextDouble();
                    sw.WriteLine($"{d1:F2}\t{d2:F2}\t{d3:F2}");
                }
            }
        }

        static void DosyadanOku()
        {
            degisken1.Clear();
            degisken2.Clear();
            degisken3.Clear();

            string[] satirlar = File.ReadAllLines("veriler.txt");
            for (int i = 1; i < satirlar.Length; i++)
            {
                string[] degerler = satirlar[i].Split('\t');
                degisken1.Add(double.Parse(degerler[0]));
                degisken2.Add(double.Parse(degerler[1]));
                degisken3.Add(double.Parse(degerler[2]));
            }
        }

        static void VerileriGoster()
        {
            Console.WriteLine("\nSatır No\tDeğişken 1\tDeğişken 2\tDeğişken 3");
            Console.WriteLine("------------------------------------------------");
            for (int i = 0; i < degisken1.Count; i++)
            {
                Console.WriteLine($"{i}\t{degisken1[i]:F2}\t{degisken2[i]:F2}\t{degisken3[i]:F2}");
            }
        }

        static void VeriEkle()
        {
            try
            {
                Console.Write("Değişken 1 için değer: ");
                double d1 = double.Parse(Console.ReadLine());
                Console.Write("Değişken 2 için değer: ");
                double d2 = double.Parse(Console.ReadLine());
                Console.Write("Değişken 3 için değer: ");
                double d3 = double.Parse(Console.ReadLine());

                File.AppendAllText("veriler.txt", $"{d1:F2}\t{d2:F2}\t{d3:F2}\n");
                DosyadanOku();
                Console.WriteLine("Veri başarıyla eklendi.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hata: {e.Message}");
            }
        }

        static void VeriSil()
        {
            try
            {
                Console.Write("Silmek istediğiniz satır numarası: ");
                int satirNo = int.Parse(Console.ReadLine());

                if (satirNo >= 0 && satirNo < degisken1.Count)
                {
                    List<string> satirlar = new List<string>(File.ReadAllLines("veriler.txt"));
                    satirlar.RemoveAt(satirNo + 1);
                    File.WriteAllLines("veriler.txt", satirlar);
                    DosyadanOku();
                    Console.WriteLine("Veri başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz satır numarası!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hata: {e.Message}");
            }
        }

        static void IstatistikleriHesapla()
        {
            using (StreamWriter sw = new StreamWriter("sonuc.txt"))
            {
                HesaplaVeYazdir("Değişken 1", degisken1, sw, 0);
                HesaplaVeYazdir("Değişken 2", degisken2, sw, 1);
                HesaplaVeYazdir("Değişken 3", degisken3, sw, 2);
            }
        }

        static void HesaplaVeYazdir(string degiskenAdi, List<double> veriler, StreamWriter sw, int index)
        {
            // Sorting, statistics, boxplot generation code...
        }

        static void CizBoxplot(List<double> veriler, string degiskenAdi, int index)
        {
            // Boxplot drawing code using OxyPlot...
        }
    }
}