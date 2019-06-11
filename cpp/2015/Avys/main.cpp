#include <fstream>

using namespace std;

struct Avis {
    string vardas;
    string DNR;
    int sutapimoKoeficientas = 0;

    Avis() {}

    Avis(string v, string dnr)
        :vardas(v), DNR(dnr) {}

    bool operator <(Avis & other) {
        return (sutapimoKoeficientas > other.sutapimoKoeficientas
                || (sutapimoKoeficientas == other.sutapimoKoeficientas && vardas < other.vardas));
    }
};

int SutapimoKoeficientas(int ilgis, Avis & tiriamoji, Avis & avis) {
    int sutapimas = 0;
    for (int i = 0; i < ilgis; i++) {
        if (avis.DNR[i] == tiriamoji.DNR[i]) {
            sutapimas++;
        }
    }

    return sutapimas;
}

void Rikiuoti(int n, Avis avys[]) {
    int minIndex;
    for (int i = 0; i < n - 1; i++) {
        minIndex = i;

        for (int j = i + 1; j < n; j++) {
            if (avys[j] < avys[minIndex]) {
                minIndex = j;
            }
        }

        swap(avys[i], avys[minIndex]);
    }
}

void Skaityti(ifstream & input, int & n, int & DNR_ilgis, Avis & tiriamojiAvis, Avis avys[]) {
    input >> n >> DNR_ilgis;

    int tiriamosiosAviesNumeris;
    input >> tiriamosiosAviesNumeris;

    char eil[11];
    string DNR;
    int m = 0;
    for (int i = 0; i < n; i++) {
        input.ignore();

        input.get(eil, 11);
        string pavadinimas = string(eil);

        input >> DNR;

        if (i != tiriamosiosAviesNumeris - 1) {
            avys[m++] = Avis(pavadinimas, DNR);
        }
        else {
            tiriamojiAvis = Avis(pavadinimas, DNR);
        }
    }

    n = m;
}

void Skaiciuoti(Avis tiriamojiAvis, int DNR_ilgis, int n, Avis avys[]) {
    for (int i = 0; i < n; i++) {
        avys[i].sutapimoKoeficientas = SutapimoKoeficientas(DNR_ilgis, tiriamojiAvis, avys[i]);
    }
}

void Spausdinti(ofstream & output, Avis tiriamojiAvis, int n, Avis avys[]) {
    output << tiriamojiAvis.vardas << endl;
    for (int i = 0; i < n; i++) {
        output << avys[i].vardas << " " << avys[i].sutapimoKoeficientas << endl;
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    Avis tiriamojiAvis;
    Avis avys[20];
    int n, DNR_ilgis;
    Skaityti(input, n, DNR_ilgis, tiriamojiAvis, avys);

    Skaiciuoti(tiriamojiAvis, DNR_ilgis, n, avys);

    Rikiuoti(n, avys);

    Spausdinti(output, tiriamojiAvis, n, avys);

    input.close();
    output.close();

    return 0;
}
