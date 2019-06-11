#include <iostream>
#include <fstream>
#include <cmath>
#include <vector>

using namespace std;

struct Picerija {
    int x, y;
};

void Skaityti(ifstream & file, int & uzsakovuSkaicius, int & kilometruPlanas, vector<Picerija> & picerijos) {
    file >> uzsakovuSkaicius >> kilometruPlanas;

    for (int i = 0; i < uzsakovuSkaicius; i++) {
        int x, y;
        file >> x >> y;
        Picerija nauja;
        nauja.x = x;
        nauja.y = y;
        picerijos.push_back(nauja);
    }
}

void Spausdinti(ofstream & file, int neaptarnautu, int kilometru) {
    file << neaptarnautu << " " << kilometru;
}

int SkaiciuotiAtstuma(int x, int y) {
    return 2 * (abs(x) + abs(y));
}

void SkaiciuotiRezultatus(int & kiekLikoNeaptarnautu, int & kiekNuvaziuotaKilometru, int uzsakovuSkaicius, int kilometruPlanas, vector<Picerija> picerijos) {
    kiekLikoNeaptarnautu = uzsakovuSkaicius;
    kiekNuvaziuotaKilometru = 0;

    for (int i = 0; i < uzsakovuSkaicius; i++) {
        if (kiekNuvaziuotaKilometru <= kilometruPlanas) {
            kiekLikoNeaptarnautu--;
            kiekNuvaziuotaKilometru += SkaiciuotiAtstuma(picerijos[i].x, picerijos[i].y);
        }
        else {
            break;
        }
    }
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    int uzsakovuSkaicius, kilometruPlanas;
    vector<Picerija> picerijos;
    Skaityti(input, uzsakovuSkaicius, kilometruPlanas, picerijos);

    int kiekLikoNeaptarnautu, kiekNuvaziuotaKilometru;
    SkaiciuotiRezultatus(kiekLikoNeaptarnautu, kiekNuvaziuotaKilometru, uzsakovuSkaicius, kilometruPlanas, picerijos);

    Spausdinti(output, kiekLikoNeaptarnautu, kiekNuvaziuotaKilometru);

    input.close();
    output.close();

    return 0;
}
