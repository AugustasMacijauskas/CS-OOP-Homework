/* input
4
4 1 1 2 1 4 4 5
2 1 3 4 6 4 7 1
6 4 6 1 3 1 3 4
4 1 2 3 4 5 6 3

*/
#include <bits/stdc++.h>

using namespace std;

struct Point {
    int x, y;

    Point() {}

    Point(int x, int y) : x(x), y(y) {}

    double Length() {
        return sqrt(pow(x, 2) + pow(y, 2));
    }

    Point operator -(Point other) {
        Point naujas(x - other.x, y - other.y);
        return naujas;
    }

    // Vektorine
    int operator *(Point other) {
        return x * other.y - y * other.x;
    }
};

struct Keturkampis {
    Point A, B, C, D;
    Point AB, BC, CD, AD;

    Keturkampis() {}

    Keturkampis(Point A, Point B, Point C, Point D) : A(A), B(B), C(C), D(D) {
        AB = B - A;
        BC = C - B;
        CD = D - C;
        AD = D - A;
    }

    double sinA() {
        // A yra kairej apacioj pagal salyga, uzsiknisau daryt visus tikrinimus xdd
        return (abs(AB * AD)) / (AB.Length() * AD.Length());
    }

    bool arStaciakampis() {
        if (abs(1 - sinA()) < 0.000001) {
            return true;
        }

        return false;
    }

    double Plotas() {
        double plotas;
        if (arStaciakampis()) {
            plotas = AB.Length() * AD.Length();
        }
        else {
            double aukstine = AB.Length() * sinA();
            plotas = (AD.Length() + BC.Length()) / 2 * aukstine;
        }

        return plotas;
    }
};

void Skaityti(vector<Keturkampis> &figuros, int N) {
    for (int i = 0; i < N; i++) {
        int x1, y1, x2, y2, x3, y3, x4, y4;
        cin >> x1 >> y1 >> x2 >> y2 >> x3 >> y3 >> x4 >> y4;
        Point A(x1, y1);
        Point B(x2, y2);
        Point C(x3, y3);
        Point D(x4, y4);
        Keturkampis naujaFigura(A, B, C, D);
        figuros.push_back(naujaFigura);
    }
}

void Skaiciuoti(vector<Keturkampis> &figuros, int N, int &didStacInd, int &didTrapInd) {
    double didStac = -1, didTrap = -1;

    for (int i = 0; i < N; i++) {
        Keturkampis curr = figuros[i];
        double plotas = curr.Plotas();

        cout << i + 1;
        if (curr.arStaciakampis()) {
            cout << " - Staciakampis   ";
            printf("%.2f\n", plotas);

            if (plotas > didStac) {
                didStac = plotas;
                didStacInd = i + 1;
            }
        }
        else {
            cout << " - Lygiasone tr.   ";
            printf("%.2f\n", plotas);

            if (plotas > didTrap) {
                didTrap = plotas;
                didTrapInd = i + 1;
            }
        }
    }
}

void Spausdinti(int didStacInd, int didTrapInd) {
    if (didTrapInd != -1) {
        cout << "Didziausia lygiasone tr. - " << didTrapInd << "\n";
    }
    else {
        cout << "Didziausio staciakampio nera!" << "\n";
    }

    if (didStacInd != -1) {
        cout << "Didziausia staciakampis - " << didStacInd << "\n";
    }
    else {
        cout << "Didziausio staciakampio nera!" << "\n";
    }
}

int main()
{
    int N;
    cin >> N;
    vector<Keturkampis> figuros;
    Skaityti(figuros, N);
    int didStacInd = -1, didTrapInd = -1;
    Skaiciuoti(figuros, N, didStacInd, didTrapInd);
    Spausdinti(didStacInd, didTrapInd);
    return 0;
}
