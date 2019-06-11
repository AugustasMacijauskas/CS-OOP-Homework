#include <bits/stdc++.h>

using namespace std;

struct Dal {
	int first, second;
	bool vid;
	Dal(int a, int b) :first(a), second(b) {}
};

int main()
{
	ios_base::sync_with_stdio(false), cin.tie(0);
#ifndef EVAL
	//freopen("a.in","r",stdin);
#else
	freopen("bokstas-vyr.in", "r", stdin);
	freopen("bokstas-vyr.out", "w", stdout);
#endif // EVAL
	int n, k;
	cin >> n >> k;
	if (k == 1)
	{
		cout << 0;
		return 0;
	}
	vector<int> c(n);
	list<Dal> a;
	for (int i = 0; i < n; i++)
	{
		cin >> c[i];
		if (!a.empty() and a.back().first == c[i])
		{
			a.back().second++;
		}
		else
		{
			a.emplace_back(c[i], 1);
		}
	}
	a.emplace_back(-1, 1);
	a.emplace_front(-2, 1);

	vector<list<Dal>::iterator> eil[2];
	int dab = 0;

	for (list<Dal>::iterator it = a.begin(); it != a.end(); it++)
	{
		if (it->second >= k) {
			if (!it->vid)
				eil[dab].push_back(it);
			it->vid = true;
		}
	}

	while (!eil[dab].empty()) {
		int tol = dab ^ 1;
		for (list<Dal>::iterator it : eil[dab]) {
			list<Dal>::iterator itp = it;
			itp--;
			list<Dal>::iterator itn = it;
			itn++;
			a.erase(it);
			if (itp->first == itn->first and !itn->vid) {
				itp->second += itn->second;
				a.erase(itn);
			}

			if (itp->second >= k) {
				if (!itp->vid)
					eil[tol].push_back(itp);
				itp->vid = true;
			}
		}
		eil[dab].clear();
		dab = tol;
	}

	vector<int> ats;
	for (Dal d : a) {
		if (d.first < 0)
			continue;
		for (int i = 0; i < d.second; i++) {
			ats.push_back(d.first);
		}
	}
	cout << ats.size() << "\n";
	for (int i : ats) {
		cout << i << "\n";
	}
}
