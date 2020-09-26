#include <iostream>
#include <cmath>
#include <stdlib.h>
#include <fstream>

using namespace std;

class FindSeqOfSinX
{
  private:
	double _x;
	double _eps;
	int _n = 0;
	bool _flag_n = false;
	double FuncForSeq(int n, double x);
	int Factorial(int n);

  public:
	FindSeqOfSinX()
	{
		_x = 0.5;
		_eps = 1e-6;
	}
	~FindSeqOfSinX(){};
	FindSeqOfSinX(double x)
	{
		_x = x;
		_eps = 1e-6;
	}
	FindSeqOfSinX(double x, double eps)
	{
		_x = x;
		_eps = eps;
	}
	FindSeqOfSinX(double x, int n)
	{
		_x = x;
		_n = n;
		_flag_n = true;
	}

	double CalcSeq();
};

/*int GetRowCount();
int GetColCount();
double **GetArr(int m, int n);
void InputArr(char filename[], double **&arr, int m, int n);
void OutputArr(double **&arr, int m, int n);
void DelArr(double **&arr, int m);
*/
int main(int argc, char *argv[])
{
	setlocale(LC_ALL, "Russia");
	cout << "Конструктор по умоланию\n";
	FindSeqOfSinX find1;
	find1.CalcSeq();
	cout << "\n======================\n";
	cout << "\nКонструктор с заданным x" << endl;
	FindSeqOfSinX find2(0.5);
	find2.CalcSeq();
	cout << "\n======================\n";
	cout << "\nКонструктор с заданным x и n" << endl;
	FindSeqOfSinX find3(0.5, (int)15);
	find3.CalcSeq();

	cout << "\n======================\n";
	cout << "\nКонструктор с заданным x и заданной точностью" << endl;
	FindSeqOfSinX find4(0.5, 1e-1);
	find4.CalcSeq();
	
		cout << "\n======================\n";
	cout << "\nИспользование массива объектов с варьированием X" << endl;
	double h = 0.1;
	int m = 0.9 / h;
	FindSeqOfSinX** finds = new FindSeqOfSinX*[m];
	for(int i = 0; i < m; i++)
	{
		cout << endl;
		finds[i] = new FindSeqOfSinX(i * h);
		finds[i]->CalcSeq();
		cout << endl;
	}
	
	for(int i = 0; i < m; i++)
	{
		delete finds[i];
	}
	delete[] finds;
	
	
	
	
	return 0;
}

int FindSeqOfSinX ::Factorial(int n)
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

double FindSeqOfSinX ::FuncForSeq(int n, double x)
{
	int one = ((n % 2) ? 1 : -1);
	return one * pow(2, 2 * n - 1) * pow(x, 2 * n) / Factorial(2 * n);
}

double FindSeqOfSinX ::CalcSeq()
{
	double sum = 0, res;
	int n = 0;
	do
	{
		n++;
		res = FuncForSeq(n, _x);
		sum += res;
		if (_flag_n && (n >= _n))
		{
			break;
		}
	} while (_flag_n || (fabs(res) > _eps));
	if (!_flag_n)
	{
		cout << "Сумма ряда Тейлора функции при X = " << _x << " и точности: " << _eps << " , и количестве членов = " << n << endl;
	}
	else
	{
		cout << "Сумма ряда Тейлора функции при X = " << _x << "  и количестве членов = " << n << endl;
	}
	cout << sum << endl;
	cout << "\nМатематическая функция при X = " << _x << endl
		 << sin(_x) * sin(_x) << endl;
	return sum;
}
/*
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