
#include <iostream>
#include <fstream>
#include <cstring>
#include <iomanip>

using namespace std;


int main()
{
    setlocale(LC_ALL,"Lithuanian");

    double a,b, vid;
    int j,i,n;
    a=0;
    b=0;
    vid=0;
    j=0;
    int paz[10], paz1[10];
    string  Vard[100],Vard1[100], Klas[10], t;
    ifstream f1("Duomenys.txt");
    ofstream f2("Atsakymai.txt");
    f2<<"1 lentele"<<endl;
    f2<<endl;
    f1>>n;
    f1.ignore();
    for(i=1;i<=n;i++)
       {
       getline(f1,Vard[i],';');
       getline(f1,Klas[i],';');
       f1>>paz[i];

       f2<<setw(30)<<left<<Vard[i]<<"  "<<setw(6)<<Klas[i]<<"  "<<setw(10)<<right<<paz[i]<<"  ";
       f2<<endl;
       f1.ignore();
       }
       f2<<endl;
         cout<<"Pasirinkite klase \n";
    cin>>t;
    for(i=1; i<=n; i++){
        if(Klas[i]==t){
            a++;
            b=paz[i]+b;
        }
    }
    if(a==0) f2<<"Tokios klases nera";
    else{vid=b/a;

    for(i=1; i<=n; i++){
        if(paz[i]>vid && Klas[i]==t){
            j++;
            Vard1[j]=Vard[i];
            paz1[j]=paz[i];
        }

    }
    if(j==0) f2<<"Nei vienas mokinys neatitinka salygu";
    else{   f2<<"2 lentele"<<endl;
            f2<<endl;
            f2<<"Klases vidurkis:"<<" "<<vid<<endl;
    for(i=1; i<=j; i++){
        f2<<setw(30)<<left<<Vard1[i]<<"  "<<setw(6)<<right<<paz1[i]<<"  "<<endl;
    }
    }
    }
    f1.close();
    f2.close();
    return 0;

}

