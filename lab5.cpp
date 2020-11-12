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
	char filename[] = "nums.txt";
	DynArr minmax;
	DynArr arr(m, n);
	arr.InputArr(filename);
	minmax.SetArr(arr.GetArrAftProc(), minmax_m, 1);
	cout << "Исходный массив" << endl;
	arr.OutputArr();
	cout << endl;
	cout << "Массив, сформированный после обработки:\n";
	minmax.OutputArr();
	cout << "\nСумма отрицательных элементов каждого столбца:\n";
	arr.PrintSumArr();
	*filename = *("output.txt");
	arr.OutputArrToFile(filename);





	/*char filename[] = "data.txt";
	ifstream fin(filename);
	if (!fin)
	{
		cout << "Файл не открыт\n\n";
		return -1;
	}
	Stack_unit stack;
	List list;
	string art1, art2, date1, date2;
	while (!fin.eof())
	{
		fin >> art1;
		fin >> art2;
		fin >> date1;
		fin >> date2;
		Artist artist(art1 + ' ' + art2, date1, date2);
		stack += artist;
		list += artist;
	}
	fin.close();
	
	stack.Print();
	cout << endl;
	list.Print();
	cout << endl << "Stack size: " << stack.GetCount() << endl;
	cout << endl << "List size: " << list.GetCount() << endl;
	Artist *search;
	string for_search = "Икэно";
	search = list.Find(for_search);
	if (search != NULL) {
		cout << "Найденная запись\n";
		search->PrintDataRow();
		//Удалим найденную запись из листа
		list -= search->GetArtist();
		cout << "\nЛист без записи о " + search->GetArtist() + "\n\n";
		list.Print();
	}
	else
	{
		cout << "Запись не найдена\n";
	}
	list.RemoveAll();
	cout << endl;
	*/
	system("pause");
	return 0;
}


