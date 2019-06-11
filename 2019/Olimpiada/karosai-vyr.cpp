#include <bits/stdc++.h>

using namespace std;

struct dsu {
    int par[1010];
    dsu(){
        for(int&i:par){
            i = -1;
        }
    }
    int parent(int i){
        if(par[i] < 0)
            return i;
        int t = i;
        while(par[i] >= 0)
            i = par[i];
        return par[t] = i;
    }
    bool merge(int i, int j){
        i = parent(i);
        j = parent(j);
        if(i == j)
            return false;
        if(par[i] > par[j]){
            swap(i,j);
        }
        par[i]+=par[j];
        par[j]=i;
        return true;
    }
    bool conn(int i, int j){
        return parent(i) == parent(j);
    }
};

struct Trys{
    int a,b,c;
    Trys(int x, int y, int z):a(x),b(y),c(z){}
    Trys(){}
    bool operator<(const Trys&o)const{
        return a < o.a;
    }
};

int main() {
    ios_base::sync_with_stdio(false),cin.tie(0);
    #ifndef EVAL
    //freopen("c.in","r",stdin);
#else
    freopen("karosai-vyr.in","r",stdin);
    freopen("karosai-vyr.out","w",stdout);
    #endif // EVAL

    dsu d;
    int n,m;
    cin >> n >> m;
    vector<Trys> t(m);
    for(Trys&i : t){
        cin >> i.b >> i.c >> i.a;
    }

    sort(t.begin(),t.end());
    for(Trys&i : t){
        d.merge(i.b,i.c);
        if(d.conn(1,n)){
            cout << i.a;
            return 0;
        }
    }
}
