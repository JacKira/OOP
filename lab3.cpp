#include <iostream>
#include <string>
#include <ctime>

using namespace std;

class MyData
{
protected:
	string _artist = "\0";
	string _dateOfBirth = "\0";
	string _dateOfDeath = "\0";

public:
	bool operator==(const MyData& d);
	bool operator!=(const MyData& d);
	MyData(const string artist, const string dateFrom, const string dateTo);
	MyData() {};
	MyData& operator=(const MyData& d);
	void PrintData();
};

class Stack
{
private:
	int _count = 0;
	MyData _data;
	Stack* _ptr;
public:
	
	Stack(const MyData &a)
	{
		this->_data = a;
		_ptr = NULL;
		_count = 1;
	};
	Stack()
	{
		_ptr = NULL;
	};
	~Stack();
	Stack& operator=(const Stack& s);
	friend Stack operator+(Stack& a, const MyData& d);
	Stack& operator+=(const MyData& d);
	friend Stack operator-(Stack& a, const MyData& d);
	Stack& operator-=(const MyData& d);
	void push(const MyData& d);
	MyData pop();
	void RemoveAll();
	void PrintStack();
	int GetCount();
};

int main(int argc, char* argv[])
{	
	setlocale(LC_ALL, "RUS");
	MyData a("Ivozovsky", "19.19.2020", "19.18.2020");
	a.PrintData();
	system("pause");
	return 0;
}

MyData::MyData(const string artist,const string dateFrom,const string dateTo)
{
	this->_artist = string(artist);
	if ((this->_artist.length() % 2) != 0) {
		this->_artist += ' ';
	}
	this->_dateOfBirth = string(dateFrom);
	this->_dateOfDeath = string(dateTo);
}

bool MyData ::operator==(const MyData& d)
{
	return ((this->_artist == d._artist) && (this->_dateOfBirth == d._dateOfBirth) && (this->_dateOfDeath == d._dateOfDeath));
}

bool MyData ::operator!=(const MyData& d)
{
	return !(*this == d);
}

void MyData::PrintData()
{
	int n = (this->_artist.size() > this->_dateOfBirth.size() ? this->_artist.size() : this->_dateOfBirth.size());
	string s1(n + 2, '='), s2(n + 2, '-'), s3((n - this->_dateOfDeath.size()) / 2, ' ');
	cout << "#" + s1 + "#\n";
	cout << "# " + this->_artist + string( n - this->_artist.size(), ' ') +  " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + this->_dateOfBirth + s3 + " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + this->_dateOfDeath + s3 + " #\n";
	cout << "#" + s1 + "#\n";
}

Stack& Stack ::operator=(const Stack& s)
{
	this->_data = s._data;
	this->_ptr = s._ptr;
	return *this;
}

Stack operator+(const Stack& s, const MyData& d)
{
	Stack _new = s;
	_new += d;
	return _new;
}

Stack& Stack ::operator+=(const MyData& d)
{
	this->push(d);
	return *this;
}

MyData& MyData ::operator=(const MyData& d)
{
	this->_artist = d._artist;
	this->_dateOfBirth = d._dateOfBirth;
	this->_dateOfDeath = d._dateOfDeath;
	return *this;
}

Stack operator-(const Stack& s, const MyData& d)
{
	Stack _new = s;
	_new -= d;
	return _new;
}

Stack& Stack ::operator-=(const MyData& d)
{
	if (this->_data == d) {
		this->pop();
	}
	return *this;
}

void Stack::push(const MyData& d)
{
	if (this->_count > 0) {
		Stack* p = new Stack(this->_data);
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

MyData Stack::pop()
{
	MyData a = this->_data;
	if (this->_count > 1) {
		Stack* p = _ptr->_ptr;
		MyData d = _ptr->_data;
		delete this->_ptr;
		this->_data = d;
		this->_ptr = p;
	}
	else {
		this->_ptr = NULL;
	}
	this->_count--;
	return a;
};

void Stack::RemoveAll()
{
	Stack* cptr, *pptr;
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

Stack :: ~Stack()
{
	if (this->_count > 0) {
		RemoveAll();
	}
}

void Stack::PrintStack()
{
	while (this->_count)
	{
		pop().PrintData();
	} 
}

int Stack::GetCount()
{
	int n = this->_count;
	return n;
}
