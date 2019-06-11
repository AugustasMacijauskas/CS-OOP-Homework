#include <fstream>
#include <vector>
#include <set>

using namespace std;

struct Pratimas {
    string pavadinimas;
    int kiekis;

    Pratimas() {}

    Pratimas(string pav, int kiek)
        : pavadinimas(pav), kiekis(kiek) {}

    bool operator <(Pratimas & other) {
        return (kiekis > other.kiekis
                || (kiekis == other.kiekis && pavadinimas < other.pavadinimas));
    }
};

struct Vytautas {
    vector<Pratimas> pratimai;
};

void Rikiuoti(vector<Pratimas> & pratimai) {
    int minIndex;
    for (int i = 0; i < pratimai.size() - 1; i++) {
        minIndex = i;

        for (int j = i + 1; j < pratimai.size(); j++) {
            if (pratimai[j] < pratimai[minIndex]) {
                minIndex = j;
            }
        }

        swap(pratimai[i], pratimai[minIndex]);
    }
}

void Skaityti(ifstream & input, vector<Pratimas> & pratimai) {
    int n;
    input >> n;
    input.ignore();

    char eil[21];
    int x;
    set<string> pratimuPavadinimai;
    for (int i = 0; i < n; i++) {
        input.get(eil, 21);
        string pavadinimas = string(eil);

        input >> x;
        input.ignore();

        if (pratimuPavadinimai.count(pavadinimas) == 0) {
            pratimuPavadinimai.insert(pavadinimas);
            pratimai.push_back(Pratimas(pavadinimas, x));
        }
        else {
            for (int j = 0; j < pratimai.size(); j++) {
                if (pratimai[j].pavadinimas == pavadinimas) {
                    pratimai[j].kiekis += x;

                    break;
                }
            }
        }
    }
}

void Spausdinti(ofstream & output, vector<Pratimas> & pratimai) {
    for (int i = 0; i < pratimai.size(); i++) {
        output << pratimai[i].pavadinimas << " " << pratimai[i].kiekis << endl;
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    Vytautas vytautas;

    Skaityti(input, vytautas.pratimai);

    Rikiuoti(vytautas.pratimai);

    Spausdinti(output, vytautas.pratimai);

    input.close();
    output.close();

    return 0;
}
