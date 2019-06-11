// pr1
#include <iostream>
#include <fstream>
#include <cstring>
//#include <cstdlib>   // Dirbant su char
#include <iomanip>

using namespace std;

struct mokinys{
    string pav;
    int dal;
    int paz[10];
    };

void Rikiuoti (int n, mokinys X[])
{
    int i, j, k;
    string max;
     for (i=1;i<=n-1;i++)
     {
         max=X[i].pav;
         k=i;
         for (j=i+1;j<=n;j++)
         {
             if (X[j].pav>=max)
             {
                 max=X[j].pav;
                 k=j;
             }
         }
         swap(X[i], X[k]);
     }
}


void Skaityti (ifstream & f1, int  & n, mokinys X[], mokinys Y[])
{
   n=0;
    while (! f1.eof())
     {
         n=n+1;
         f1>>X[n].pav>>X[n].dal;
         for (int j=1;j<=X[n].dal;j++)
            f1>>X[n].paz[j];
         f1.ignore();
         Y[n]=X[n];
     }


}

void Spausdinti (ofstream & f2, int  n, mokinys Y[])
{

   for (int i=1;i<=n;i++)
     {    f2<<Y[i].pav;
          for (int j=1;j<=Y[i].dal;j++)
          f2<<"  "<<Y[i].paz[j];
          f2<<endl;
     }
 }


int main()
{
    setlocale(LC_ALL,"Lithuanian");
    int i, j, n ,m;
    mokinys X[10],Y[10];

    ifstream f1("strukturos1.txt");
    ofstream f2("Atsakymai_strukturos2.txt");

    Skaityti (f1, n, X, Y);
      f2<<"  I struktura"<<endl<<endl;

    Spausdinti(f2, n, X);

     f2<<endl;
     f2<<"  Rikiuota I struktura"<<endl<<endl;
     Rikiuoti(n, X);
    Spausdinti(f2, n, X);



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
