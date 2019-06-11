#include <iostream>

using namespace std;

int main()
{
    int count = 0;
    for (int i = 1000; i <= 9999; i++) {
        if (i % 3 == 0) {
            count++;
        }
    }

    cout << count;
    return 0;
}
