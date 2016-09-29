#include<iostream>
#include<string>
using namespace std;


struct fcfs {
	int n;
	string *name;
	int *arr;
	int *pro;
	int *rt;
	int *wt;
	int *tt;
};
int a[] = { 0,3,4,6,11 };
int p[] = { 8,5,10,9,7 };

void init(fcfs &f) {
	f.name = new string[f.n];
	f.arr = new int[f.n];
	f.pro = new int[f.n];
	f.rt = new int[f.n];
	f.wt = new int[f.n];
	f.tt = new int[f.n];
}

void swap(int &a, int &b)
{
	int t = a;
	a = b;
	b = t;
}
void sort(fcfs &f) {
	for (int i = 0; i < f.n; i++) {
		for (int j = i; j < f.n; j++) {
			if (f.arr[i] > f.arr[j]) {
				swap(f.arr[i], f.arr[j]);
				swap(f.name[i], f.name[j]);
				swap(f.pro[i], f.pro[j]);
			}
		}
	}
}

void input(int n, int &arr, int &pro) {
	cout << "arrival and process: "; cin >> arr >> pro;
}

void process(fcfs &f) {
	f.wt[0] = f.arr[0];
	f.rt[0] = f.wt[0];
	f.tt[0] = f.wt[0] + f.pro[0];

	for (int i = 1; i < f.n; i++) {
		int tmp = 0;
		for (int j = 0; j < i; j++) {
			tmp += f.pro[j];
		}
		f.wt[i] = tmp - f.arr[i];
		f.rt[i] = f.wt[i];
		f.tt[i] = f.wt[i] + f.pro[i];
	}
}

void output(fcfs f) {
	cout << "P\t" << "rt\t" << "wt\t" << "tt" << endl;
	cout << "==========================" << endl;
	for (int i = 0; i < f.n; i++) {
		cout << f.name[i] << "\t" << f.rt[i] << "\t" << f.wt[i] << "\t" << f.tt[i] << endl;
	}
}

int main() {
	fcfs f;
	cout << "Input number of process: ";
	cin >> f.n;
	//f.n = 5;
	init(f);
	for (int i = 0; i < f.n; i++) {
		cout << "p[" << i + 1 << "] ";
		input(f.n, f.arr[i], f.pro[i]);
		f.name[i] = "P" + to_string(i + 1);
		//f.arr[i] = a[i];
		//f.pro[i] = p[i];
	}
	sort(f);
	process(f);
	output(f);
	return 0;
}