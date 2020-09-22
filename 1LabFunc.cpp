#include <iostream>
#include <cmath>
#include <stdlib.h>
#include <fstream>

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
double **GetArr(int m, int n);
void InputArr(char filename[], double **&arr, int m, int n);
void OutputArr(double **&arr, int m, int n);
void DelArr(double **&arr, int m);

int main(int argc, char *argv[])
{
	int m = GetRowCount();
	int n = GetColCount();
	char filename[] = "nums.txt";
	double **arr = GetArr(m, n);
	InputArr(filename, arr, m, n);
	OutputArr(arr, m, n);
	DelArr(arr, m);
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
	cout << "\nВведите x для вычисления функции с A = " << A << "; и B = " << B << endl;
	cin >> x;
	cout << "Результат F(x) = " << MyFunc(x) << endl;
}

bool MyLogicFunc(bool a, bool b, bool c)
{
	return (a && (!b) && (!c)) || ((!a) && b && (!c)) || ((!a) && (!b) && c);
}

void CalcLogicFunc()
{
	bool a, b, c;
	cout << "Введите три логические переменные, используя числа, через пробел, считая что 0 - это ложь, а не 0 - истина\n";
	cin >> a;
	cin >> b;
	cin >> c;
	cout << "Результат логического выражения, где истина, когда только одна переменная - истина, а остальное - ложь:\n"
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
	cout << "Введите Х для вычисления (sin(x))^2\n";
	cin >> x;
	do
	{
		n++;
		res = FuncForSeq(n, x);
		sum += res;
	} while (res > EPS);
	cout << "Сумма ряда Тейлора функции\n";
	cout << sum << endl;
	cout << "\nМатематическая функция\n"
		 << sin(x) * sin(x) << endl;
}

int GetRowCount()
{
	bool deny;
	int m;
	do
	{
		deny = false;
		cout << "Введите число строк, меньше или равное восьми\n";
		cin >> m;
		system("cls");
		if ((m > M) || (m < 0))
		{
			cout << "Введено неверное число, повторите ввод или введите 0 для выхода\n";
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
		cout << "Введите число столбцов, меньше или равное трем\n";
		cin >> n;
		system("cls");
		if ((n > N) || (n < 0))
		{
			cout << "Введено неверное число, повторите ввод или введите 0 для выхода\n";
			deny = true;
		}
	} while (deny);
	if (n == 0)
	{
		return -1;
	}
	return n;
}

void OutputArr(double **&arr, int m, int n)
{
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << arr[i][j] << "  ";
		}
		cout << endl;
	}
}

void DelArr(double **&arr, int m)
{
	for (int i = 0; i < m; i++)
	{
		delete[] arr[i];
	}
	delete[] arr;
}

double **GetArr(int m, int n)
{
	double **arr = new double *[m];
	for (int i = 0; i < m; i++)
	{
		arr[i] = new double[n];
	}
	return arr;
}

void InputArr(char filename[], double **&arr, int m, int n)
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
				fin >> arr[i][j];
			}
		}
	}
	fin.close();
}

/*    ifstream fin("file.txt");
    if (!fin) cout << "Error!" << endl;
    else
    {
        int cols;
        int rows;
        char str[10];
        
        fin >> str >> cols;
        fin >> str >> rows;
 
        double** arr = new double*[rows];
        for (int i = 0; i < rows; ++i)
            arr[i] = new double[cols];
 
        for (int i = 0; i < rows; ++i)
            for ( int j = 0; j < cols; ++j)
                fin >> arr[i][j];
 
        fin.close();
    }
    
   */