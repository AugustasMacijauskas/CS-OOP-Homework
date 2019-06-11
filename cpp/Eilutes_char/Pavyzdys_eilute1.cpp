// pr1
#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdlib>
using namespace std;
int main()
{
    setlocale(LC_ALL,"Lithuanian");
    char x[256];
    char z[]="Darbas";
    char eil[20];
    int i,y;
    cout<<"Labas"<< endl;
    ifstream f1("Eilute.txt");
    ofstream f2("Atsakymai_eilute1.txt");

    if (z[1]=='a') cout<<endl;




    while (!f1.eof())
    {
       f1.getline(x,256,'\n');


        f2<<x;
        cout<<x;
        if(!f1.eof())
        {f2<<endl;
        cout<<endl;
        }
    }

    cout<<endl;
    cout<<endl;


    y=sizeof(z);
    cout<<"Ilgis="<<y<<endl;

    y=strlen(z);
    cout<<"Ilgis="<<y<<endl;
//-----------------------------------------------


    //eil=z;     Negalima

    strcpy(eil,z);  //Priskiria eilutei kità eilutæ.
    cout<<eil<<endl;

    strcpy(eil,"Dabar pamoka. "); //Priskiria eilutei kità eilutæ.
    cout<<eil<<endl;

    strcat(eil,"Pirmadienis.");  //Apjungia eilutes.
    cout<<eil<<endl;
//-----------------------------------------------


    strncpy(eil,"Vakar",5);  //Pakeièia 5 pirmos eilutës simbolius.
    cout<<eil<<endl;

    strncat(eil," Pirmadienis.",6);  //Prijungia nurodytà kieká antros eilutës simboliø
    cout<<eil<<endl;
//-----------------------------------------------


    cout<<strcmp(eil,z)<<endl;  //Lygina eilutes: 0 lygios; neigiamas skaièius I>II; teigiamas skaièius I<II;
//-----------------------------------------------


     char p[]="67,896Lt";
     int k;
     long int l;
     double m;
     k=atoi(p);    //Eilutæ verèia á skaièiø int
     l=atol(p);    //Eilutæ verèia á skaièiø long int
     m=atof(p);    //Eilutæ verèia á skaièiø došuble (Kreipti dëmesá á skyriklá)
     cout<<"k="<<k<<"   l="<<l<<"   m="<<m<<endl;


    f1.close();
    f2.close();
    return 0;
}
