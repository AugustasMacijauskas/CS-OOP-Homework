using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L6_Serveriai_Augustas_Mačijauskas_4NFQ
{
    class InvalidIPFormatException : ApplicationException
    {
        public string messageDetails { get; private set; }
        public string causeOfError { get; private set; }

        public InvalidIPFormatException()
        {
        }

        public InvalidIPFormatException(string message, string line)
        {
            this.messageDetails = message;
            this.causeOfError = line;
        }

        public override string Message
        {
            get {
               return string.Format($"Netinkamas IP adreso formatas: {messageDetails}; eilutė: {causeOfError}");
            }
        }
    }

    class IP : IEquatable<IP>
    {
        public string Address { get; private set; }

        public IP(string ip = "")
        {
            this.Address = ip;
        }

        public static bool TryParse(string ip, out IP naujas, string line)
        {
            int countDots = ip.Count(x => x == '.');

            if (countDots != 3)
                throw new InvalidIPFormatException("Taškų skaičius IP adrese nelygus trims.", line);

            string[] parts = ip.Split('.');
            foreach (string part in parts)
            {
                bool arSkaicius = int.TryParse(part, out int ipDalis);
                if (!arSkaicius) {
                    throw new InvalidIPFormatException("IP adreso dalis nėra skaičius.", line);
                }
                else
                {
                    if (ipDalis < 0 || ipDalis > 255)
                    {
                        throw new InvalidIPFormatException("IP adreso dalis nėra skaičius intervale [0; 255].", line);
                    }
                }
            }

            naujas = new IP(ip);

            return true;
        }

        public override string ToString()
        {
            return Address;
        }

        public bool Equals(IP other)
        {
            int poz = string.Compare(Address, other.Address, StringComparison.CurrentCulture);

            return poz == 0;
        }
    }

    class Serveris : IComparable<Serveris>, IEquatable<Serveris>
    {
        public IP IP_Adresas { get; private set; }
        public string SimbolinisAdresas { get; private set; }

        public Serveris(IP ip, string adr)
        {
            this.IP_Adresas = ip;
            this.SimbolinisAdresas = adr;
        }

        public static readonly string Divider = "-------------------------------------------------";

        public static readonly string Header = Divider + "\r\n" +
                                               $" {"IP adresas",-16} {"Simbolinis adresas",30}\r\n" +
                                               Divider;

        public override string ToString()
        {
            return string.Format($"{IP_Adresas,-16} {SimbolinisAdresas,30}");
        }

        public int CompareTo(Serveris other)
        {
            int poz = string.Compare(SimbolinisAdresas, other.SimbolinisAdresas, StringComparison.CurrentCulture);

            return poz;
        }

        public bool Equals(Serveris other)
        {
            int poz = string.Compare(SimbolinisAdresas, other.SimbolinisAdresas, StringComparison.CurrentCulture);

            return (IP_Adresas.Equals(other.IP_Adresas) && poz == 0);
        }
    }

    class Apsilankymas
    {
        public DateTime Laikas { get; private set; }
        public IP Kompiuterio_IP_Adresas { get; private set; }
        public string Endpoint { get; private set; }

        public Apsilankymas(DateTime dt, IP ip, string endpoint)
        {
            this.Laikas = dt;
            this.Kompiuterio_IP_Adresas = ip;
            this.Endpoint = endpoint;
        }

        public static readonly string Divider = "-----------------------------------------------------------------------";

        public static readonly string Header = Divider + "\r\n" +
                                               $" {"Laikas"}      {"Kompiuterio IP adresas",-16} {"Svetainė",34}\r\n" +
                                               Divider;

        public override string ToString()
        {
            return string.Format($" {Laikas:HH:mm:ss}    {Kompiuterio_IP_Adresas, -16} {Endpoint, 40}");
        }
    }

    class Program
    {
        const string serveriuDuomenys = "..\\..\\Serveriai.txt";

        static void Main(string[] args)
        {
            try {
                Console.OutputEncoding = Encoding.Unicode;

                List<Serveris> serveriai = new List<Serveris>();
                SkaitytiServerius(serveriuDuomenys, serveriai);
                SpausdintiSarasa(serveriai, "Pradiniai serverių duomenys:", Serveris.Header, Serveris.Divider);

                Console.Write("Įveskite simbolinį adresą serverio, kurio duomenis norite pamatyti: ");
                string websiteInput = Console.ReadLine();
                if (websiteInput == "")
                    websiteInput = "ktug.lt";
                if (serveriai.Any(x => x.SimbolinisAdresas == websiteInput))
                {
                    Dictionary<DateTime, List<Apsilankymas>> apsilankymai = new Dictionary<DateTime, List<Apsilankymas>>();
                    SkaitytiDienas(apsilankymai);
                    SpausdintiDienas(apsilankymai, "Pradiniai apsilankymų duomenys:", Apsilankymas.Header, Apsilankymas.Divider);

                    List<string> puslapioStruktura = new List<string>();
                    FormuotiPuslapioStruktura(websiteInput, apsilankymai, puslapioStruktura);

                    SpausdintiSarasa(puslapioStruktura, $"{websiteInput} puslapio struktūra:", "-------------------\r\n Adresas \r\n-------------------", "-------------------");
                }
                else
                {
                    throw new Exception("Klaida! Įvestas serverio simbolinis adresas neatitinka nei vieno egzistuojančio serverio vardo.");
                }
            }
            catch (InvalidIPFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void FormuotiPuslapioStruktura(string puslapis, Dictionary<DateTime, List<Apsilankymas>> apsilankymai, List<string> struktura)
        {
            foreach (var entry in apsilankymai)
            {
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    if (entry.Value[i].Endpoint.Contains(puslapis))
                    {
                        struktura.Add(entry.Value[i].Endpoint.Substring(entry.Value[i].Endpoint.IndexOf('/')));
                    }
                }
            }
        }

        static void SkaitytiServerius(string file, List<Serveris> serveriai)
        {
            if (!File.Exists(file))
            {
                throw new Exception($"Klaida! Failas {Directory.GetCurrentDirectory() + file} nerastas");
            }
            else
            {
                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        IP.TryParse(parts[0].Trim(), out IP naujasIP, line);
                        string simbolinisNaujas = parts[1].Trim();
                        if (simbolinisNaujas != "")
                        {
                            serveriai.Add(new Serveris(naujasIP, simbolinisNaujas));
                        }
                        else
                        {
                            throw new Exception($"Klaida! Neįmanoma nuskaityti eilutės: {line}");
                        }
                    }
                }
            }
        }

        static void SpausdintiSarasa<T>(List<T> sarasas, string antraste, string header, string divider)
        {
            if (sarasas.Count > 0)
            {
                Console.WriteLine(antraste);
                Console.WriteLine(header);
                for (int i = 0; i < sarasas.Count; i++)
                {
                    Console.WriteLine(" " + sarasas[i]);
                }
                Console.WriteLine(divider + "\r\n");
            }
            else
            {
                throw new Exception("Klaida! Sąrašas tuščias.");
            }
        }

        static void SkaitytiDienas(Dictionary< DateTime, List<Apsilankymas> > apsilankymai)
        {
            string fileDirectory = Directory.GetCurrentDirectory() + "..\\..\\..\\Dienos";
            if (!Directory.Exists(fileDirectory))
            {
                throw new DirectoryNotFoundException($"Klaida! Direktorija {fileDirectory} neegzistuoja");
            }
            List<string> fileEntries = new List<string>(Directory.GetFiles(fileDirectory, "*.txt"));
            foreach (var entry in fileEntries)
            {
                //string failoPavadinimas = Path.GetFileNameWithoutExtension(entry);
                string failoPavadinimas = entry;
                using (var reader = new StreamReader(failoPavadinimas))
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');

                    if (!(DateTime.TryParse(parts[0].Trim(), out DateTime data) && data <= DateTime.Now))
                    {
                        throw new Exception("Klaida! Blogas dienos failo pavadinimo formatas.");
                    }
                    IP.TryParse(parts[1].Trim(), out IP naujas, line);
                    //else if (IP.TryParse(parts[1].Trim(), out IP naujas))
                    //{

                    //}

                    apsilankymai.Add(data, new List<Apsilankymas>());
                    while ((line = reader.ReadLine()) != null)
                    {
                        parts = line.Split(';');
                        DateTime.TryParse(parts[0].Trim(), out DateTime kreipimosiLaikas);
                        IP.TryParse(parts[1].Trim(), out IP besikreipantisKomputeris, line);
                        string endpoint = parts[2].Trim();
                        if (endpoint == "")
                        {
                            throw new Exception($"Klaida! Neįmanoma nuskaityti eilutės: {line}");
                        }
                        else
                        {
                            apsilankymai[data].Add(new Apsilankymas(kreipimosiLaikas, besikreipantisKomputeris, endpoint));
                        }
                    }
                }
            }
        }

        static void SpausdintiDienas(Dictionary<DateTime, List<Apsilankymas>> apsilankymai, string antraste, string header, string divider)
        {
            Console.WriteLine(antraste);
            foreach (KeyValuePair<DateTime, List<Apsilankymas> > entry in apsilankymai)
            {
                Console.WriteLine(entry.Key.ToString("d") + ":");
                Console.WriteLine(header);
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    Console.WriteLine(entry.Value[i]);
                }
                Console.WriteLine(divider + "\r\n");
            }
        }
    }
}
