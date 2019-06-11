#include <bits/stdc++.h>

using namespace std;

int main()
{
    int n;
    char k;
    ifstream input("kaladeles-vyr.in");
    ofstream output("kaladeles-vyr.out");
    map<char, int> kiekSpalvos;
    deque<char> spalvos;

    input >> n;
    for (int i = 0; i < n; i++) {
        input >> k;
        if (kiekSpalvos.count(k) == 0) {
            kiekSpalvos[k] = 1;
            spalvos.push_back(k);
        }
        else {
            kiekSpalvos[k]++;
        }
    }

    char maxRaide;
    int maxKiekis = 0;
    for (auto it = kiekSpalvos.cbegin(); it != kiekSpalvos.end(); ++it) {
        if (maxKiekis < it->second) {
            maxRaide = it->first;
            maxKiekis = it->second;
        }
    }

    int suma = 0;
    for (auto it = kiekSpalvos.cbegin(); it != kiekSpalvos.end(); ++it) {
        if (it->first != maxRaide) {
            suma += it->second;
        }
    }

    char paskutineRaide = ' ';
    int index = 0;
    if (maxKiekis - 1 > suma) {
        output << "NE" << endl;
    }
    else {
        for (int i = 0; i < n; i++) {
            if (paskutineRaide == maxRaide || kiekSpalvos[maxRaide] == 0) {
                if (kiekSpalvos[spalvos[index]] == 0) {
                    index++;
                }
                if (spalvos[index] == maxRaide) {
                    index++;
                }
                output << spalvos[index] << " ";
                paskutineRaide = spalvos[index];
                kiekSpalvos[spalvos[index]]--;
            }
            else {
                output << maxRaide << " ";
                paskutineRaide = maxRaide;
                kiekSpalvos[maxRaide]--;
            }
        }
    }

    input.close();
    output.close();
    return 0;
}
