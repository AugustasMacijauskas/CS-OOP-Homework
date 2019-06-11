#include <bits/stdc++.h>

using namespace std;

void input(ifstream &in, vector<int> &nominalai, vector<int> &kiekiai)
{
    int n;
    in >> n;
    nominalai = vector<int>(n);
    kiekiai = vector<int>(n);
    for (int i = 0; i < n; i++)
        in >> nominalai[i];
    for (int i = 0; i < n; i++)
        in >> kiekiai[i];
}

int suma(vector<int> nominalai, vector<int> kiekiai)
{
    if (nominalai.size() != kiekiai.size())
        throw invalid_argument("Nesutampa kiekiai");
    int s = 0;
    for (int i = 0; i < nominalai.size(); i++)
        s += nominalai[i] * kiekiai[i];
    return s;
}

vector<int> skaiciavimas(vector<int> &nominalai, vector<int> &kiekiai, vector<int> &kitiNominalai)
{
    int s = suma(nominalai, kiekiai);
    vector<int> D(s + 1 + kitiNominalai[0], -1);
    D[0] = 0;
    for (int i = 0; i < s; i++)
    {
        if (D[i] == -1)
            continue;
        for (auto verte: kitiNominalai)
        {
            if (D[i + verte] == -1 || D[i + verte] > D[i] + 1)
                D[i + verte] = D[i] + 1;
        }
    }

    vector<int> kitiKiekiai(kitiNominalai.size(), 0);
    if (D[s] == 0)
        return kitiKiekiai;

    while (s > 0)
    {
        for (int i = 0; i < kitiNominalai.size(); i++)
        {
            if (D[s] == D[s - kitiNominalai[i]] + 1)
            {
                s -= kitiNominalai[i];
                kitiKiekiai[i]++;
                continue;
            }
        }
    }

    return kitiKiekiai;
}

void output(ofstream &out, vector<int> nominalai, vector<int> kiekiai)
{
    if (nominalai.size() != kiekiai.size())
        throw invalid_argument("Nesutampa kiekiai");
    for (int i = 0; i < nominalai.size(); i++)
        out << nominalai[i] << ' ' << kiekiai[i] << '\n';
    out << accumulate(kiekiai.begin(), kiekiai.end(), 0) << '\n';
}

int main()
{
    ifstream in("U1.txt");
    ofstream out("U1rez.txt");

    vector<int> nominalai1, kiekiai1, nominalai2, kiekiai2;

    input(in, nominalai1, kiekiai1);
    input(in, nominalai2, kiekiai2);

    vector<int> kiekiai3 = skaiciavimas(nominalai1, kiekiai1, nominalai2);
    vector<int> kiekiai4 = skaiciavimas(nominalai2, kiekiai2, nominalai1);

    output(out, nominalai2, kiekiai3);
    output(out, nominalai1, kiekiai4);

    in.close();
    out.close();
    return 0;
}
