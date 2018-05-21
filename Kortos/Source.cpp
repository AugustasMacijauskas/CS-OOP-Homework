#include <iostream>
#include <fstream>
#include <map>
#define MP make_pair

using namespace std;

int main()
{
	ifstream duom("duom.txt");
	ofstream rez("rez.txt");

	int y;
	char x;
	multimap<char, int> kortos;

	while (duom >> x >> y) {
		kortos.insert(MP(x, y));
	}

	for (multimap<char, int>::iterator i = kortos.begin(); i != kortos.end(); i++)
	{
		cout << i->first << " " << i->second << endl;
	}

	return 0;
}