#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

void Skaityti(ifstream & file, int & n, int lytis[], int koja[], int dydis[]) {
    file >> n;

    for (int i = 0; i < n; i++) {
        file >> lytis[i] >> koja[i] >> dydis[i];
    }
}

void SkaiciuotiPoras(int & n, int lytis[], int koja[], int dydis[], int & vyrisku, int & moterisku) {
    vector<bool> panaudoti(n, false);

    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            if (!panaudoti[i] && !panaudoti[j] && lytis[i] == lytis[j] && koja[i] != koja[j] && dydis[i] == dydis[j]) {
                panaudoti[i] = true;
                panaudoti[j] = true;

                if (lytis[i] == 3) {
                    moterisku++;
                }
                else {
                    vyrisku++;
                }

                break;
            }
        }
    }
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    int n;
    int lytis[100], koja[100], dydis[100];
    Skaityti(input, n, lytis, koja, dydis);

    int vyrisku = 0, moterisku = 0;
    SkaiciuotiPoras(n, lytis, koja, dydis, vyrisku, moterisku);
    output << vyrisku << "\n" << moterisku;

    input.close();
    output.close();
    return 0;
}
