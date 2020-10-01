#include <iostream>
#include <cmath>
#include <cstdlib>
#include <fstream>
#include <cstdio>
#include <string>

using namespace std;






// FIRST TASK
double MyFunc(double x);
void CalcFunc();
#define A 1
#define B 10e10

// SECOND TASK
bool MyLogicFunc(bool a, bool b, bool c);
void CalcLogicFunc();

// THIRD TASK
int Factorial(int n);
double FuncForSeq(int n, double x);
void CalcSeq();
#define EPS 1e-5

// FOURTH TASK
int GetRowCount();
int GetColCount();
double* GetArr(int m, int n);
double* GetArrAftProc(double arr[], int m, int n);
void PrintSumArr(double arr[], int m, int n);
void InputArr(char filename[], double arr[], int m, int n);
void OutputArr(double arr[], int m, int n);
void ArrTask();
#define M 8
#define N 3


int main()
{
	setlocale(LC_ALL, "Russian");
	int task;
	bool work = true;
	char branch;
	do {
		cout << "\n�������� ������: \n";
		cout << "1 - ���������� ��������������� ���������\n";
		cout << "2 - ���������� ����������� ���������\n";
		cout << "3 - ���������� ����� ���� �������\n";
		cout << "4 - ������ � ��������\n";
		cout << "����� ������ ������� ����� �����\n";
		cin >> branch;
		system("cls");
		switch (branch)
		{
		case '1': CalcFunc();
			break;
		case '2': CalcLogicFunc();
			break;
		case '3': CalcSeq();
			break;
		case '4': ArrTask();
			break;
		default: work = false;
		}
	} while (work);

	return 0;
}


// FIRST TASK
double MyFunc(double x)
{
	return (B * B * x + exp(-x) * pow(sin(B * x), 5)) / (log(A + B) - log(B - x) / log(5));
}

void CalcFunc()
{
	setlocale(LC_ALL, "RUS");
	double x;
	cout << "\n������� x ��� ���������� ������� � A = " << A << "; � B = " << B << endl;
	cin >> x;
	cout << "��������� F(x) = " << MyFunc(x) << endl;
}


// SECOND TASK
bool MyLogicFunc(bool a, bool b, bool c)
{
	return (a && (!b) && (!c)) || ((!a) && b && (!c)) || ((!a) && (!b) && c);
}

void CalcLogicFunc()
{
	bool a, b, c;
	double x1, x2, x3;
	cout << "������� ����� ��� ��������� X > 0\n\n";
	cin >> x1;
	cout << "������� ����� ��� ��������� X < 0\n\n";
	cin >> x2;
	cout << "������� ����� ��� ��������� X = 0\n\n";
	cin >> x3;
	a = x1 > 0;
	b = x2 < 0;
	c = x3 == 0;
	cout << "��������� ����������� ��������� �� ������ ���� ���������, ��� ������, ����� ������ ���� ���������� - ������, � ��������� - ����:\n"
		<< (MyLogicFunc(a, b, c) ? "True\n" : "False\n");
}


// THIRD TASK
int Factorial(int n)
{
	int res = 1;
	if (n >= 2)
	{
		for (int i = 2; i <= n; i++)
		{
			res *= i;
		}
	}
	return res;
}

double FuncForSeq(int n, double x)
{
	int one = ((n % 2) ? 1 : -1);
	return one * pow(2, 2 * n - 1) * pow(x, 2 * n) / Factorial(2 * n);
}

void CalcSeq()
{
	double sum = 0;
	double x;
	int n = 0;
	double res;
	cout << "������� � ��� ���������� (sin(x))^2, ��� |X| < 1;\n";
	cin >> x;
	if ((x <= -1) || (x >= 1)) {
		x = (x <= -1 ? -0.99 : x);
		x = (x >= 1 ? 0.99 : x);
		cout << "X ��� ������ ���������� � ����� ��������\n";
		cout << "�� ����������� ��� ����������� �����, ��� ������� ��� ��������\n";
	}
	do
	{
		n++;
		res = FuncForSeq(n, x);
		sum += res;
	} while (fabs(res) > EPS);
	cout << "X = " << x << endl;
	cout << "����� ���� ������� �������\n";
	cout << sum << endl;
	cout << "\n�������������� �������\n"
		<< sin(x) * sin(x) << endl;
	cout << "\n�������������� ������� sin(x)\n"
		<< sin(x) << endl;
}


// FOURTH TASK
int GetRowCount()
{
	int m;
	cout << "������� ����� �����\n";
	cin >> m;
	system("cls");
	return m;
}

int GetColCount()
{
	int n;
	cout << "������� ����� ��������\n";
	cin >> n;
	system("cls");
	return n;
}



void OutputArr(double arr[], int m, int n)
{
	string s = string(11 * n + 1, '=');
	cout << s << endl;
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			printf("|%10.3f", arr[i * n + j]);
		}
		cout << "|" << endl;
		cout << s << endl;
	}
}

double* GetArr(int m, int n)
{
	double* arr = new double[m * n];
	return arr;
}

void InputArr(char filename[], double arr[], int m, int n)
{
	ifstream fin(filename);
	if (!fin)
		cout << "Error!" << endl;
	else
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				fin >> arr[i * n + j];
			}
		}
	}
	fin.close();
}

double* GetArrAftProc(double arr[], int m, int n)
{
	int l_m = m / 2;
	double* minmax = new double[l_m];
	for (int i = 0; i < l_m; i++)
	{
		double max = -1e6;
		for (int j = 0; j < n; j++)
		{
			if (arr[(i * 2 + 1) * n + j] < 0)
			{
				max = ((arr[(i * 2 + 1) * n + j] > max) ? arr[(i * 2 + 1) * n + j] : max);
			}
		}
		minmax[i] = max;
	}
	return minmax;
}

void PrintSumArr(double arr[], int m, int n)
{
	int l_n = n / 2;
	for (int j = 0; j < l_n; j++)
	{
		double sum = 0;
		for (int i = 0; i < m; i++)
		{
			if (arr[i * n + j * 2 + 1] < 0)
			{
				sum += arr[i * n + j * 2 + 1];
			}
		}
		cout << "\t" << sum << endl;
	}
}


void ArrTask() {
	bool deny;
	int m;
	int n;
	do {
		deny = false;
		cout << "������� ������ �������, ��� ���������� ��������� �� ��������� 24\n";
		m = GetRowCount();
		n = GetColCount();
		system("cls");
		if ((m * n) > 24 || (m < 0) || (n < 0) )
		{
			cout << "���������� ��������� ������� �����������, ��������� ����\n";
			deny = true;
		}

	} while (deny);
	int minmax_m = m / 2;
	char filename[] = "nums.txt";
	double* minmax;
	double* arr = GetArr(m, n);
	InputArr(filename, arr, m, n);
	minmax = GetArrAftProc(arr, m, n);
	cout << "�������� ������" << endl;
	OutputArr(arr, m, n);
	cout << endl;
	cout << "������ ������������ ������������� ����� ������ ������ ������:\n";
	OutputArr(minmax, minmax_m, 1);
	cout << "\n����� ������������� ��������� ��� ������ ��������:\n";
	PrintSumArr(arr, m, n);
	delete[] minmax;
	delete[] arr;
}
