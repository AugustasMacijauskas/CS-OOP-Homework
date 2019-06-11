#include <bits/stdc++.h>

using namespace std;

typedef long long ll;

string ats;
ll atss;
ll dali = -1;
int d;

int a[10];

void rek(int i = 1, ll skai = 0, ll des = 1) {
	//cout << i << " " << skai << " " << des << endl;
	if (i == d + 1) {
		ll t = skai;
		int dalij = 0;
		while ((t & 1) == 0) {
			// x&(-x)
			t >>= 1;
			dalij++;
		}
		if (dalij > dali) {
			atss = skai;
			dali = dalij;
		}
		return;
	}

	if (i - 1 > dali) {
		ll t = skai;
		ll de = des;
		for (int j = 0; j < 10; j++) {
			for (int k = 0; k < a[j]; k++) {
				t += j * de;
				de *= 10;
			}
		}
		atss = t;
		dali = i - 1;
	}

	if (i + a[0] > d)
		return;
	for (int j = 0; j < 10; j++) {
		if (a[j]) {
			if (((skai + j * des) & ((1ll << i) - 1)) == 0) {
				a[j]--;
				rek(i + 1, skai + j * des, des * 10);
				a[j]++;
			}
		}
	}
}

int main() {
	ios_base::sync_with_stdio(false), cin.tie(0);
#ifndef EVAL
	//freopen("b.in","r",stdin);
#else
	freopen("dvejetumas-vyr.in", "r", stdin);
	freopen("dvejetumas-vyr.out", "w", stdout);
#endif // EVAL
	cin >> d;
	string n;
	cin >> n;
	ats = n;
	for (char c : n) {
		a[c - '0']++;
	}
	rek();
	cout << atss << "\n" << (1ll << dali);
}
