using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Marsrutai
{
    class Stotelė
    {
        public int AutobusoNumeris { get; set; }
        public List<string> Kryptys { get; set; }

        public Stotelė(int num, List<string> kr)
        {
            this.AutobusoNumeris = num;
            this.Kryptys = kr;
        }

        public override string ToString()
        {
            string eil = "";
            eil = eil + AutobusoNumeris;
            foreach (string kryptis in Kryptys)
            {
                eil = eil + " " + kryptis;
            }

            eil = eil + "\n";

            return eil;
        }
    }

    class Kelias
    {
        public int AutobusoNumeris { get; set; }
        public string Kryptis { get; set; }

        public Kelias(int num, string des)
        {
            this.AutobusoNumeris = num;
            this.Kryptis = des;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}; ", AutobusoNumeris, Kryptis);
        }
    }

    class Maršrutas
    {
        public List<Kelias> marsrutas { get; private set; }

        public Maršrutas(List<Kelias> route)
        {
            marsrutas = route;
        }

        public override string ToString()
        {
            string eil = "";
            foreach(var kelias in marsrutas)
            {
                eil += kelias;
            }

            eil += "\n";

            return eil;
        }
    }

    class Keliai
    {
        private Dictionary<string, List<Kelias>> graph;
        private Dictionary<string, bool> visited;
        public List<Maršrutas> Atsakymai { get; private set; }

        public Keliai(List<Stotelė> marsrutai)
        {
            graph = new Dictionary<string, List<Kelias>>();
            visited = new Dictionary<string, bool>();
            FormGraph(marsrutai);
            Atsakymai = new List<Maršrutas>();
        }

        private void FormGraph(List<Stotelė> marsrutai)
        {

            foreach (var entry in marsrutai)
            {
                List<string> stoteles = entry.Kryptys;
                for (int i = 0; i < stoteles.Count; i++)
                {
                    visited[stoteles[i]] = false;
                    if (!graph.ContainsKey(stoteles[i]))
                    {
                        graph.Add(stoteles[i], new List<Kelias>());
                    }

                    if (i - 1 >= 0)
                    {
                        graph[stoteles[i]].Add(new Kelias(entry.AutobusoNumeris, stoteles[i - 1]));
                    }
                    if (i + 1 < stoteles.Count)
                    {
                        graph[stoteles[i]].Add(new Kelias(entry.AutobusoNumeris, stoteles[i + 1]));
                    }
                }
            }
        }

        public void DFS(string start, string finish, Maršrutas current, Kelias edge = null)
        {
            if (start == finish)
            {
                Maršrutas naujas = new Maršrutas(new List<Kelias>(current.marsrutas));
                Atsakymai.Add(naujas);
                naujas.marsrutas.Add(edge);
                return;
            }

            visited[start] = true;

            if (edge != null)
            {
                current.marsrutas.Add(edge);
            }

            List<Kelias> adjacent = graph[start];
            for (int i = 0; i < adjacent.Count; i++)
            {
                if (!visited[adjacent[i].Kryptis])
                {
                    DFS(adjacent[i].Kryptis, finish, current, adjacent[i]);
                }
            }

            visited[start] = false;
            if (edge != null)
            {
                current.marsrutas.RemoveAt(current.marsrutas.Count - 1);
            }
        }

        public override string ToString()
        {
            string eil = "";
            eil += "Grafas:\n";
            foreach(var pair in graph)
            {
                eil += pair.Key + " ";
                foreach (var kelias in pair.Value)
                {
                    eil += kelias + " ";
                }
                eil += "\n";
            }

            return eil;
        }
    }

    class Program
    {
        const string input = "..//..//marsrutai.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            List<Stotelė> marsrutai = new List<Stotelė>();
            Skaityti(input, marsrutai);
            Spausdinti(marsrutai, "Pradinis sąrašas:");

            Keliai keliai = new Keliai(marsrutai);
            Console.WriteLine(keliai);

            string start, finish;
            Console.Write("Įveskite, iš kur norite važiuoti: ");
            start = Console.ReadLine();
            Console.Write("Įveskite, kur norite nuvažiuoti: ");
            finish = Console.ReadLine();
            keliai.DFS(start, finish, new Maršrutas(new List<Kelias>()));

            List<Maršrutas> atsakymai = keliai.Atsakymai;
            if (atsakymai.Count > 0)
            {
                int minimumas = atsakymai.Min(x => x.marsrutas.Count);
                atsakymai = atsakymai.Where(x => x.marsrutas.Count == minimumas).ToList();
                Spausdinti(atsakymai, "Galimi keliai:");
            }
            else
            {
                Console.WriteLine("Galimų kelių nėra!");
            }
        }

        static void Skaityti(string file, List<Stotelė> marsrutai)
        {
            using (StreamReader reader = new StreamReader(file)) {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    List<string> marsrutas = new List<string>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        marsrutas.Add(parts[i].Trim());
                    }

                    Stotelė naujaStotelė = new Stotelė(int.Parse(parts[0].Trim()), marsrutas);
                    marsrutai.Add(naujaStotelė);
                }
            }
        }

        static void Spausdinti<T>(List<T> masyvas, string antraste)
        {
            if (masyvas.Count > 0)
            {
                Console.WriteLine(antraste);
                foreach (var entry in masyvas)
                {
                    Console.Write(entry);
                }

                Console.WriteLine();
            }
        }
    }
}