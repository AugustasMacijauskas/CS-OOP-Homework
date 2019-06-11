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

    string x="Antra";
    string y="aktyviai ";
    string z="neaktyviai ";
    string eil="Pirmadienis. Dabar pamoka.";
    string eil1, eil2, eil3, eil3_1, eil4, eil5, eil6, eil7;
char p;
p=x[1];

    eil1=" Visi dirba.";
    eil2=eil;
    eil3=eil2+eil1;  //Sujungia eilutes
    cout<<eil3<<endl;

    eil3_1=eil2;
    eil3_1.append(eil1);   //Sujungia eilutes
    cout<<eil3_1<<endl;

    eil3=eil3+" Mokiniai tuoj patys spr�s.";    //Sujungia eilutes
    cout<<eil3<<endl;

    eil4.assign(eil3);  //Eilutei priskiria kit� eilut�
    cout<<eil4<<endl;

    eil5.assign(eil4,13,5); //Eilutei priskiria kitos eilut�s dal�: 5simbolius pradedant 13
    cout<<eil5<<endl;


    eil6=eil4;
    eil6.assign(10,'*');    //Suformuoja pasikartojan�i� simboli� eilut�
    cout<<eil6<<endl;

    eil6.swap(eil5);        //Eilutes sukei�ia vietomis
    cout<<eil6<<endl;

    int a=0,b=5;
    eil3.replace(a,b,x);    //b eilut�s simboli�, pradedant nuo a, pakei�ia kitos eilut�s simboliais
    cout<<eil3<<endl;

    int c=32;
    eil3.insert(c,y);       //� eilut� �terpia kit� eilut�, pradedant vieta c
    cout<<eil3<<endl;

    c=6;
    int d=2, e=9;
    eil1.insert(c,z,d,e);   //� eilut�, pradedant vieta c, �terpia kitos eilut�s z dal�, nuo d e simboli�
    cout<<eil1<<endl;

    eil1.clear();           //Pilnai i�valo eilut�

    c=32;
    eil3.erase(c,e);        //I� eilut�s pa�alina e simboli�, pradedant c
    cout<<eil3<<endl;

    a=0; b=11;
    eil7=eil3.substr(a,b);  //I� eilut�s i�skiria b simboli�, pradedant a
    cout<<eil7<<endl;

    int kuris=eil3.find("Dabar",a); //Randa antros eilut�s pradinio simbolio numer� duotoje eilut�je, pradedant nuo a
    cout<<"kuris="<<kuris<<endl;          //Jei n�ra, i�duoda -1

    a=11;
    int pradzia=eil3.find_first_not_of(" .,;:?!",a);  //Pradedant a, randa pirmo simbolio, nepriklausan�io antra eilutei, numer�
    cout<<"pradzia="<<pradzia<<endl;       //Jei n�ra, i�duoda -1

    a=13;
    int pabaiga=eil3.find_first_of(" .,;:?!",a);  //Pradedant a, randa pirmo simbolio, priklausan�io antra eilutei, numer�
    cout<<"pabaiga="<<pabaiga<<endl;       //Jei n�ra, i�duoda -1

    a=11;                                            //�od�io i�skyrimas
    pradzia=eil3.find_first_not_of(" .,;:?!",a);     //Prad�ia
    pabaiga=eil3.find_first_of(" .,;:?!",pradzia);   //Pabaiga
    eil7=eil3.substr(pradzia,pabaiga-pradzia);     //�odis
    cout<<eil7<<endl;

    int ilgis=eil3.length();    //Eilut�s ilgis
    cout<<"ilgis="<<ilgis<<endl;

    ilgis=eil3.size();    //Eilut�s ilgis
    cout<<"ilgis="<<ilgis<<endl;

    char pav[]="Eilut�s";
    eil3=pav;   //Char � string. Tiesiogiai i� string � char negalima
    cout<<eil3<<endl;

    int n, m, i, j;
    string klas;
    string Pav[10], Lyt[10], Klase[10];
    int Paz[10][10];
    ifstream f1("Eilute_string.txt");
    ofstream f2("Atsakymai_eilute_string.txt");
    f1>>n>>m;
    f1.ignore();
    getline(f1,klas,'\n');
    f2<<"Klase  "<<klas<<endl;
    for(i=1;i<=n;i++)
       {
       getline(f1,Pav[i],',');
       f1>>ws;   //Praleid�ia tarpus
       getline(f1,Lyt[i],',');
       f1>>ws;   //Praleid�ia tarpus
       f1>>Klase[i];
       f1>>ws;   //Praleid�ia tarpus
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
