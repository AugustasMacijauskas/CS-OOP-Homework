// pr1
#include <iostream>
#include <fstream>
#include <cstring>
//#include <cstdlib>   // Dirbant su char
#include <iomanip>

using namespace std;
int main()
{
    setlocale(LC_ALL,"Lithuanian");
    int i, j, n ,m;
    struct mokinys{
    string pav;
    int dal;
    int paz[10];
    };
    mokinys X[10],Y[10];

    ifstream f1("strukturos1.txt");
    ofstream f2("Atsakymai_strukturos.txt");

    n=0;
    while (! f1.eof())
     {
         n=n+1;
         f1>>X[n].pav>>X[n].dal;
         for (j=1;j<=X[n].dal;j++)
            f1>>X[n].paz[j];
         f1.ignore();
         Y[n]=X[n];
     }
      f2<<"  I struktura"<<endl<<endl;

     for (i=1;i<=n;i++)
     {    f2<<Y[i].pav;
          for (j=1;j<=Y[i].dal;j++)
          f2<<"  "<<Y[i].paz[j];
          f2<<endl;
     }





    ifstream f3("strukturos2.txt");

    struct data{
    int metai, menuo, diena;
    };

    struct mokinys1{
    string pav;
    data dat;
    int kiekis;
    };

    mokinys1 Z[10];
    m=0;
    while (! f3.eof())
     {
         m=m+1;
         f3>>Z[m].pav>>Z[m].dat.metai>>Z[m].dat.menuo>>Z[m].dat.diena>>Z[m].kiekis;
         f3.ignore();

     }
      f2<<endl;
      f2<<"  II struktura"<<endl<<endl;

     for (i=1;i<=m;i++)
     {    f2<<Z[i].pav<<"  "<<Z[i].dat.metai<<"  "<<Z[i].dat.menuo<<"  "<<Z[i].dat.diena<<"  "<<Z[i].kiekis;
          f2<<endl;
     }




    f1.close();
    f2.close();
    f3.close();
    return 0;
}
