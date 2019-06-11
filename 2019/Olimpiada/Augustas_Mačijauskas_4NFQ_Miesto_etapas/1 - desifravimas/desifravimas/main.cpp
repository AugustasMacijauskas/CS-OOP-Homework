#include <bits/stdc++.h>

using namespace std;

int main()
{
    int stringSize, K;
    string badString, goodString, encodedString;
    char x;
    ifstream input("desifravimas-vyr.in");
    ofstream output("desifravimas-vyr.out");

    input >> stringSize;
    for (int i = 0; i < stringSize; i++) {
        input >> x;
        badString += x;
    }

    for (int i = 0; i < stringSize; i++) {
        input >> x;
        goodString += x;
    }

    int stringIterator;
    for (stringIterator = 0; stringIterator < stringSize; stringIterator++) {
        if (badString[stringIterator] == goodString[stringIterator]) {
            continue;
        }
        else {
            K = goodString[stringIterator] - badString[stringIterator];
            break;
        }
    }

    if (K < 0) {
        K += 26;
    }

    for (int i = 0; i < stringSize; i++) {
        if ((int(goodString[i]) >= 65 && int(goodString[i]) <= 90)) {
            int charNumber = int(goodString[i]) - K;
            if (charNumber < 65) {
                charNumber = 90 - (65 - charNumber) + 1;
            }
            encodedString += char(charNumber);
        }
        else if ((int(goodString[i]) >= 97 && int(goodString[i] <= 122))) {
            int charNumber = int(goodString[i]) - K;
            if (charNumber < 97) {
                charNumber = 122 - (97 - charNumber) + 1;
            }
            encodedString += char(charNumber);
        }
        else {
            encodedString += goodString[i];
        }
    }

    output << encodedString << endl;
    return 0;
}
