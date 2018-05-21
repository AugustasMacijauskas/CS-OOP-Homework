using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDS_14GeometrinesFiguros
{
    class Program
    {
        const string figuruDuomenys = "FiguruDuomenys.txt";
        const string atsakymuFailas = "AtsakymuFailas.txt";

        private static List<Figura> visosFiguros = new List<Figura>();
        private static List<Apskritimas> apskritimai = new List<Apskritimas>();

        private static void Main(string[] args)
        {
            Console.WriteLine("Meniu:");
            Console.WriteLine("1. Kiek ir kokiu figuru yra.");
            Console.WriteLine("2. Didziausia perimetra turinti figura.");
            Console.WriteLine("3. Didziausia plota turinti figura.");
            Console.WriteLine("4. Kiek yra staciu trikampiu ibreztu i apskritimus.");
            Console.WriteLine("5. Kiek yra kvadratu apibreztu apie apskritimus.");
            Console.WriteLine("6. Informacija apie kiekviena grupe.");
            Console.WriteLine("7. Baigti.");
            
            IsvalytiAtsakymuFaila();
            GautiFiguras();
            Meniu();
        }

        private static void IsvalytiAtsakymuFaila()
        {
            File.WriteAllText(atsakymuFailas, String.Empty);
        }

        private static void GautiFiguras()
        {
            using (StreamReader sr = new StreamReader(figuruDuomenys))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] input = line.Split(' ');   
                    if (input.Length != 4)
                    {
                        Figura figura = new Figura(input[0]);
                        for (int i = 1; i < input.Length - 1; i++)
                        {
                            if (i % 2 != 0)
                            {
                                figura.PridetiKampa(new Point(double.Parse(input[i]), double.Parse(input[i + 1])));
                            }
                        }
                        visosFiguros.Add(figura);
                    }
                    else
                    {
                        Apskritimas figura = new Apskritimas(input[0], double.Parse(input[3]));
                        figura.PridetiKampa(new Point(double.Parse(input[1]), double.Parse(input[2])));
                        apskritimai.Add(figura);
                    }     
                }
            }
        }

        private static void Meniu()
        {
            string pasirinkimas;
            string atskyrimas = new string('-', 51);
            string galimiVariantai = "1 2 3 4 5 6";

            Console.WriteLine(atskyrimas);
            Console.Write("Pasirinkimas: ");
            File.AppendAllText(atsakymuFailas, atskyrimas + "\n");

            while (galimiVariantai.Contains((pasirinkimas = Console.ReadLine())) && pasirinkimas != "")
            {
                Console.WriteLine(atskyrimas);
                File.AppendAllText(atsakymuFailas, "Pasirinkimas: " + pasirinkimas + "\n" + 
                                                                        atskyrimas + "\n");

                switch (pasirinkimas)
                {
                    case "1":
                        KiekIrKokiuFiguru();
                        break;
                    case "2":
                        DidziausioDydzioFigura(x => x.Perimetras, "perimetras");
                        break;
                    case "3":
                        DidziausioDydzioFigura(x => x.Plotas, "plotas");
                        break;
                    case "4":
                        IbreztiStatiejiTrikampiai();
                        break;
                    case "5":
                        ApibreztiKvadratai();
                        break;
                    case "6":
                        Console.WriteLine("Grupes kampu skaicius: (apskritimams 0)");
                        File.AppendAllText(atsakymuFailas, "Grupes kampu skaicius: (apskritimams 0)" + "\n");
                        int kampuSk = int.Parse(Console.ReadLine());
                        Console.WriteLine(atskyrimas);
                        File.AppendAllText(atsakymuFailas, "Pasirinkta kampu grupe: " + kampuSk + 
                                                                        "\n" + atskyrimas + "\n");
                        InfoApieFiguruGrupe(kampuSk);
                        break;
                }

                Console.WriteLine(atskyrimas);
                Console.Write("Pasirinkimas: ");
                File.AppendAllText(atsakymuFailas, atskyrimas + "\n");
            }
            Console.WriteLine(atskyrimas);
        }

        private static void InfoApieFiguruGrupe(int kampuSk)
        {
            StreamWriter sw = new StreamWriter(atsakymuFailas, true);
            if ((kampuSk < 3 || kampuSk > 10) && kampuSk != 0)
            {
                Console.WriteLine("Tokios figuru grupes nera");
                sw.WriteLine("Tokios figuru grupes nera");
                return;
            }            

            if (kampuSk == 0)
            {
                if (apskritimai.Count != 0)
                {
                    Console.WriteLine("Isviso apskritimu yra: " + apskritimai.Count);
                    sw.WriteLine("Isviso apskritimu yra: " + apskritimai.Count);
                }              
                else
                {
                    Console.WriteLine("Apskritimu nera.");
                    sw.WriteLine("Apskritimu nera.");
                    return;
                }
                Console.WriteLine("Bendras apskritimu plotas: {0:f2}", apskritimai.Sum(x => x.Plotas));
                Console.WriteLine("Bendras apskritimu perimetras: {0:f2}", apskritimai.Sum(x => x.Perimetras));
                sw.WriteLine("Bendras apskritimu plotas: {0:f2}", apskritimai.Sum(x => x.Plotas));
                sw.WriteLine("Bendras apskritimu perimetras: {0:f2}", apskritimai.Sum(x => x.Perimetras));
            }
            else
            {
                List<Figura> kampuSkFiguros = visosFiguros.FindAll(x => x.kampai.Count == kampuSk);
                if (visosFiguros.Count != 0)
                {
                    Console.WriteLine("Isviso figuru yra: " + kampuSkFiguros.Count);
                    sw.WriteLine("Isviso figuru yra: " + kampuSkFiguros.Count);
                }  
                else
                {
                    Console.WriteLine("Figuru nera.");
                    sw.WriteLine("Figuru nera.");
                    return;
                }
                int lygiakrasciuKiekis = kampuSkFiguros.FindAll(x => x.arLygiakrastis).Count;
                if (lygiakrasciuKiekis != 0)
                {
                    Console.WriteLine("Lygiakrasciu figuru yra: {0}", lygiakrasciuKiekis);
                    sw.WriteLine("Lygiakrasciu figuru yra: {0}", lygiakrasciuKiekis);
                }
                else
                {
                    Console.WriteLine("Lygiakrasciu figuru nera.");
                    sw.WriteLine("Lygiakrasciu figuru nera.");
                }

                Console.WriteLine("Bendras figuru plotas: {0:f2}", kampuSkFiguros.Sum(x => x.Plotas));
                Console.WriteLine("Bendras figuru perimetras: {0:f2}", kampuSkFiguros.Sum(x => x.Perimetras));
                sw.WriteLine("Bendras figuru plotas: {0:f2}", kampuSkFiguros.Sum(x => x.Plotas));
                sw.WriteLine("Bendras figuru perimetras: {0:f2}", kampuSkFiguros.Sum(x => x.Perimetras));
            }
            sw.Dispose();
        }

        private static void ApibreztiKvadratai()
        {
            List<Figura> apibreztiKvadratai = new List<Figura>();
            foreach (Figura f in visosFiguros)
            {
                if (f.arKvadratas)
                {
                    foreach (Apskritimas a in apskritimai)
                    {
                        if (f.ArApibreztas(a))
                            apibreztiKvadratai.Add(f);
                    }
                }
            }
            IbreztiniuApibreztiniuSpausdinimas(apibreztiKvadratai, "Apibreztu kvadratu yra: ");
        }

        private static void IbreztiStatiejiTrikampiai()
        {
            List<Figura> ibreztiStatiejiTrikampiai = new List<Figura>();
            foreach (Figura f in visosFiguros)
            {
                if (f.arStatusisTrikampis)
                {
                    foreach (Apskritimas a in apskritimai)
                    {
                        if (f.ArIbreztas(a))
                        {
                            ibreztiStatiejiTrikampiai.Add(f);
                            break;
                        }
                    }
                }
            }
            IbreztiniuApibreztiniuSpausdinimas(ibreztiStatiejiTrikampiai, "Ibreztu staciuju trikampiu yra: ");
        }

        private static void IbreztiniuApibreztiniuSpausdinimas(List<Figura> rinkinys, string tekstas)
        {
            using (StreamWriter sw = new StreamWriter(atsakymuFailas, true))
            {
                Console.WriteLine(tekstas + rinkinys.Count);
                sw.WriteLine(tekstas + rinkinys.Count);

                Action<Figura> spausdinimas = (f) =>
                {
                    Console.Write(f.vardas + " ");
                    sw.Write(f.vardas + " ");
                };

                rinkinys.ForEach(x => spausdinimas(x));

                if (rinkinys.Count != 0)
                {
                    Console.WriteLine();
                    sw.WriteLine();
                } 
            }
        }

        private static void DidziausioDydzioFigura(Func<Figura, double> pasirinktasDydis, string dydzioPav)
        {
            double ilgiausiasFiguros = visosFiguros.Max(x => pasirinktasDydis(x));
            double ilgiausiasApskritimo = apskritimai.Max(x => pasirinktasDydis(x));

            if (ilgiausiasFiguros > ilgiausiasApskritimo)
            {
                SpausdintiFigurasSuDidziausiuDydziu(visosFiguros.FindAll(x => pasirinktasDydis(x) == ilgiausiasFiguros), 
                                                                                dydzioPav, x => pasirinktasDydis(x));
            }
            else if (ilgiausiasApskritimo > ilgiausiasFiguros)
            {
                List<Figura> ilgiausiApskritimai = apskritimai.FindAll(x => pasirinktasDydis(x) == ilgiausiasApskritimo).
                                                                                                Cast<Figura>().ToList();
                SpausdintiFigurasSuDidziausiuDydziu(ilgiausiApskritimai, dydzioPav, x => pasirinktasDydis(x));
            }
            else
            {
                List<Figura> ilgiausiosFiguros = visosFiguros.FindAll(x => pasirinktasDydis(x) == ilgiausiasFiguros);
                List<Figura> ilgiausiApskritimai = apskritimai.FindAll(x => pasirinktasDydis(x) == ilgiausiasApskritimo).
                                                                                                Cast<Figura>().ToList();
                SpausdintiFigurasSuDidziausiuDydziu(ilgiausiosFiguros.Concat(ilgiausiApskritimai).ToList(), dydzioPav, 
                                                                                               x => pasirinktasDydis(x));
            }
        }

        private static void SpausdintiFigurasSuDidziausiuDydziu(List<Figura> figuros, string dydis, 
                                                                Func<Figura, double> didziausiasDydis)
        {
            using (StreamWriter sw = new StreamWriter(atsakymuFailas, true))
            {
                if (figuros.Count == 1)
                {
                    Console.WriteLine("Didziausia {0} turinti figura:\n{1}, jos {0}s: {2}", dydis.Remove(dydis.Length - 1, 1),
                                                                        figuros[0].vardas, didziausiasDydis(figuros[0]));

                    sw.WriteLine("Didziausia {0} turinti figura:\n{1}, jos {0}s: {2}", dydis.Remove(dydis.Length - 1, 1),
                                                                        figuros[0].vardas, didziausiasDydis(figuros[0]));
                }
                else
                {
                    Console.WriteLine("Didziausia {0} turincios figuros:", dydis.Remove(dydis.Length - 1, 1));
                    sw.WriteLine("Didziausia {0} turincios figuros:", dydis.Remove(dydis.Length - 1, 1));

                    foreach (Figura figura in figuros)
                    {
                        Console.WriteLine("Vardas: {0}, {1}: {2}", figura.vardas, dydis, didziausiasDydis(figura));
                        sw.WriteLine("Vardas: {0}, {1}: {2}", figura.vardas, dydis, didziausiasDydis(figura));
                    }                    
                }
            }   
        }

        private static void KiekIrKokiuFiguru()
        {
            StreamWriter sw = new StreamWriter(atsakymuFailas, true);
            if (apskritimai.Count != 0)
            {
                if (apskritimai.Count == 1)
                {
                    Console.Write("Yra 1 apskritimas: ");
                    sw.Write("Yra 1 apskritimas: ");
                }
                else if (apskritimai.Count < 10)
                {
                    Console.Write("Yra {0} apskritimai: ", apskritimai.Count);
                    sw.Write("Yra {0} apskritimai: ", apskritimai.Count);
                }
                else
                {
                    Console.Write("Yra {0} apskritimu: ", apskritimai.Count);
                    sw.Write("Yra {0} apskritimu: ", apskritimai.Count);
                }

                Action<string> spausdinimas = (x) => 
                {
                    Console.Write(x + " ");
                    sw.Write(x + " ");
                };
                apskritimai.ForEach(x => spausdinimas(x.vardas));

                Console.WriteLine();
                sw.WriteLine();
            }
            
            if (visosFiguros.Count != 0)
            {
                IEnumerable<IGrouping<int, Figura>> sugrupuota = visosFiguros.GroupBy(x => x.kampai.Count);
                foreach (IGrouping<int, Figura> grupe in sugrupuota)
                {
                    if (grupe.Count() == 1)
                    {
                        Console.Write("Yra 1 {0}-kampis: ", grupe.Key);
                        sw.Write("Yra 1 {0}-kampis: ", grupe.Key);
                    }
                    else if (grupe.Count() < 10)
                    {
                        Console.Write("Yra {0} {1}-kampiai: ", grupe.Count(), grupe.Key);
                        sw.Write("Yra {0} {1}-kampiai: ", grupe.Count(), grupe.Key);
                    }
                    else
                    {
                        Console.Write("Yra {0} {1}-kampiu: ", grupe.Count(), grupe.Key);
                        sw.Write("Yra {0} {1}-kampiu: ", grupe.Count(), grupe.Key);
                    }

                    foreach (Figura f in grupe)
                    {
                        Console.Write(f.vardas + " ");
                        sw.Write(f.vardas + " ");
                    }
                    Console.WriteLine();
                    sw.WriteLine();
                }
            }
            sw.Dispose();
        }
    }
}
