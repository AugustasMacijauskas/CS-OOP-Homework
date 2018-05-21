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

            string skyrikliai = " .,!?:;()\t'\"";
            string text1 = File.ReadAllText(duom1);
            string text2 = File.ReadAllText(duom2);

            IlgiausiZodziai(text1, text2, skyrikliai);

            Spausdinti(rez1, String.Format("\nPirmame duomenų faile:"));
            IlgiausiasSakinys(text1, skyrikliai);
            Spausdinti(rez1, String.Format("Antrame duomenų faile:"));
            IlgiausiasSakinys(text2, skyrikliai);
        }

        static void IlgiausiasSakinys(string text, string skyrikliai)
        {
            string[] parts = text.Split(".!?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int ilgisSim = parts[0].Length;
            int ilgisŽod = parts[0].Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
            int ind = text.IndexOf(parts[0]);

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i].Length > ilgisSim)
                {
                    ilgisSim = parts[i].Length;
                    ilgisŽod = parts[i].Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
                    ind = text.IndexOf(parts[i]);
                }
            }

            int count = 1;
            
            for (int i = 0; i < text.Length; i++)
            {
                if (ind == i)
                    break;
                if (text[i] == '\n')
                    count++;
            }

            Spausdinti(rez1, String.Format("Ilgiausias sakinys prasideda {0} eilutėje, jo ilgis simboliais: {1}, ilgis žodžiais: {2}", count, ilgisSim, ilgisŽod));

        }

        static void IlgiausiZodziai(string text1, string text2, string skyrikliai)
        {
            string[] parts1 = text1.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] parts2 = text2.Split(skyrikliai.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
                    Spausdinti(rez1, String.Format("{0, -20} {1, 5} {2, 5}", A[i], PasikartojimuSkaicius(A[i], parts1), PasikartojimuSkaicius(A[i], parts2)));
                }
            }
            else
            {
                for (int i = 0; i < A.Count; i++)
                {
                    Spausdinti(rez1, String.Format("{0, -20} {1, 5} {2, 5}", A[i], PasikartojimuSkaicius(A[i], parts1), PasikartojimuSkaicius(A[i], parts2)));
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
                if (masyvas[i].ToLower().Trim() == x.ToLower())
                    kiekPasikartojimu++;
            }

            return kiekPasikartojimu;
        }
    }
}