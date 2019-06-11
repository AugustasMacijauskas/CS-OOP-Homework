#include <fstream>
#include <iomanip>
#include <vector>
#include <cmath>
#include <algorithm>

using namespace std;

// Naudosime saugoti mokinio duomenims
struct Mokinys {
    string PavardeVardas;
    bool arVyras = true;
    vector<int> pazymiai;
    double Vidurkis = 0;

    Mokinys() {}

    bool operator <(Mokinys& other) {
        ((Vidurkis > other.Vidurkis)
         || (abs(Vidurkis - other.Vidurkis) <= 0.0001 && PavardeVardas < other.PavardeVardas));
    }
};

// Skaito duomenis is failo
void Skaityti(ifstream& input, vector<Mokinys>& mokiniai) {
    int n, m;
    input >> n >> m;
    input.ignore();

    char eil[21];
    for (int i = 0; i < n; i++) {
        Mokinys naujas;

        input.get(eil, 21);
        naujas.PavardeVardas = string(eil);

        string lytis;
        input >> lytis;
        if (lytis == "mot") {
            naujas.arVyras = false;
        }

        int x;
        for (int j = 0; j < m; j++) {
            input >> x;
            naujas.pazymiai.push_back(x);
            naujas.Vidurkis += x;
        }
        naujas.Vidurkis /= m; // Suskaiciuojame vidurki

        mokiniai.push_back(naujas);

        input.ignore();
    }
}

bool arVisiPazymiaiDidesni(vector<int>& pazymiai, int pazymys) {
    for (int i = 0; i < pazymiai.size(); i++) {
        if (pazymiai[i] < pazymys) {
            return false;
        }
    }

    return true;
}

void Atrinkti(vector<Mokinys> mokiniai, vector<Mokinys>& vaikinai, vector<Mokinys>& merginos) {
    double visuVidurkis = 0;
    for (int i = 0; i < mokiniai.size(); i++) {
        visuVidurkis += mokiniai[i].Vidurkis;
    }
    visuVidurkis /= mokiniai.size();

    for (int i = 0; i < mokiniai.size(); i++) {
        if (mokiniai[i].Vidurkis > visuVidurkis && arVisiPazymiaiDidesni(mokiniai[i].pazymiai, 8)) {
            if (mokiniai[i].arVyras) {
                vaikinai.push_back(mokiniai[i]);
            }
            else {
                merginos.push_back(mokiniai[i]);
            }
        }
    }

    sort(vaikinai.begin(), vaikinai.end());
    sort(merginos.begin(), merginos.end());
}

void Spausdinti(ofstream& output, vector<Mokinys> vaikinai, vector<Mokinys> merginos) {
    if (vaikinai.size() > 0) {
        for (int i = 0; i < vaikinai.size(); i++) {
            output << vaikinai[i].PavardeVardas;
            for (int j = 0; j < vaikinai[i].pazymiai.size(); j++) {
                output << setw(2) << vaikinai[i].pazymiai[j] << " ";
            }
            output << endl;
        }
    }

    if (vaikinai.size() > 0 && merginos.size() > 0) {
        for (int i = 0; i < 30; i++) {
            output << "=";
        }
        output << endl;
    }

    if (merginos.size() > 0) {
        for (int i = 0; i < merginos.size(); i++) {
            output << merginos[i].PavardeVardas;
            for (int j = 0; j < merginos[i].pazymiai.size(); j++) {
                output << setw(2) << merginos[i].pazymiai[j] << " ";
            }
            output << endl;
        }
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("uzd2_rez.txt");

    vector<Mokinys> mokiniai;
    Skaityti(input, mokiniai);

    vector<Mokinys> vaikinai, merginos;
    Atrinkti(mokiniai, vaikinai, merginos);

    Spausdinti(output, vaikinai, merginos);

    input.close();
    output.close();

    return 0;
}
