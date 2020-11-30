#include <iostream>
#include <fstream>
#include <string>
#include "Artist.h"
#include "Stack_unit.h"
#include "Utils.h"
#include "List.h"
#include "DynArr.h"


using namespace std;
string* ParseToThree(const string s, const char c);
long ToInt(const string &s);


int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	bool deny;
	int m;
	int n;
	do {
		deny = false;
		cout << "Введите размерность массива для количества элементов не больше 24\n";
		m = GetRowCount();
		n = GetColCount();
		system("cls");
		if ((m * n) > 24 || (m < 0) || (n < 0))
		{
			cout << "Размеры массива введены некорректно\n";
			deny = true;
		}

	} while (deny);
	int minmax_m = m / 2;
	char* filename = "nums.txt\0";
	DynArr minmax;
	DynArr arr(m, n);
	arr.InputArrFromTxt(filename);
	minmax.SetArr(arr.GetArrAftProc(), minmax_m, 1);
	cout << "Исходный массив" << endl;
	arr.OutputArr();
	cout << endl;
	cout << "Массив, сформированный после обработки:\n";
	minmax.OutputArr();
	cout << "\nСумма отрицательных элементов каждого столбца:\n";
	arr.PrintSumArr();
	filename = "output.txt\0";
	arr.OutputArrToFileTxt(filename);

	filename = "data.txt\0";
	Stack_unit new_stack(filename);
	cout << "\nВывод данных, считанных из файла txt в файл txt\n";
	filename = "dataout.txt\0";
	new_stack >> filename;
	cout << endl;
	cout << "\nВывод данных, считанных из файла txt, который заполнили данными из файла txt\n";
	new_stack << filename;
	new_stack.Print();
	cout << endl;

	cout << endl;

	
	system("pause");
	return 0;
}


