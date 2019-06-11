#include <bits/stdc++.h>

using namespace std;

int main()
{
    int kiekZiurovu, x, pirmasis;

    ifstream input("koncertas.in");
    ofstream output("koncertas.out");

    // Index, zmogaus numeris
    map<int, int> vietos;

    input >> kiekZiurovu;
    input >> pirmasis;
    int kiek = 0;
    if (pirmasis != 0) {
        vietos.insert(make_pair(0, pirmasis));
        for (int i = 1; i < kiekZiurovu; i++) {
            input >> x;
            if (x != (i + 1)) {
                vietos.insert(make_pair(i, x));
            }
        }

        int ind = 0;
        while(vietos[ind] != 0) {
            kiek++;
            ind = vietos[ind] - 1;
        }
    }

    output << kiek << endl;

    return 0;
}
