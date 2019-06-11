#include <fstream>

using namespace std;

// Saugo langelio spalva
struct Spalva {
    int R, G, B;

    Spalva() {
        R = G = B = 255;
    }

    Spalva (int r, int g, int b) : R(r), G(g), B(b) {}
};

struct Staciakampis {
    int x, y;
    int dx, dy;
    Spalva spalva;
};

pair<int, int> UzdetiStaciakampi(Staciakampis & staciakampis, pair<int, int> ribos, Spalva piesinys[100][100]) {
    if (staciakampis.x + staciakampis.dx > ribos.first) {
        ribos.first = staciakampis.x + staciakampis.dx;
    }

    if (staciakampis.y + staciakampis.dy > ribos.second) {
        ribos.second = staciakampis.y + staciakampis.dy;
    }

    for (int i = staciakampis.x; i < staciakampis.x + staciakampis.dx; i++) {
        for (int j = staciakampis.y; j < staciakampis.y + staciakampis.dy; j++) {
            piesinys[i][j] = staciakampis.spalva;
        }
    }

    return ribos;
}

void Skaityti(ifstream & input, int & n, Staciakampis staciakampiai[]) {
    input >> n;

    for (int i = 0; i < n; i++) {
        input >> staciakampiai[i].y >> staciakampiai[i].x
              >> staciakampiai[i].dy >> staciakampiai[i].dx
              >> staciakampiai[i].spalva.R >> staciakampiai[i].spalva.G >> staciakampiai[i].spalva.B;
    }
}

void Spausdinti(ofstream & output,  pair<int, int> ribos, Spalva spalvos[100][100]) {
    output << ribos.first << " " << ribos.second << endl;
    for (int i = 0; i < ribos.first; i++) {
        for (int j = 0; j < ribos.second; j++) {
            output << spalvos[i][j].R << " " << spalvos[i][j].G << " " << spalvos[i][j].B << endl;
        }
    }
}

void Skaiciuoti(int n, Staciakampis staciakampiai[],  pair<int, int> & ribos, Spalva piesinys[100][100]) {
    for (int i = 0; i < n; i++) {
        ribos = UzdetiStaciakampi(staciakampiai[i], ribos, piesinys);
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    int n;
    Staciakampis staciakampiai[100];
    Skaityti(input, n, staciakampiai);

    pair<int, int> ribos(0, 0);
    Spalva piesinys[100][100];
    Skaiciuoti(n, staciakampiai, ribos, piesinys);
    Spausdinti(output, ribos, piesinys);

    input.close();
    output.close();

    return 0;
}
