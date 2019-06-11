#include <fstream>
#include <iomanip>
#include <vector>

using namespace std;

// Iraso tipas prekes duomenims saugoti
struct Preke
{
    string Pavadinimas;
    int Gauta, Parduota;

    Preke() : Pavadinimas(""), Gauta(-1), Parduota(-1) {}

    Preke(string pav, int g, int p) : Pavadinimas(pav), Gauta(g), Parduota(p) {}

    Preke operator +(const Preke& other) const
    {
        return Preke(Pavadinimas, Gauta + other.Gauta, Parduota + other.Parduota);
    }

    bool operator ==(const Preke& other) const
    {
        return (Pavadinimas == other.Pavadinimas);
    }

    bool operator <(const Preke& other) const
    {
        return ((Gauta > other.Gauta)
                || (Gauta == other.Gauta && Pavadinimas < other.Pavadinimas));
    }

    bool operator >(const Preke& other) const
    {
        return ((Gauta < other.Gauta)
                || (Gauta == other.Gauta && Pavadinimas > other.Pavadinimas));
    }
};

// Uzsiklojame operatoriu, kad butu patogu spausdinti
ostream& operator <<(ostream& stream, const Preke& preke)
{
    stream << preke.Pavadinimas << " "
           << setw(2) << preke.Gauta << " "
           << setw(2) << preke.Parduota;
    return stream;
}

void Skaityti(ifstream& input, vector<Preke>& prekes)
{
    int n;
    input >> n;
    input.ignore();

    for (int i = 0; i < n; i++)
    {
        Preke nauja;

        char eil[21];
        input.get(eil, 21);
        nauja.Pavadinimas = string(eil);

        int gauta, parduota;
        input >> gauta >> parduota;
        nauja.Gauta = gauta;
        nauja.Parduota = parduota;

        prekes.push_back(nauja);

        input.ignore();
    }
}

void Spausdinti(ofstream& output, vector<Preke>& prekes)
{
    for (int i = 0; i < prekes.size(); i++)
    {
        output << prekes[i] << endl;
    }
}

void NaikintiPasikartojimus(vector<Preke>& prekes)
{
    for (int i = 0; i < prekes.size() - 1; i++)
    {
        for (int j = i + 1; j < prekes.size(); j++)
        {
            if (prekes[i] == prekes[j])
            {
                prekes[i] = prekes[i] + prekes[j];

                for (int k = j; k < prekes.size() - 1; k++)
                {
                    prekes[k] = prekes[k + 1];
                }
                prekes.resize(prekes.size() - 1);
                j--;
            }
        }
    }
}

void Rikiuoti(vector<Preke>& prekes)
{
    int i = 0;
    bool bk = true;

    while (bk)
    {
        bk = false;
        for (int j = prekes.size() - 1; j > i; j--)
        {
            if (prekes[j] <  prekes[j - 1])
            {
                bk = true;
                swap(prekes[j], prekes[j - 1]);
            }
        }
        i++;
    }
}

int PrekesIndeksas(vector<Preke>& prekes, Preke& preke)
{
    for (int i = 0; i < prekes.size(); i++)
    {
        if (prekes[i] == preke)
        {
            return i;
        }
    }

    return -1;
}

void PapildytiStandartinis(vector<Preke>& prekes1, vector<Preke>& prekes2)
{
    prekes1.insert(prekes1.end(), prekes2.begin(), prekes2.end());

    NaikintiPasikartojimus(prekes1);

    Rikiuoti(prekes1);
}

void Papildyti(vector<Preke>& prekes1, vector<Preke>& prekes2)
{
    for (int i = 0; i < prekes2.size(); i++)
    {
        int indeksas = PrekesIndeksas(prekes1, prekes2[i]);
        if (indeksas >= 0)
        {
            prekes1[indeksas] = prekes1[indeksas] + prekes2[i];
        }
        else
        {
            int k;
            for (k = 0; k < prekes1.size(); k++)
            {
                if (prekes1[k] > prekes2[i])
                {
                    break;
                }
            }
            k--;

            prekes1.push_back(Preke());
            for (int l = prekes1.size() - 1; l > k; l--)
            {
                prekes1[l] = prekes1[l - 1];
            }

            prekes1[k] = prekes2[i];
        }
    }

    NaikintiPasikartojimus(prekes1);

    Rikiuoti(prekes1);
}

void Salinti(vector<Preke>& prekes)
{
    int counter = 0;
    for (int i = 0; i < prekes.size(); i++)
    {
        if (prekes[i].Gauta == prekes[i].Parduota)
        {
            for (int j = i; j < prekes.size() - 1; j++)
            {
                prekes[j] = prekes[j + 1];
            }
            counter++;
            i--;
        }
    }

    prekes.resize(prekes.size() - counter);
}

int main()
{
    ifstream input("duom.txt");
    ofstream output("rez.txt");

    vector<Preke> prekes1;
    vector<Preke> prekes2;
    Skaityti(input, prekes1);
    Skaityti(input, prekes2);

    NaikintiPasikartojimus(prekes1);

    Papildyti(prekes1, prekes2);

    Salinti(prekes1);

    if (prekes1.size() > 0)
    {
        Spausdinti(output, prekes1);
    }
    else
    {
        output << "Sarasas tuscias" << endl;
    }

    input.close();
    output.close();

    return 0;
}
