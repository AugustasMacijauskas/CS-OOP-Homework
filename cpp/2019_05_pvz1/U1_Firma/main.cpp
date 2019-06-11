#include <fstream>
#include <iomanip>

using namespace std;

// Saugome darbuotoja
struct Darbuotoja {
    string Vardas;
    int Pirstiniu = 0, Saliku = 0, Kepuraiciu = 0;
    double Suma = 0;

    Darbuotoja() {}
};

void Skaityti(ifstream& input, int& n, Darbuotoja darbuotojos[],
              double& pirstiniuKaina, double& salikoKaina, double& kepuraitesKaina) {
    input >> n;
    input >> pirstiniuKaina >> salikoKaina >> kepuraitesKaina;
    input.ignore();

    char eil[16];
    for (int i = 0; i < n; i++) {
        input.get(eil, 16);
        darbuotojos[i].Vardas = string(eil);

        int d;
        input >> d;
        int x, y, z;
        for (int j = 0; j < d; j++) {
            input >> x >> y >> z;
            darbuotojos[i].Pirstiniu += x;
            darbuotojos[i].Saliku += y;
            darbuotojos[i].Kepuraiciu += z;
        }

        input.ignore();
    }
}

int GeriausiosDarbuotojosIndeksas(int n, Darbuotoja darbuotojos[]) {
    int indeksas = 0;
    for (int i = 1; i < n; i++) {
        if (darbuotojos[i].Suma > darbuotojos[indeksas].Suma) {
            indeksas = i;
        }
    }

    return indeksas;
}

void Skaiciuoti(int n, Darbuotoja darbuotojos[],
                double pirstiniuKaina, double salikoKaina, double kepuraitesKaina,
                int& visoPirstiniu, int& visoSaliku, int& visoKepuraiciu) {
    visoPirstiniu = visoSaliku = visoKepuraiciu = 0;

    for (int i = 0; i < n; i++) {
        darbuotojos[i].Suma = darbuotojos[i].Pirstiniu * pirstiniuKaina +
                              darbuotojos[i].Saliku * salikoKaina +
                              darbuotojos[i].Kepuraiciu * kepuraitesKaina;

        visoPirstiniu += darbuotojos[i].Pirstiniu;
        visoSaliku += darbuotojos[i].Saliku;
        visoKepuraiciu += darbuotojos[i].Kepuraiciu;
    }
}

void Spausdinti(ofstream& output, int n, Darbuotoja darbuotojos[], int geriausiosDarbuotojosIndeksas,
                int visoPirstiniu, int visoSaliku, int visoKepuraiciu) {
    for (int i = 0; i < n; i++) {
        output << darbuotojos[i].Vardas
               << setw(6) << darbuotojos[i].Pirstiniu
               << setw(6) << darbuotojos[i].Saliku
               << setw(6) << darbuotojos[i].Kepuraiciu
               << fixed << setw(8) << setprecision(2) << darbuotojos[i].Suma << endl;
    }

    output << setw(6) << visoPirstiniu
           << setw(6) << visoSaliku
           << setw(6) << visoKepuraiciu << endl;

    output << darbuotojos[geriausiosDarbuotojosIndeksas].Vardas
           << fixed << setw(8) << setprecision(2) << darbuotojos[geriausiosDarbuotojosIndeksas].Suma;
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    int n; // Darbuotoju kiekis
    Darbuotoja darbuotojos[101];
    double pirstiniuKaina, salikoKaina, kepuraitesKaina;
    Skaityti(input, n, darbuotojos, pirstiniuKaina, salikoKaina, kepuraitesKaina);

    int visoPirstiniu, visoSaliku, visoKepuraiciu;
    Skaiciuoti(n, darbuotojos, pirstiniuKaina, salikoKaina,
               kepuraitesKaina, visoPirstiniu, visoSaliku, visoKepuraiciu);

    int geriausiosDarbuotojosIndeksas = GeriausiosDarbuotojosIndeksas(n, darbuotojos);

    Spausdinti(output, n, darbuotojos, geriausiosDarbuotojosIndeksas, visoPirstiniu, visoSaliku, visoKepuraiciu);

    input.close();
    output.close();

    return 0;
}
