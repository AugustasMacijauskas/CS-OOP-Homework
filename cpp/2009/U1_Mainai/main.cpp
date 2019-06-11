#include <fstream>
#include <vector>
#include <numeric>

using namespace std;

void Skaityti(ifstream& input, vector<int>& nominalai, vector<int>& monetos) {
    int n;
    input >> n;

    int x;
    for (int i = 0; i < n; i++)
    {
        input >> x;
        nominalai.push_back(x);
    }
    for (int i = 0; i < n; i++)
    {
        input >> x;
        monetos.push_back(x);
    }
}

// Funkcija, surandanti norima iskeisti suma
int Suma(int n, vector<int>& nominalai, vector<int>& monetos) {
    int suma = 0;
    for (int i = 0; i < n; i++)
    {
        suma += nominalai[i] * monetos[i];
    }

    return suma;
}

// Funkcija, atliekanti skaiciavimus ir grazinanti masyva, sauganti kiek kokiu monetu bus gauta keiciantis
vector<int> Skaiciuoti(vector<int>& nominalai, vector<int>& monetos, vector<int>& kitiNominalai) {
    int suma = Suma(nominalai.size(), nominalai, monetos);

    vector<int> atsakymai(kitiNominalai.size(), 0);
    for (int i = 0; i < kitiNominalai.size(); i++)
    {
        atsakymai[i] = suma / kitiNominalai[i];
        suma -= atsakymai[i] * kitiNominalai[i];
    }

    if (suma != 0)
    {
        throw invalid_argument("Neimanoma iskeisti");
    }

    return atsakymai;
}

vector<int> SkaiciuotiDinamiskai(vector<int>& nominalai, vector<int>& monetos, vector<int>& kitiNominalai)
{
    int suma = Suma(nominalai.size(), nominalai, monetos);

    vector<int> sumos(suma + 1 + kitiNominalai[0], 1e9);
    vector<int> pagalbinis(suma + 1 + kitiNominalai[0], 0);
    sumos[0] = 0;
    for (int i = 0; i < kitiNominalai.size(); i++) {
        int verte = kitiNominalai[i];
        for (int j = 0; j < suma; j++)
        {
            if (sumos[j] > suma)
            {
                continue;
            }

            if (sumos[j + verte] > sumos[j] + 1) {
                sumos[j + verte] = sumos[j] + 1;
                pagalbinis[j + verte] = i;
            }
        }
    }

    if (sumos[suma] > suma)
    {
        throw invalid_argument("Neimanoma iskeisti dinaminis");
    }

    vector<int> atsakymai(kitiNominalai.size(), 0);
    while (suma > 0) {
        int i = pagalbinis[suma];
        suma -= kitiNominalai[i];
        atsakymai[i]++;
    }

    return atsakymai;
}

void Spausdinti(ofstream& output, vector<int>& nominalai, vector<int>& atsakymai) {
    for (int i = 0; i < atsakymai.size(); i++)
    {
        output << nominalai[i] << " " << atsakymai[i] << endl;
    }

    output << accumulate(atsakymai.begin(), atsakymai.end(), 0) << endl;
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    vector<int> gilijosNominalai, gilijosMonetos, eglijosNominalai, eglijosMonetos;
    Skaityti(input, gilijosNominalai, gilijosMonetos);
    Skaityti(input, eglijosNominalai, eglijosMonetos);

    vector<int> eglijosAtsakymai = SkaiciuotiDinamiskai(gilijosNominalai, gilijosMonetos, eglijosNominalai);
    vector<int> gilijosAtsakymai = SkaiciuotiDinamiskai(eglijosNominalai, eglijosMonetos, gilijosNominalai);

    Spausdinti(output, eglijosNominalai, eglijosAtsakymai);
    Spausdinti(output, gilijosNominalai, gilijosAtsakymai);

    input.close();
    output.close();

    return 0;
}
