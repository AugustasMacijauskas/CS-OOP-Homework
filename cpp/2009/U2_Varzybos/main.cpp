#include <fstream>
#include <vector>
#include <algorithm>

using namespace std;

struct Sportininkas {
    string VardasPavarde;
    int Minutes, Sekundes;

    bool operator <(Sportininkas& other) {
        return ((Minutes < other.Minutes)
                || (Minutes == other.Minutes && Sekundes < other.Sekundes));
    }
};

struct Grupe {
    vector<Sportininkas> Sportininkai;
};

// Funkcija, skaitanti is failo
void Skaityti(ifstream& input, vector<Grupe>& grupes) {
    int n;
    input >> n;

    for (int i = 0; i < n; i++)
    {
        int x;
        input >> x;
        input.ignore();

        grupes.push_back(Grupe());

        for (int j = 0; j < x; j++) {
            Sportininkas naujas;
            char eil[21];
            input.get(eil, 21);
            naujas.VardasPavarde = string(eil);

            input >> naujas.Minutes >> naujas.Sekundes;
            input.ignore();

            grupes[i].Sportininkai.push_back(naujas);
        }
    }
}

vector<Sportininkas> Skaiciuoti(vector<Grupe>& grupes) {
    vector<Sportininkas> sportininkai;
    for (int i = 0; i < grupes.size(); i++) {
        sort(grupes[i].Sportininkai.begin(), grupes[i].Sportininkai.end());

        for (int j = 0; j < grupes[i].Sportininkai.size() / 2; j++) {
            sportininkai.push_back(grupes[i].Sportininkai[j]);
        }
    }

    sort(sportininkai.begin(), sportininkai.end());

    return sportininkai;
}

void Spausdinti(ofstream& output, vector<Sportininkas>& atsakymai) {
    for (int i = 0; i < atsakymai.size(); i++)
    {
        output << atsakymai[i].VardasPavarde << " "
               << atsakymai[i].Minutes << " " << atsakymai[i].Sekundes << endl;
    }
}

int main()
{
    ifstream input("U2.txt");
    ofstream output("U12ez.txt");

    vector<Grupe> grupes;
    Skaityti(input, grupes);

    vector<Sportininkas> atsakymai = Skaiciuoti(grupes);

    Spausdinti(output, atsakymai);

    input.close();
    output.close();

    return 0;
}
