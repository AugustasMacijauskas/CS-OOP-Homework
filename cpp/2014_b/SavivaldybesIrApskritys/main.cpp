#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <cmath>
#include <iomanip>

using namespace std;

struct Apskritis {
    string Pavadinimas;
    int SavivaldybiuSkaicius = 0;
    int KiekDaugiausiaMokyklu = 0;

    bool operator < (Apskritis & other) {
        return (KiekDaugiausiaMokyklu > other.KiekDaugiausiaMokyklu) || (KiekDaugiausiaMokyklu == other.KiekDaugiausiaMokyklu && Pavadinimas < other.Pavadinimas);
    }
};

struct Savivaldybe {
    string Pavadinimas;
    int MokykluSkaicius;
    string Apskritis;

    Savivaldybe() {}

    Savivaldybe(string pav, int sk, string apsk)
        : Pavadinimas(pav), MokykluSkaicius(sk), Apskritis(apsk) { }
};

// Uzklojame << operatoriu, kad butu patogiau spausdinti:
ostream& operator <<(ostream & stream, Apskritis ob) {
    stream << left << setw(13) << ob.Pavadinimas << " " << ob.SavivaldybiuSkaicius << " " << ob.KiekDaugiausiaMokyklu << endl;
    return stream;
}

// Procedura duomenims skaityti:
void Skaityti(ifstream & file, int & savivaldybiuSkaicius, Savivaldybe savivaldybes[]) {
    file >> savivaldybiuSkaicius;
    file.ignore();

    for (int i = 0; i < savivaldybiuSkaicius; i++) {
        char pav[21];
        file.get(pav, 21);

        int x;
        file >> x;
        file.ignore();

        char apskr[14];
        file.get(apskr, 14);
        file.ignore();

        savivaldybes[i] = Savivaldybe(pav, x, apskr);
    }
}

void Spausdinti(ofstream  & file, int apskriciuSkaicius, Apskritis apskritys[]) {
    file << apskriciuSkaicius << endl;
    for (int i = 0; i < apskriciuSkaicius; i++) {
        file << apskritys[i];
        //file << left << setw(13) << apskritys[i].Pavadinimas << " " << apskritys[i].SavivaldybiuSkaicius << " " << apskritys[i].KiekDaugiausiaMokyklu << endl;
    }
}

// Suranda kiek yra skirtingu apskriciu ir grazina ju masyva:
void RastiApskritis(int savivaldybiuSkaicius, Savivaldybe savivaldybes[], int & apskriciuSkaicius, Apskritis apskritys[]) {
    vector<string> pavadinimai;

    apskriciuSkaicius = 0;
    for (int i = 0; i < savivaldybiuSkaicius; i++) {
        if (count(pavadinimai.begin(), pavadinimai.end(), savivaldybes[i].Apskritis) == 0) {
            pavadinimai.push_back(savivaldybes[i].Apskritis);
            Apskritis nauja;
            nauja.Pavadinimas = savivaldybes[i].Apskritis;
            apskritys[apskriciuSkaicius++] = nauja;
        }
    }
}

void Skaiciuoti(int savivaldybiuSkaicius, Savivaldybe savivaldybes[], int apskriciuSkaicius, Apskritis apskritys[]) {
    for (int i = 0; i < apskriciuSkaicius; i++) {
        for (int j = 0; j < savivaldybiuSkaicius; j++) {
            if (savivaldybes[j].Apskritis == apskritys[i].Pavadinimas) {
                apskritys[i].SavivaldybiuSkaicius++;
                apskritys[i].KiekDaugiausiaMokyklu = max(savivaldybes[j].MokykluSkaicius, apskritys[i].KiekDaugiausiaMokyklu);
            }
        }
    }

    sort(apskritys, apskritys + apskriciuSkaicius);
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U2rez.txt");

    int savivaldybiuSkaicius;
    Savivaldybe savivaldybes[60];
    Skaityti(input, savivaldybiuSkaicius, savivaldybes);

    int apskriciuSkaicius;
    Apskritis apskritys[10];
    RastiApskritis(savivaldybiuSkaicius, savivaldybes, apskriciuSkaicius, apskritys);

    Skaiciuoti(savivaldybiuSkaicius, savivaldybes, apskriciuSkaicius, apskritys);

    Spausdinti(output, apskriciuSkaicius, apskritys);

    input.close();
    output.close();

    return 0;
}
