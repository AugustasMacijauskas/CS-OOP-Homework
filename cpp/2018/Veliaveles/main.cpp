#include <fstream>

using namespace std;

void Skaityti(ifstream & input, int & g, int & z, int & r) {
    int n;
    input >> n;

    for (int i = 0; i < n; i++) {
        string sp;
        int x;
        input >> sp >> x;

        if (sp == "G") {
            g += x;
        }
        else if (sp == "Z") {
            z += x;
        }
        else if (sp == "R") {
            r += x;
        }
    }
}

int KiekVeliaveliu(int & g, int & z, int & r) {
    int counter = 0;

    while (g - 2 >= 0 && z - 2 >= 0 && r - 2 >= 0) {
        counter++;
        g -= 2;
        z -= 2;
        r -= 2;
    }

    return counter;
}


int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    int geltonu = 0, zaliu = 0, raudonu = 0;
    Skaityti(input, geltonu, zaliu, raudonu);

    int kiekVeliaveliu = KiekVeliaveliu(geltonu, zaliu, raudonu);

    output << kiekVeliaveliu << "\n";
    output << "G = " << geltonu << "\n";
    output << "Z = " << zaliu << "\n";
    output << "R = " << raudonu;

    input.close();
    output.close();
    return 0;
}
