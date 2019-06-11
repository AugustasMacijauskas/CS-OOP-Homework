// pr1
#include <iostream>
#include <fstream>
#include <cstring>
//#include <cstdlib>
using namespace std;
int main()
{
    setlocale(LC_ALL,"Lithuanian");
    char x[21];
    string pav[100];
    int kiek[100];
    int i, n;
    cout<<"Labas"<< endl;
    ifstream f1("Eilute3.txt");
    ofstream f2("Atsakymai_eilute3.txt");
    n=0;
    while (!f1.eof())
    {
       f1.get(x,20);
       string nauj(x);
       pav[n]=nauj;
       f1>>kiek[n];
       f1.ignore();
       n++;
    }


    for (i=0;i<n;i++)
        f2<<pav[i]<<"    "<<kiek[i]<<endl;




    f1.close();
    f2.close();
    return 0;
}
