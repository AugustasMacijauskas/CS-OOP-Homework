using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FailoKopija
{
    class Program
    {
        const string duom1 = "..\\..\\Knyga1.txt";
        const string duom2 = "..\\..\\Knyga2.txt";
        const string rez1 = "..\\..\\Analizė.txt";
        const string rez2 = "..\\..\\ManoKnyga.txt";

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;

            char[] skyrikliai = { ' ', '-', '.', ',', '!', '?', ':', ';', '(', ')', '\'', '\t', '\"', '\n', '\r' };
            string text1 = File.ReadAllText(duom1);
            
            string text2 = File.ReadAllText(duom2);

            if (File.Exists(rez1))
                File.Delete(rez1);

            if (File.Exists(rez2))
                File.Delete(rez2);

            IlgiausiZodziai(text1, text2, skyrikliai);

            Spausdinti(rez1, String.Format("\nPirmame duomenų faile:"));
            IlgiausiasSakinys(text1, skyrikliai);
            Spausdinti(rez1, String.Format("\nAntrame duomenų faile:"));
            IlgiausiasSakinys(text2, skyrikliai);


            Formuoti(rez2, text1, text2, skyrikliai);
        }

        static void Valyti(ref string x)
        {
            string txt = "";
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != '\r')
                {
                    txt += x[i];
                }
            }

            x = txt;
        }

        static void Formuoti(string rez, string text1, string text2, char[] skyrikliai)
        {
            Valyti(ref text1);
            Valyti(ref text2);

            while (text1.Length > 0 && text2.Length > 0)
            {
                if (text1.Length > 0 && text2.Length > 0)
                {
                    Tikrinti(rez, ref text1, text2, skyrikliai);
                }
                if (text1.Length > 0 && text2.Length > 0)
                {
                    Tikrinti(rez, ref text2, text1, skyrikliai);
                }
            }
        }

        static void NukirptiPradzia(ref string x, char[] skyrikliai)
        {
            while (skyrikliai.Contains(x[0])) {
                x = x.Substring(1);
            }
        }

        static void Tikrinti(string rez, ref string text1, string text2, char[] skyrikliai)
        {
            string[] parts1 = text1.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            string[] parts2 = text2.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);

            string pagalb = parts2[0];

            foreach (string zodis1 in parts1)
            {
                if (zodis1.ToLower().Trim() == pagalb.Trim().ToLower())
                {
                    int at = text1.IndexOf(pagalb, StringComparison.CurrentCultureIgnoreCase);

                    if (at > 0)
                    {
                        if (parts2.Length == 1)
                        {
                            Spausdinti(rez, text1.Substring(0));
                            text1 = "";
                            text2 = "";
                            break;
                        }
                        else
                        {
                            Spausdinti(rez, text1.Substring(0, text1.IndexOf(pagalb, StringComparison.CurrentCultureIgnoreCase)));
                            text1 = text1.Substring(text1.IndexOf(pagalb, StringComparison.CurrentCultureIgnoreCase) + pagalb.Length);
                            NukirptiPradzia(ref text1, skyrikliai);
                            Console.WriteLine(text1 + '\n');
                            break;
                        }
                    }
                    else if (at == 0)
                    {
                        if (parts2.Length == 1)
                        {
                            Spausdinti(rez, text1);
                            text1 = "";
                            text2 = "";
                            break;
                        }
                        else
                        {
                            Spausdinti(rez, text1.Substring(0, text1.IndexOf(pagalb, StringComparison.CurrentCultureIgnoreCase)));
                            text1 = text1.Substring(text1.IndexOf(pagalb, StringComparison.CurrentCultureIgnoreCase) + pagalb.Length);
                            NukirptiPradzia(ref text1, skyrikliai);
                            break;
                        }
                    }                 
                }
                else
                {
                    if (pagalb == "")
                    {
                        Spausdinti(rez, text1.Substring(0));
                        text1 = "";
                        Spausdinti(rez, text2);
                        text2 = "";
                    }
                    else if (!parts1.Contains(pagalb))
                    {
                        Spausdinti(rez, text1 + text2);
                        text1 = "";
                        text2 = "";
                        break;
                    }
                }
            }
        }

        static string Removal(string text)
        {
            string nauja = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\r' || text[i] == '\n')
                {

                }
                else
                {
                    nauja += text.Substring(i);
                    break;
                }
            }

            return nauja;
        }

        static void IlgiausiasSakinys(string text, char[] skyrikliai)
        {
            string[] parts = text.Split(".!?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int ilgisSim = 0;
            int pagalbSim = 0;
            int ilgisŽod = 0;
            int ind = text.IndexOf(parts[0]);
            int pagalb = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                pagalbSim = 0;
                for (int j = 0; j < parts[i].Length; j++)
                {
                    if (parts[i][j] != '\r' && parts[i][j] != '\n')
                        pagalbSim++;
                }
                if (pagalbSim > ilgisSim)
                {
                    ilgisSim = pagalbSim;
                    ind = text.IndexOf(parts[i]);
                    pagalb = i;
                }
            }

            parts[pagalb] = Removal(parts[pagalb]);
            ind = text.IndexOf(parts[pagalb]);

            Spausdinti(rez1, parts[pagalb]);

            ilgisŽod = parts[pagalb].Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries).Length;

            int count = 1;

            for (int i = 0; i < text.Length; i++)
            {
                if (ind == i)
                {
                    if (text[i] == '\n' || text[i] == '\r')
                        count++;
                    break;
                }
                if (text[i] == '\n')
                    count++;
            }

            Spausdinti(rez1, String.Format("Ilgiausias sakinys prasideda {0} eilutėje, jo ilgis simboliais: {1}, ilgis žodžiais: {2}", count, ilgisSim, ilgisŽod));

        }

        static void IlgiausiZodziai(string text1, string text2, char[] skyrikliai)
        {
            string[] parts1 = text1.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
            string[] parts2 = text2.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);

            List<string> naujas1 = new List<string>();
            List<string> naujas2 = new List<string>();
            List<string> naujas3 = new List<string>();

            Formuoti(naujas1, parts1);
            Formuoti(naujas2, parts2);
            Ilgiausi(naujas3, naujas1, naujas2);

            naujas3.Sort((x, y) => y.Length.CompareTo(x.Length));

            SpausdintiIlgiausius(naujas3, parts1, parts2);
        }

        static void SpausdintiIlgiausius(List<string> A, string[] parts1, string[] parts2)
        {
            if (A.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    Spausdinti(rez1, String.Format("{0, -30}  {1, 5}  {2, 5}", A[i], PasikartojimuSkaicius(A[i], parts1), PasikartojimuSkaicius(A[i], parts2)));
                }
            }
            else
            {
                for (int i = 0; i < A.Count; i++)
                {
                    Spausdinti(rez1, String.Format("{0, -30}  {1, 5}  {2, 5}", A[i], PasikartojimuSkaicius(A[i], parts1), PasikartojimuSkaicius(A[i], parts2)));
                }
            }
        }

        static void Ilgiausi(List<string> naujas3, List<string> naujas1, List<string> naujas2)
        {
            foreach (string x1 in naujas1)
            {
                foreach (string x2 in naujas2)
                {
                    if (x1.ToLower().Trim() == x2.ToLower().Trim())
                        naujas3.Add(x1);
                }
            }
        }

        static void Formuoti(List<string> naujas, string[] parts)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                if (!naujas.Contains(parts[i].ToLower().Trim()))
                    naujas.Add(parts[i].ToLower().Trim());
            }
        }

        static void Spausdinti(string rez, string text)
        {
            using (var fw = File.AppendText(rez))
            {
                fw.WriteLine(text);
                Console.WriteLine(text);
            }
        }

        static int PasikartojimuSkaicius(string x, string[] masyvas)
        {
            int kiekPasikartojimu = 0;
            for (int i = 0; i < masyvas.Length; i++)
            {
                if (masyvas[i].ToLower().Trim() == x.ToLower().Trim())
                    kiekPasikartojimu++;
            }

            return kiekPasikartojimu;
        }
    }
}