#include <fstream>
#include <vector>

using namespace std;

struct Slidininkas {
    string vardas;
    int startoValanda, startoMinutes, startoSekundes;
    int finisoValanda, finisoMinutes, finisoSekundes;
    bool arFinisavo = false;

    Slidininkas() {}

    Slidininkas(string v, int val, int minut, int sek)
        : vardas(v), startoValanda(val), startoMinutes(minut), startoSekundes(sek) {}

    int SkaiciuotiMinutes() {
        int ret = finisoMinutes - startoMinutes;;
        if (finisoMinutes < startoMinutes) {
            ret += 60;
        }

        return ret;
    }

    int SkaiciuotiSekundes() {
        int ret = finisoSekundes - startoSekundes;;
        if (finisoSekundes < startoSekundes) {
            ret += 60;
        }

        return ret;
    }

    bool operator <(Slidininkas & other) {
        return (SkaiciuotiMinutes() < other.SkaiciuotiMinutes()
                || (SkaiciuotiMinutes() == other.SkaiciuotiMinutes()
                    && SkaiciuotiSekundes() < other.SkaiciuotiSekundes())
                || (SkaiciuotiMinutes() == other.SkaiciuotiMinutes() && SkaiciuotiSekundes() == other.SkaiciuotiSekundes()
                    && vardas < other.vardas)
                );
    }
};

void Skaityti(ifstream & input, vector<Slidininkas> & sl) {
    int n;
    input >> n;
    input.ignore();
    for (int i = 0; i < n; i++) {
        char eil[21];
        input.get(eil, 21);

        int val, minut, sek;
        input >> val >> minut >> sek;
        input.ignore();

        sl.push_back(Slidininkas(string(eil), val, minut, sek));
    }

    int m;
    input >> m;
    input.ignore();
    for (int i = 0; i < m; i++) {
        char eil[21];
        input.get(eil, 21);
        string vardas = string(eil);

        int val, minut, sek;
        input >> val >> minut >> sek;
        input.ignore();

        for (int j = 0; j < sl.size(); j++) {
            if (sl[j].vardas == vardas) {
                sl[j].arFinisavo = true;
                sl[j].finisoValanda = val;
                sl[j].finisoMinutes = minut;
                sl[j].finisoSekundes = sek;

                break;
            }
        }
    }

    // Salinima perkelti i atskira funkcija
    for (int i = 0; i < sl.size(); i++) {
        if (!sl[i].arFinisavo) {
            sl.erase(sl.begin() + i);
            i--;
        }
    }
}

void Rikiuoti(vector<Slidininkas> & sl) {
    int minIndex;
    for (int i = 0; i < sl.size() - 1; i++) {
        minIndex = i;
        for (int j = i + 1; j < sl.size(); j++) {
            if (sl[j] < sl[minIndex]) {
                minIndex = j;
            }
        }

        swap(sl[i], sl[minIndex]);
    }
}

void Spausdinti(ofstream & output, vector<Slidininkas> & sl) {
    for (int i = 0; i < sl.size(); i++) {
        if (sl[i].arFinisavo) {
            output << sl[i].vardas << " ";
            output << sl[i].SkaiciuotiMinutes() << " " << sl[i].SkaiciuotiSekundes() << endl;
        }
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    vector<Slidininkas> slidininkai;
    Skaityti(input, slidininkai);

    Rikiuoti(slidininkai);

    Spausdinti(output, slidininkai);

    input.close();
    output.close();
    return 0;
}
