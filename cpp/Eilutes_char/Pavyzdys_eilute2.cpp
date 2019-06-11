// pr1
#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdlib>
#include <iomanip>

using namespace std;
int main()
{
    setlocale(LC_ALL,"Lithuanian");
    char x[30];
    char Pav[10][30],Lyt[10][30],Klase[10][30];
    int Paz[10][10];
    int n,m,i,j;



    cout<<"Labas"<< endl;
    ifstream f1("Eilute2.txt");
    ofstream f2("Atsakymai_eilute2.txt");
    f1>>n>>m;
    f1.ignore();
    f1.getline(x,256,'\n');
    //f1.ignore();
    f2<<"Klase  "<<x<<endl;
    for(i=1;i<=n;i++)
       {
       f1.getline(Pav[i],256,',');
       f1.getline(Lyt[i],256,',');
       f1>>Klase[i];
       for(j=1;j<=m;j++)
       f1>>Paz[i][j];

       f2<<setw(20)<<left<<Pav[i]<<"  "<<setw(6)<<Lyt[i]<<"  "<<setw(10)<<Klase[i]<<"  ";
       for(j=1;j<=m;j++)
       f2<<Paz[i][j]<<"  ";
       f2<<endl;
       f1.ignore();
    }




    f1.close();
    f2.close();
    return 0;
}
