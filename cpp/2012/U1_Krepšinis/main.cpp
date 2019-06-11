#include <fstream>
#include <vector>
#include <algorithm>
#include <numeric>

using namespace std;

struct Krepsininkas {
    int Numeris;
    vector<int> Laikai;
    int ZaidimoLaikas;

    bool operator <(Krepsininkas& other) {
        return (Numeris < other.Numeris);
    }
};

// Uzklojame << operatoriu, kad galetume patogiai spausdinti Krepsininkas tipo irasa
ostream& operator <<(ostream& stream, Krepsininkas& krepsininkas) {
    stream << krepsininkas.Numeris << " " << krepsininkas.ZaidimoLaikas;
    return stream;
}

// Funkcija duomenu skaitymui is failo
void Skaityti(ifstream& input, vector<Krepsininkas>& krepsininkai)
{
    int n;
    input >> n;

    for (int i = 0; i < n; i++) {
        Krepsininkas naujas;
        input >> naujas.Numeris;

        int x;
        input >> x;
        naujas.Laikai = vector<int>(x);
        for (int j = 0; j < x; j++) {
            input >> naujas.Laikai[j];
        }
        naujas.ZaidimoLaikas = 0;
        for (int j = 0; j < naujas.Laikai.size(); j++) {
            if (naujas.Laikai[j] > 0) {
                naujas.ZaidimoLaikas += naujas.Laikai[j];
            }
        }

        krepsininkai.push_back(naujas);
    }
}

int MaziausioIndeksas(vector<Krepsininkas>& krepsininkai) {
    int maziausioIndeksas = 0;
    for (int i = 1; i < krepsininkai.size(); i++) {
        if (krepsininkai[i].ZaidimoLaikas < krepsininkai[maziausioIndeksas].ZaidimoLaikas) {
            maziausioIndeksas = i;
        }
    }

    return maziausioIndeksas;
}

int DidziausioIndeksas(vector<Krepsininkas>& krepsininkai) {
    int didziausioIndeksas = 0;
    for (int i = 1; i < krepsininkai.size(); i++) {
        if (krepsininkai[i].ZaidimoLaikas > krepsininkai[didziausioIndeksas].ZaidimoLaikas) {
            didziausioIndeksas = i;
        }
    }

    return didziausioIndeksas;
}

vector<int> Skaiciuoti(vector<Krepsininkas>& krepsininkai) {
    vector<int> penketukas;
    for (int i = 0; i < krepsininkai.size(); i++) {
        if (krepsininkai[i].Laikai[0] > 0) {
            penketukas.push_back(krepsininkai[i].Numeris);
        }
    }

    return penketukas;
}

void Spausdinti(ofstream& output, vector<int>& startinisPenketukas,
                Krepsininkas maziausias, Krepsininkas didziausias)
{
    for (int i = 0; i < startinisPenketukas.size(); i++) {
        output << startinisPenketukas[i] << " ";
    }
    output << endl;
    output << didziausias << endl;
    output << maziausias.Numeris << " " << 40 - maziausias.ZaidimoLaikas;
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1Rez.txt");

    vector<Krepsininkas> krepsininkai;
    Skaityti(input, krepsininkai);
    sort(krepsininkai.begin(), krepsininkai.end());

    vector<int> startinisPenketukas = Skaiciuoti(krepsininkai);

    Spausdinti(output, startinisPenketukas,
               krepsininkai[MaziausioIndeksas(krepsininkai)], krepsininkai[DidziausioIndeksas(krepsininkai)]);

    input.close();
    output.close();

    return 0;
}
