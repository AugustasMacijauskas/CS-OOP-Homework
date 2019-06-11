#include <iostream>
#include <fstream>
#include <iomanip>

using namespace std;

struct Zvejys {
    string Vardas;
    int Karosu = 0, Karpiu = 0, Kuoju = 0;
};

Zvejys GeriausiasZvejas(int & n, Zvejys zvejai[]) {
    int geriausioKiekis = zvejai[0].Karosu + zvejai[0].Karpiu + zvejai[0].Kuoju;
    Zvejys geriausias = zvejai[0];

    for (int i = 1; i < n; i++) {
        int suma = zvejai[i].Karosu + zvejai[i].Karpiu + zvejai[i].Kuoju;
        if (suma > geriausioKiekis) {
            geriausias = zvejai[i];
            geriausioKiekis = suma;
        }
    }

    return geriausias;
}

void Skaityti(ifstream & input, int & n, Zvejys zvejai[]) {
    input >> n;
    input.ignore();

    for (int i = 0; i < n; i++) {
        char vard[11];
        input.get(vard, 11);
        zvejai[i].Vardas = vard;

        int dienuSkaicius;
        input >> dienuSkaicius;

        for (int j = 0; j < dienuSkaicius; j++) {
            int karosu, karpiu, kuoju;
            input >> karosu >> karpiu >> kuoju;
            zvejai[i].Karosu += karosu;
            zvejai[i].Karpiu += karpiu;
            zvejai[i].Kuoju += kuoju;
        }

                    input.ignore();
    }
}

void Spausdinti(ofstream & output, int & n, Zvejys zvejai[]) {
    for (int i = 0; i < n; i++) {
        output << setw(10) << zvejai[i].Vardas << setw(5) << zvejai[i].Karosu << setw(5) << zvejai[i].Karpiu << setw(5) << zvejai[i].Kuoju << endl;
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    int n;
    Zvejys zvejai[100];
    Skaityti(input, n, zvejai);

    Spausdinti(output, n, zvejai);
    Zvejys geriausias = GeriausiasZvejas(n, zvejai);
    output << setw(10) << geriausias.Vardas << setw(5) << geriausias.Karosu + geriausias.Karpiu + geriausias.Kuoju << endl;

    input.close();
    output.close();
    return 0;
}
