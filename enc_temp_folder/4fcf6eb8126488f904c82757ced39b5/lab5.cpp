#include <iostream>
#include <fstream>
#include <string>
#include <stack>
#include "Utils.h"
#include "DynArr.h"



using namespace std;
string* ParseToThree(const string s, const char c);
long ToInt(const string &s);

class Artist
{
private:
	void PrintDataWithWidth();
protected:
	string _artist = "\0";
	int _dateOfBirth[3] = { 0, 0, 0 };
	int _dateOfDeath[3] = { 0, 0, 0 };

public:
	bool operator==(const Artist& d);
	bool operator!=(const Artist& d);
	bool operator>(const Artist& d);
	Artist(ifstream& finstr);
	Artist(const string artist, const string dateFrom, const string dateTo);
	Artist() {};
	Artist& operator=(const Artist& d);
	void PrintDataRow();
	void InputDataRowFromFileTxt(ifstream& fin);
	int InputDataRowFromFileBin(ifstream& fin);
	void PrintDataRowToFileTxt(ofstream& fout, int width = 60);
	void PrintDataRowToFileBin(ofstream& fout, int width = 60);
	string GetArtist();
	friend ifstream& operator>> (ifstream& in, Artist& art);
	friend ofstream& operator<< (ofstream& out, const Artist& art);
	friend ostream& operator<< (ostream& out, const Artist& art);
	int* GetBirthDate();
	int* GetDeathDate();
	void SetAtrist(string artist);
	void SetBirthDate(int date[3]);
	void SetDeathDate(int date[3]);
};




template<class T>
class Stack_unit
{
private:
	int _count = 0;
	T _data;
	Stack_unit* _ptr;

public:
	Stack_unit(const T& a);
	Stack_unit();
	Stack_unit(char filename[]);
	~Stack_unit();
	Stack_unit& operator=(const Stack_unit& s);
	friend Stack_unit operator+(Stack_unit& a, const T& d);
	Stack_unit& operator+=(const T& d);
	friend Stack_unit operator-(Stack_unit& a, const T& d);
	Stack_unit& operator-=(const T& d);
	Stack_unit& operator--();
	Stack_unit& operator--(int);
	void RemoveAll();
	void Print();
	void OutputToFileTxt(char filename[]);
	void InputFormFileTxt(char filename[]);
	void push(const T& d);
	T pop();
	int GetCount();
	void operator<<(string filename);
	void operator>>(string filename);
};

template<class T>
void operator>>(stack<T> &stack, string filename);

template<class T>
void operator<<(stack<T> &stack, string filename);

template<class T>
void Print(stack<T> &stack);


int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	bool deny;
	int m;
	int n;
	do {
		try
		{
			cout << "Введите размерность массива для количества элементов не больше 24\n";
			m = GetRowCount();
			n = GetColCount();
			system("cls");
			DynArr arr(m, n);
			int minmax_m = m / 2;
			char* filename = "nums.txt\0";
			DynArr minmax;
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
			deny = false;
		}
		catch (int s) {
			deny = true;
		}
	} while (deny);
	

	char* filename = "data.txt\0";
	//char* filename = "nums.txt\0";
	Stack_unit<Artist> new_stack(filename);
	cout << "\nВывод данных, считанных из файла txt в файл txt\n";
	filename = "dataout.txt\0";
	new_stack >> filename;
	cout << endl;
	cout << "\nВывод данных, считанных из файла txt, который заполнили данными из файла txt\n";
	new_stack << filename;
	new_stack.Print();
	cout << endl;

	
	filename = "nums.txt\0";
	cout << endl;
	cout << "\nВывод данных, считанных из файла для массива\n";
	Stack_unit<int> new_stack_int(filename);
	new_stack_int.Print();
	cout << endl;
	cout << endl;


	// Стек с наследованием стека библиотеки STL
	cout << "\nБЛОК РАБОТЫ С БИБЛИОТЕКОЙ STL\n";
	filename = "data.txt\0";
	stack<Artist> new_stackSTL;
	new_stackSTL << filename;
	cout << "\nВывод данных, считанных из файла txt в файл txt\n";
	filename = "dataout.txt\0";
	new_stackSTL >> filename;
	cout << endl;
	cout << "\nВывод данных, считанных из файла txt, который заполнили данными из файла txt\n";
	new_stackSTL << filename;
	Print(new_stackSTL);
	cout << endl;

	
	filename = "nums.txt\0";
	cout << endl;
	cout << "\nВывод данных, считанных из файла для массива\n";
	stack<int> new_stackSTL_int;
	new_stackSTL_int << filename;
	Print(new_stackSTL_int);
	cout << endl;
	cout << endl;

	
	system("pause");
	return 0;
}


#include "Artist.h"
#include <iostream>
#include "Utils.h"
using namespace std;


Artist::Artist(const string artist, const string dateFrom, const string dateTo)
{
	this->_artist = string(artist);
	if ((this->_artist.length() % 2) != 0) {
		this->_artist += ' ';
	}
	string* s1 = ParseToThree(dateFrom, '.');
	string* s2 = ParseToThree(dateTo, '.');
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = ToInt(s1[i]);
		this->_dateOfDeath[i] = ToInt(s2[i]);
	}
	delete[] s1;
	delete[] s2;

}

void Artist::PrintDataWithWidth()
{
	const int size = 98;
	int n = this->_artist.size();
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " - " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	int m = dateStr.size();
	string s1(size, '=');
	cout.width(100);
	cout << "#" + s1 + "#\n# " + this->_artist + string(size - n - m - 4, ' ') + "| " + dateStr + " #\n#" + s1 + "#";
}

bool Artist ::operator==(const Artist& d)
{
	bool condition1 = (this->_artist == d._artist);
	bool condition2 = (this->_dateOfBirth[0] == d._dateOfBirth[0]) && (this->_dateOfBirth[1] == d._dateOfBirth[1]) &&
		(this->_dateOfBirth[2] == d._dateOfBirth[2]);
	bool condition3 = (this->_dateOfDeath[0] == d._dateOfDeath[0]) && (this->_dateOfDeath[1] == d._dateOfDeath[1]) &&
		(this->_dateOfDeath[2] == d._dateOfDeath[2]);
	return (condition1 && condition2 && condition3);
}

bool Artist ::operator!=(const Artist& d)
{
	return !(*this == d);
}

bool Artist :: operator>(const Artist& d) {
	int life1 = this->_dateOfDeath[2] * 365 + this->_dateOfDeath[1] * 30 + this->_dateOfDeath[0] -
		this->_dateOfBirth[2] * 365 + this->_dateOfBirth[1] * 30 + this->_dateOfBirth[0];
	int life2 = d._dateOfDeath[2] * 365 + d._dateOfDeath[1] * 30 + d._dateOfDeath[0] -
		d._dateOfBirth[2] * 365 + d._dateOfBirth[1] * 30 + d._dateOfBirth[0];
	return life1 > life2;
}

Artist::Artist(ifstream& finstr)
{
	if (!(bool)(finstr.binary))
	{
		InputDataRowFromFileBin(finstr);
	}
	else {
		InputDataRowFromFileTxt(finstr);
	}

}

Artist& Artist ::operator=(const Artist& d)
{
	this->_artist = d._artist;
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = d._dateOfBirth[i];
		this->_dateOfDeath[i] = d._dateOfDeath[i];
	}
	return *this;
}

void Artist::PrintDataRow()
{
	PrintDataWithWidth();
}





void Artist::PrintDataRowToFileTxt(ofstream& fout, int _width)
{
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	int n = this->_artist.size();
	int m = dateStr.size();
	string outStr = this->_artist + string(_width - n - m - 1, ' ') + dateStr;
	cout.width(100);
	fout << outStr;
}

void Artist::PrintDataRowToFileBin(ofstream& fout, int _width)
{
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	int n = this->_artist.size();
	int m = dateStr.size();
	string outStr = this->_artist + string(_width - n - m - 1, ' ') + dateStr + "\n";
	for each (char b in outStr)
	{
		fout.write((char*)&b, sizeof(b));
	}
}





string Artist::GetArtist() {
	string art = this->_artist;
	return art;
}



void Artist::InputDataRowFromFileTxt(ifstream& fin)
{
	string art1, art2, date1, date2;
	fin >> art1;
	fin >> art2;
	fin >> date1;
	fin >> date2;
	//Finish read Date of Death
	this->_artist = art1 + ' ' + art2;
	string* s1 = ParseToThree(date1, '.');
	string* s2 = ParseToThree(date2, '.');
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = ToInt(s1[i]);
		this->_dateOfDeath[i] = ToInt(s2[i]);
	}
}

int Artist::InputDataRowFromFileBin(ifstream& fin)
{

	char b;
	int endOfFile = 0;
	string artist, dateFrom, dateTo, s = "";
	fin.read((char*)&b, sizeof(b));
	//Start read Artsit
	while (b != ' ')
	{
		s += b;
		fin.read((char*)&b, sizeof(b));
	}
	artist = s;

	fin.read((char*)&b, sizeof(b));
	while (b == ' ')
	{
		fin.read((char*)&b, sizeof(b));
	}

	s = "";
	s += b;
	fin.read((char*)&b, sizeof(b));
	while (b != ' ')
	{
		s += b;
		fin.read((char*)&b, sizeof(b));
	}
	artist += ' ' + s;
	//Finish read Artist

	//Start read Date of Birth
	fin.read((char*)&b, sizeof(b));
	while (b == ' ')
	{
		fin.read((char*)&b, sizeof(b));
	}

	s = "";
	s += b;
	fin.read((char*)&b, sizeof(b));
	while (b != ' ')
	{
		s += b;
		fin.read((char*)&b, sizeof(b));
	}
	dateFrom = s;
	//Finish read Date of Birth

	//Start read Datd of Death
	fin.read((char*)&b, sizeof(b));
	while (b == ' ')
	{
		fin.read((char*)&b, sizeof(b));
	}

	s = "";
	s += b;
	fin.read((char*)&b, sizeof(b));
	while ((b != ' ') && (b != '\n') && !fin.eof())
	{
		s += b;
		fin.read((char*)&b, sizeof(b));
	}
	dateTo = s;
	//Finish read Date of Death
	this->_artist = artist;
	string* s1 = ParseToThree(dateFrom, '.');
	string* s2 = ParseToThree(dateTo, '.');
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = ToInt(s1[i]);
		this->_dateOfDeath[i] = ToInt(s2[i]);
	}
	delete[] s1;
	delete[] s2;
	return endOfFile;

}

ifstream& operator>>(ifstream& in, Artist& art)
{
	art.InputDataRowFromFileTxt(in);
	return in;
}

ofstream& operator<<(ofstream& out, Artist& art)
{
	art.PrintDataRowToFileTxt(out);
	return out;
	// TODO: вставьте здесь оператор return
}

ostream& operator<<(ostream& out, Artist& art)
{
	art.PrintDataRow();
	return out;
	// TODO: вставьте здесь оператор return
}



int* Artist::GetBirthDate()
{
	int* date = new int[3];
	for (int i = 0; i < 3; i++)
	{
		date[i] = this->_dateOfBirth[i];
	}
	return date;
}

int* Artist::GetDeathDate()
{
	int* date = new int[3];
	for (int i = 0; i < 3; i++)
	{
		date[i] = this->_dateOfDeath[i];
	}
	return date;
}

void Artist::SetAtrist(string artist)
{
	this->_artist = artist;
}

void Artist::SetBirthDate(int date[3])
{
	for (int i = 0; i < 3; i++)
	{
		this->_dateOfBirth[i] = date[i];
	}
}

void Artist::SetDeathDate(int date[3])
{
	for (int i = 0; i < 3; i++)
	{
		this->_dateOfDeath[i] = date[i];
	}
}



template<class T>
Stack_unit<T>::Stack_unit(const T& a)
{
	this->_data = a;
	this->_ptr = NULL;
	this->_count = 1;
}

template<class T>
Stack_unit<T>::Stack_unit()
{
	this->_ptr = NULL;
}

template<class T>
Stack_unit<T>::Stack_unit(char filename[])
{
	T var;
	this->_ptr = NULL;
	ifstream fin(filename);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	while (!fin.eof()) {
		
		fin >> var;
		this->push(var);
	}
	fin.close();
}

template<class T>
Stack_unit<T>& Stack_unit<T> ::operator=(const Stack_unit& s)
{
	this->_data = s._data;
	this->_ptr = s._ptr;
	return *this;
}

template<class T>
Stack_unit<T> operator+(const Stack_unit<T>& s, const T& d)
{
	Stack_unit _new = s;
	_new += d;
	return _new;
}

template<class T>
Stack_unit<T>& Stack_unit<T> ::operator+=(const T& d)
{
	this->push(d);
	return *this;
}


template<class T>
Stack_unit<T> operator-(const Stack_unit<T>& s, const T& d)
{
	Stack_unit _new = s;
	_new -= d;
	return _new;
}

template<class T>
Stack_unit<T>& Stack_unit<T> ::operator-=(const T& d)
{
	if (this->_data == d) {
		this->pop();
	}
	return *this;
}

template<class T>
void Stack_unit<T>::push(const T& d)
{
	if (this->_count > 0) {
		Stack_unit* p = new Stack_unit(this->_data);
		(*p)._ptr = this->_ptr;
		(*p)._count = -1;
		this->_count++;
		this->_data = d;
		this->_ptr = p;
	}
	else {
		this->_data = d;
		this->_count = 1;
	}
}

template<class T>
T Stack_unit<T>::pop()
{
	T a = this->_data;
	if (this->_count > 1) {
		Stack_unit* p = _ptr->_ptr;
		T d = _ptr->_data;
		delete this->_ptr;
		this->_data = d;
		this->_ptr = p;
		this->_count--;
	}
	else {
		this->_ptr = NULL;
		this->_count = 0;
	}
	return a;
};

template<class T>
void Stack_unit<T>::RemoveAll()
{
	Stack_unit* cptr, * pptr;
	cptr = this->_ptr;
	while (cptr != NULL)
	{
		pptr = cptr;
		cptr = cptr->_ptr;
		delete pptr;
		pptr = NULL;
	}
	this->_ptr = NULL;
	this->_count = 0;
}

template<class T>
Stack_unit<T> :: ~Stack_unit()
{
	if (this->_count > 0) {
		RemoveAll();
	}
}

template<class T>
void Stack_unit<T>::Print()
{
	T var;
	while (this->_count)
	{
		var  = this->pop();
		cout << endl;
		cout << var;
		
	}
}

template<class T>
void Stack_unit<T>::OutputToFileTxt(char filename[])
{
	ofstream fout(filename);
	if (!fout) {
		cout << "Error open output file\n";
		return;
	}
	while (this->_count)
	{
		T el = this->pop();
		fout << endl;
		fout << el;
	}
	fout.close();
}

template<class T>
void Stack_unit<T> ::InputFormFileTxt(char filename[])
{
	ifstream fin(filename);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	T var;
	char b;
	while (!fin.eof()) {
		fin >> var;
		this->push(var);
	}
	fin.close();
}


template<class T>
int Stack_unit<T> ::GetCount()
{
	int n = this->_count;
	return n;
}

template<class T>
void Stack_unit<T> ::  operator>>(string filename)
{
	if (IsInStr(filename, ".txt")) {
		char* c = &filename[0];
		this->OutputToFileTxt(c);
	}
}

template<class T>
void Stack_unit<T> :: operator<<(string filename)
{
	if (IsInStr(filename, ".txt")) {
		char* c = &filename[0];
		this->InputFormFileTxt(c);
	}
}


template<class T>
Stack_unit<T>& Stack_unit<T> :: operator--() {
	this->pop();
	return *this;
}

template<class T>
Stack_unit<T>& Stack_unit<T> :: operator--(int) {
	this->pop();
	return *this;
}



template<class T>
void operator<<(stack<T> &stack, string filename) {
	ifstream fin(filename);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	T var;
	char b;
	while (!fin.eof()) {
		fin >> var;
		stack.push(var);
	}
	fin.close();
}

template<class T>
void  operator>>(stack<T> &stack, string filename) {
	ofstream fout(filename);
	if (!fout) {
		cout << "Error open txt file\n";
		return;
	}
	T var;
	while (stack.size()) {
		var = stack.top();
		stack.pop();
		fout << endl;
		fout << var;
	}
	fout.close();
}

template<class T>
void Print(stack<T> &stack) {
	T var;
	while (stack.size()) {
		var = stack.top();
		stack.pop();
		cout << var << endl;;
	}
}
