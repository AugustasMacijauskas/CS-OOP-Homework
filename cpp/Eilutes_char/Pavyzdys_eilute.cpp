// pr1
#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdlib>
using namespace std;
int main()
{
    setlocale(LC_ALL,"Lithuanian");
    char x;
    int y,i;
    char z[]="Pirmadienis. Dabar pamoka.";
    int kiekis[200];


    cout<<"Labas"<< endl;
    ifstream f1("Eilute.txt");
    ofstream f2("Atsakymai_eilute.txt");

    while (!f1.eof())
    {
       f1.get(x);
       if(!f1.fail())
       {y=(int)x;
        f2<<x;
        cout<<x<<"     "<<y<<endl;
    }
    }


    for(i=0;i<255;i++)
    {
    cout<<i<<"  -  "<<(char)i<<endl;
    }

    for(i=0;i<200;i++)
        kiekis[i]=0;

    for(i=0;i<strlen(z);i++)
    {
    if ((z[i]>='A'&& z[i]<='Z')|| (z[i]>='a'&& z[i]<='z'))
        kiekis[z[i]]++;
    }


    f2<<endl;
    f2<<endl;
    f2<<"  Raidžių pasikartojimo kiekis tekste:    "<<endl;
    f2<<"  "<<z<<endl;
    f2<<endl;
    f2<<endl;

    for(i=32;i<128;i++)
    {
    if (((char)i>='A' && (char)i<='Z') || ((char)i>='a' && (char)i<='z'))
       if (kiekis[(char)i]) f2<<(char)i <<"   "<<kiekis[(char)i]<<endl;
    }



    f1.close();
    f2.close();
    return 0;
}
