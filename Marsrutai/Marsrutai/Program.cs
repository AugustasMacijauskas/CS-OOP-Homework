using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Marsrutai
{
    class Program
    {
        const string input = "..//..//marsrutai.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Dictionary<int, List<string>> marsrutai = new Dictionary<int, List<string>>();
            Skaityti(input, marsrutai);
            Spausdinti(marsrutai, "Pradinis sąrašas:");

            Dictionary<string, List<KeyValuePair<int, string>>> graph = new Dictionary<string, List<KeyValuePair<int, string>>>();
            FormGraph(marsrutai, graph);
            Spausdinti(graph, "Grafas:");

            List<List<KeyValuePair<int, string>>> atsakymai = new List<List<KeyValuePair<int, string>>>();
            bool[] visited = new bool[graph.Count];
            DFS(atsakymai, graph, visited);

            // I funkcija
            atsakymai.ForEach(x => {
                x.ForEach(y =>
                {
                    Console.Write($"{y.Key} -> {y.Value}");
                });
                Console.WriteLine();
            });
        }

        static void DFS(List<List<KeyValuePair<int, string>>> atsakymai, Dictionary<string, List<KeyValuePair<int, string>>> graph, bool[] visited, int gylis = 5, string start = "A", string finish = "R")
        {
            foreach (var stotele in graph)
            {

            }
        }

        static void FormGraph(Dictionary<int, List<string>> marsrutai, Dictionary<string, List<KeyValuePair<int, string>>> graph)
        {
            foreach (KeyValuePair<int, List<string>> pair in marsrutai)
            {
                List<string> stoteles = pair.Value;
                for (int i = 0; i < stoteles.Count - 1; i++)
                {
                    if (!graph.ContainsKey(stoteles[i]))
                    {
                        graph.Add(stoteles[i], new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(pair.Key, stoteles[i + 1]) });
                    }
                    else
                    {
                        graph[stoteles[i]].Add(new KeyValuePair<int, string>(pair.Key, stoteles[i + 1]));
                    }
                }
            }
        }

        static void Skaityti(string file, Dictionary<int, List<string>> marsrutai)
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

                    marsrutai.Add(int.Parse(parts[0].Trim()), marsrutas);
                }
            }
        }

        static void Spausdinti(Dictionary<string, List<KeyValuePair<int, string>>> grafas, string antraste)
        {
            if (grafas.Count > 0)
            {
                Console.WriteLine(antraste);
                foreach (KeyValuePair<string, List<KeyValuePair<int, string>>> pair in grafas)
                {
                    Console.Write("{0} stotele:", pair.Key);
                    foreach (KeyValuePair<int, string> edge in pair.Value)
                    {
                        Console.Write(" {0} -> {1};", edge.Key, edge.Value);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        static void Spausdinti(Dictionary<int, List<string>> marsrutai, string antraste)
        {
            if (marsrutai.Count > 0)
            {
                Console.WriteLine(antraste);
                foreach (KeyValuePair<int, List<string>> pair in marsrutai)
                {
                    Console.Write("{0}", pair.Key);
                    foreach(string stotele in pair.Value)
                    {
                        Console.Write(" " + stotele);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
