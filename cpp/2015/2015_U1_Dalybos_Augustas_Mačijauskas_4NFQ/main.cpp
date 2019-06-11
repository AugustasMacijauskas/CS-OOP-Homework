#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

void Skaityti(ifstream &input, vector<int> &dubeneliai, vector<int> &zmones) {
    for (int i = 0; i < 10; i++) {
        int x;
        input >> x;
        zmones[i] = x;
        dubeneliai[i] = 10 - zmones[i];
    }

    input.close();
}

void Spausdinti(ofstream &output, vector<int> &dubeneliai, vector<int> &zmones) {
    for (int i = 0; i < 20; i++) {
        output << zmones[i] << " ";
    }
}

void kiekSuvalge(vector<int> &dubeneliai, vector<int> &zmones) {
    for (int i = 0; i < 10; i++) {
        for (int j = i + 1; j <= i + 10 && j < 20; j++) {
            if (dubeneliai[i] == 0) {
                break;
            }

            zmones[j]++;
            dubeneliai[i]--;
        }
    }
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    vector<int> dubeneliai(10);
    vector<int> zmones(20, 0);
    Skaityti(input, dubeneliai, zmones);
    kiekSuvalge(dubeneliai, zmones);
    Spausdinti(output, dubeneliai, zmones);

    return 0;
}
