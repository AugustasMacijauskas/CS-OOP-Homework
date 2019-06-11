#include <iostream>
#include <fstream>
#include <vector>
#include <cmath>

using namespace std;

int search(vector<int> zmones, int x, int D) {
	for (int i = 0; i < zmones.size(); i++) {
		if (abs(x - zmones[i]) <= D) {
			return i;
		}
	}
	
	return -1;
}

bool arEgzistuoja(vector<int> zmones, int x, int D) {
	if (zmones.size() > 0) {
		for (int i = 0; i < zmones.size(); i++) {
			cout << abs(x - zmones[i]) << endl;
			if (abs(x - zmones[i]) <= D) {
				return true;
			}
		}
	}

	return false;
}

int main()
{
	int n, D, x;

	ifstream input("svarstykles-vyr.in");
	ofstream output("svarstykles-vyr.out");

	// Zmogus, paskutinis svoris
	vector<int> zmones;

	input >> n >> D;

	int zmoniuSkaicius = 0;
	for (int i = 0; i < n; i++) {
		input >> x;
		if (zmones.size() <= 0 || !arEgzistuoja(zmones, x, D)) {
			zmones.push_back(x);
			zmoniuSkaicius++;
		}
		else {
			int indexas = search(zmones, x, D);
			zmones[indexas] = x;
		}
	}

	output << zmoniuSkaicius << endl;
	cout << zmoniuSkaicius << endl;
	return 0;
}
