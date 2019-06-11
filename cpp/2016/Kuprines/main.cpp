#include <fstream>

using namespace std;

int SunkiausiaKuprine(ifstream & input) {
    int n;
    input >> n;

    int sunkiausia = 0;
    for (int i = 0; i < n; i++) {
        int x;
        input >> x;

        if (x > sunkiausia) {
            sunkiausia = x;
        }
    }

    return sunkiausia;
}

int KiekLengviausiu(ifstream & input, int sunkiausia) {
    int n;
    input >> n;

    int counter = 0;
    for (int i = 0; i < n; i++) {
        int x;
        input >> x;

        if (2 * x <= sunkiausia) {
            counter++;
        }
    }

    return counter;
}

int main()
{
    char inputFileName[] = "U1_2.txt";
    ifstream input(inputFileName);
    ofstream output("U1rez.txt");

    int sunkiausiaKuprine = SunkiausiaKuprine(input);

    input.close();
    input.open(inputFileName);

    output << sunkiausiaKuprine << " " << KiekLengviausiu(input, sunkiausiaKuprine);

    input.close();
    output.close();

    return 0;
}
