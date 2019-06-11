#include <fstream>

using namespace std;

string Konvertuoti(int desimtainis) {
    static string raides = "0123456789ABCDEF";
    string ret = "";

    int sveikojiDalis = desimtainis / 16;
    ret += raides[sveikojiDalis];

    int liekana = desimtainis % 16;
    ret += raides[liekana];

    return ret;
}

void Skaiciuoti(ifstream & input, ofstream & output) {
    int a, b;

    input >> a >> b;

    for (int i = 0; i < a; i++) {
        for (int j = 0; j < b; j++) {
            int x, y, z;
            input >> x >> y >> z;
            output << Konvertuoti(x) << Konvertuoti(y) << Konvertuoti(z);
            if (j != b - 1) {
                output << ";";
            }
        }

        output << endl;
    }
}

int main()
{
    ifstream input("U1.txt");
    ofstream output("U1rez.txt");

    Skaiciuoti(input, output);

    input.close();
    output.close();

    return 0;
}
