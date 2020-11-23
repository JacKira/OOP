#include <iostream>
#include <fstream>
#include <string>
#include "Data.h"
#include "StackNumTempl.h"
#include "Utils.h"


using namespace std;


template <class T>
class Data
{
private:
	T _dat;
public:
	Data();
	Data(T& data);
	T& GetData();
	void SetData(T& data);
	Data<T>& operator=(const Data& s);
	friend Data<T> operator+(Data& a, const Data& b);
	Data<T>& operator+=(const Data& d);
	friend Data<T> operator-(Data& a, const Data& b);
	Data& operator-=(const Data& d);
	bool operator==(const Data& d);
	bool operator!=(const Data& d);
	bool operator>(const Data& d);
	bool operator<(const Data& d);
	bool operator<=(const Data& d);
	bool operator>=(const Data& d);
	void PrintData();

};


template<class T>
class StackNumTempl
{
private:
	int _count = 0;
	Data<T> _data;
	StackNumTempl* _ptr;

public:
	StackNumTempl(const Data<T>& a);
	StackNumTempl();
	~StackNumTempl();
	void RemoveAll();
	void Print();
	void push(const Data<T>& d);
	Data<T> pop();
	int GetCount();
	Data<T>& GetMax();
};


int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	string str = "olleH\0";
	StackNumTempl<int> stack_int;
	StackNumTempl<double> stack_double;
	StackNumTempl<char> stack_char;
	for (int i = 0; i < str.size(); i++)
	{
		stack_int.push(Data<int>(i));
		double d = i;
		stack_double.push(Data<double>(d));
		stack_char.push(Data<char>(str[i]));
	}
	stack_char.Print();
	Data<int> max_int = stack_int.GetMax();
	Data<double> max_double = stack_double.GetMax();
	cout << "Максимальное целочисленное и вещественное значение: " << endl;
	max_int.PrintData();
	max_double.PrintData();
	return 0;
}


template<class T>
StackNumTempl<T>::StackNumTempl(const Data<T>& a)
{
	this->_data = a;
	this->_ptr = NULL;
	this->_count = 1;
}

template<class T>
StackNumTempl<T>::StackNumTempl()
{
	this->_ptr = NULL;
}


template<class T>
void StackNumTempl<T>::push(const Data<T>& d)
{
	if (this->_count > 0) {
		StackNumTempl<T>* p = new StackNumTempl<T>(this->_data);
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
Data<T> StackNumTempl<T>::pop()
{
	Data<T> a = this->_data;
	if (this->_count > 1) {
		StackNumTempl<T>* p = _ptr->_ptr;
		Data<T> d = _ptr->_data;
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
void StackNumTempl<T>::RemoveAll()
{
	StackNumTempl<T>* cptr, * pptr;
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
StackNumTempl<T> :: ~StackNumTempl()
{
	if (this->_count > 0)
	{
		RemoveAll();
	}
}

template<class T>
void StackNumTempl<T>::Print()
{
	while (this->_count)
	{
		this->pop().PrintData();
	}
}

template<class T>
int StackNumTempl<T>::GetCount()
{
	int n = this->_count;
	return n;
}

template<class T>
Data<T>& StackNumTempl<T>::GetMax()
{
	T max = 0;
	T crnt;
	while (this->_count)
	{
		crnt = this->pop().GetData();
		if (crnt > max)
		{
			max = crnt;
		}
	}
	return Data<T>(max);
}


template<class T>
Data<T>::Data()
{
	this->_dat = 0;
}

template<class T>
Data<T>::Data(T& data)
{
	this->_dat = data;
}

template<class T>
T& Data<T>::GetData()
{
	T new_d = this->_dat;
	return new_d;
}

template<class T>
void Data<T>::SetData(T& data)
{
	this->_dat = data;
}

template<class T>
Data<T>& Data<T>::operator=(const Data<T>& data)
{
	this->_dat = data._dat;
	return *this;
}

template<class T>
Data<T>& Data<T>::operator+=(const Data& d)
{
	this->_dat += d._dat;
	return *this;
}

template<class T>
Data<T>& Data<T>::operator-=(const Data<T>& d)
{
	this->_dat -= d._dat;
	return *this;
}

template<class T>
bool Data<T>::operator==(const Data& d)
{
	return this->_dat == d._dat;
}

template<class T>
bool Data<T>::operator!=(const Data& d)
{
	return this->_dat != d._dat;
}

template<class T>
bool Data<T>::operator>(const Data& d)
{
	return this->_dat > d._dat;
}

template<class T>
bool Data<T>::operator<(const Data& d)
{
	return this->_dat < d._dat;
}

template<class T>
bool Data<T>::operator<=(const Data& d)
{
	return this->_dat <= d._dat;
}

template<class T>
bool Data<T>::operator>=(const Data& d)
{
	return this->_dat >= d._dat;
}

template<class T>
void Data<T>::PrintData()
{
	cout << "\n===";
	cout << "\n\|" << this->_dat << "\|\n";
	cout << "===\n";
}

template<class T>
Data<T> operator+(Data<T>& a, const Data<T>& b)
{
	Data<T> _new(a._dat);
	_new += b;
	return _new;
}

template<class T>
Data<T> operator-(Data<T>& a, const Data<T>& b)
{
	Data<T> _new(a._dat);
	_new -= b;
	return _new;
}


