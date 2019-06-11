#include <fstream>
#include <vector>

using namespace std;

struct Dievas {
    string Vardas;
    int KiekLyginiu;
    int Taskai;

    bool operator >(Dievas& other) {
        return ((Taskai > other.Taskai)
                || (Taskai == other.Taskai && KiekLyginiu > other.KiekLyginiu));
    }
};

// Uzklojame << operatoriu, kad galetume patogiai spausdinti Dievas tipo irasa
ostream& operator <<(ostream& stream, Dievas& dievas) {
    stream << dievas.Vardas << " " << dievas.Taskai;
    return stream;
}

// Funkcija skaitymui is failo
void Skaityti(ifstream& input, vector<Dievas>& dievai)
{
    int n, k;
    input >> n >> k;
    input.ignore();

    for (int i = 0; i < n; i++) {
        Dievas naujas;

        char eil[11];
        input.get(eil, 11);
        naujas.Vardas = string(eil);

        naujas.Taskai = 0;
        naujas.KiekLyginiu = 0;
        for (int j = 0; j < k; j++) {
            int x;
            input >> x;

            if (x % 2 == 0) {
                naujas.Taskai += x;
                naujas.KiekLyginiu++;
            }
            else {
                naujas.Taskai -= x;
            }
        }
        input.ignore();

        dievai.push_back(naujas);
    }
}

Dievas RastiValdova(vector<Dievas>& dievai) {
    Dievas valdovas = dievai[0];
    for (int i = 1; i < dievai.size(); i++) {
        if (dievai[i] > valdovas) { // Naudojame uzklota operatoriu
            valdovas = dievai[i];
        }
    }

    return valdovas;
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2Rez.txt");

    vector<Dievas> dievai;
    Skaityti(input, dievai);

    Dievas valdovas = RastiValdova(dievai);

    output << valdovas;

    input.close();
    output.close();

    return 0;
}
