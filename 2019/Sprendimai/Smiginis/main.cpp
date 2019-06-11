#include <iostream>
#include <fstream>>

using namespace std;

int lenta[1000][1000];

int main()
{

    ifstream cin("smiginis-vyr.in");
    ofstream cout("smiginis-vyr.out");
    int n, l;

    cin >> n;
    cin >> l;

    int lenta[n][n];

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cin >> lenta[i][j];
        }
    }

    int x = 1, y = 1, tempSum = 0;

    int sum = 0;

    for (int i = 0; i < n; i++) {
        sum = 0;
        for (int k = i - l; k <= i + l; k++) {
            for (int m = 0; m <= l; m++) {
                if (k > -1 && k < n) {
                    sum += lenta[k][m];
                }
            }
        }

        if (tempSum < sum) {
            tempSum = sum;
            x = i;
            y = 0;
        }

        for (int j = 1; j < n; j++) {
            for (int k = i - l; k <= i + l; k++) {
                if (k < 0 || k >= n)
                    continue;

                if (j + l < n) {
                    sum += lenta[k][j + l];
                }

                if (j - l - 1 > -1) {
                    sum -= lenta[k][j - l - 1];
                }
            }

            if (tempSum < sum) {
                tempSum = sum;
                x = i;
                y = j;
            }
        }
    }

    cout << y + 1 << " " << x + 1 << endl;

    return 0;
}
