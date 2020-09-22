#include <iostream>
#include <cmath>
#include <stdlib.h>
#include <fstream>
#include <cstdio>
#include <string>

using namespace std;

#define A 1
#define B 10e10
#define EPS 1e-2
#define M 8
#define N 3

double MyFunc(double x);
void CalcFunc();

bool MyLogicFunc(bool a, bool b, bool c);
void CalcLogicFunc();

int Factorial(int n);
double FuncForSeq(int n, double x);
void CalcSeq();


int GetRowCount();
int GetColCount();
double* GetArr(int m, int n);
double* GetArrAftProc(double arr[], int m, int n);
void PrintSumArr(double arr[], int m, int n);
void InputArr(char filename[], double arr[], int m, int n);
void OutputArr(double arr[], int m, int n);
void ArrTask();


int main()
{
	setlocale(LC_ALL, "Russian");
	int task;
	bool work = true;
	char tree;
	
	do {
		cout << "\n�������� ������: \n";
		cout << "1 - ���������� ��������������� ���������\n";
		cout << "2 - ���������� ����������� ���������\n";
		cout << "3 - ���������� ����� ���� �������\n";
		cout << "4 - ������ � ��������\n";
		cout << "����� ������ ������� ����� �����\n";
		cin >> task;
		system("cls");
		tree = task + 48;
		switch (tree)
		{		
		case '1': CalcFunc();
			break;
		case '2' : CalcLogicFunc();
			break;
		case '3': CalcSeq();
			break;
		case '4': ArrTask();
			break;
		default: work = false;
		}
	}while(work);
	
	return 0;
}

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

bool MyLogicFunc(bool a, bool b, bool c)
{
	return (a && (!b) && (!c)) || ((!a) && b && (!c)) || ((!a) && (!b) && c);
}

void CalcLogicFunc()
{
	bool a, b, c;
	cout << "������� ��� ���������� ����������, ��������� �����, ����� ������, ������ ��� 0 - ��� ����, � �� 0 - ������\n";
	cin >> a;
	cin >> b;
	cin >> c;
	cout << "��������� ����������� ���������, ��� ������, ����� ������ ���� ���������� - ������, � ��������� - ����:\n"
		<< (MyLogicFunc(a, b, c) ? "True\n" : "False\n");
}

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
	cout << "������� � ��� ���������� (sin(x))^2\n";
	cin >> x;
	do
	{
		n++;
		res = FuncForSeq(n, x);
		sum += res;
	} while (res > EPS);
	cout << "����� ���� ������� �������\n";
	cout << sum << endl;
	cout << "\n�������������� �������\n"
		<< sin(x) * sin(x) << endl;
}

int GetRowCount()
{
	bool deny;
	int m;
	do
	{
		deny = false;
		cout << "������� ����� �����, ������ ��� ������ ������\n";
		cin >> m;
		system("cls");
		if ((m > M) || (m < 0))
		{
			cout << "������� �������� �����, ��������� ���� ��� ������� 0 ��� ������\n";
			deny = true;
		}
	} while (deny);
	if (m == 0)
	{
		return -1;
	}
	return m;
}

int GetColCount()
{
	bool deny;
	int n;
	do
	{
		deny = false;
		cout << "������� ����� ��������, ������ ��� ������ ����\n";
		cin >> n;
		system("cls");
		if ((n > N) || (n < 0))
		{
			cout << "������� �������� �����, ��������� ���� ��� ������� 0 ��� ������\n";
			deny = true;
		}
	} while (deny);
	if (n == 0)
	{
		return -1;
	}
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
	int m = GetRowCount();
	int n = GetColCount();
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
	cout << "\n����� ������������� ��������� ��� ������ ������:\n";
	PrintSumArr(arr, m, n);
	delete[] minmax;
	delete[] arr;
}
