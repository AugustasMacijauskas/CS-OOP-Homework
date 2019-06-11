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

    for (auto it = kiekSpalvos.cbegin(); it != kiekSpalvos.end(); ++it) {
        cout << it->first << " : " << it->second << endl;
    }

    for (int i = 0; i != spalvos.size(); i++) {
        cout << spalvos[i] << " ";
    }
    cout << endl;

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
                cout << "index: " << index << endl;
                cout << spalvos[index] << " " << endl;
                output << spalvos[index] << " ";
                paskutineRaide = spalvos[index];
                kiekSpalvos[spalvos[index]]--;
            }
            else {
                // cout << maxRaide << " " << endl
                output << maxRaide << " ";
                paskutineRaide = maxRaide;
                kiekSpalvos[maxRaide]--;
            }
        }
    }

    cout << endl;
    for (auto it = kiekSpalvos.cbegin(); it != kiekSpalvos.end(); ++it) {
        cout << it->first << " : " << it->second << endl;
    }

    input.close();
    output.close();
    return 0;
}
