// graza-vyr

#include <bits/stdc++.h>

using namespace std;

int main()
{
    int n, t;
    ifstream input("graza-vyr.in");
    ofstream output("graza-vyr.out");

    int banknotai[] = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };
    int kiekBanknotu[1025];

    for (int i = 0; i < 11; i++) {
        kiekBanknotu[banknotai[i]] = 0;
    }

    input >> n;
    for (int i = 0; i < n; i++) {
        input >> t;

        if (t < 0) {
            t = abs(t);
            for (int i = 10; i >= 0; i--) {
                if (t >= banknotai[i] && kiekBanknotu[banknotai[i]] > 0) {
                    int kiekTelpa = t / banknotai[i];
                    while (kiekTelpa && kiekBanknotu[banknotai[i]] > 0) {
                            output << banknotai[i];
                            kiekBanknotu[banknotai[i]]--;
                            t -= banknotai[i];
                            kiekTelpa--;
                            if (t != 0) {
                                output << " ";
                            }
                            else {
                                output << endl;
                            }
                    }
                }
            }
        }
        else {
            kiekBanknotu[t]++;
        }
    }

    input.close();
    output.close();
    return 0;
}
