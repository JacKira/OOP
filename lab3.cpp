#include <iostream>
#include <string>
#include "Artist.h"
#include "Stack_unit.h"
#include "Utils.h"

using namespace std;
string* ParseToThree(const string s, const char c);
long ToInt(const string &s);

class List {
private:
	Artist _data;
	List* _left = NULL;
	List* _right = NULL;
	List* _head = this;
	List* _main = this;
	int _count = 0;
public:
	List();
	List(const Artist& d);
	~List();
	List& operator=(const List& l);
	friend const List operator+(const List& a, const Artist& d);
	List& operator+=(const Artist& d);
	friend const List operator-(List& a, const string& artist);
	List& operator-=(const string& artist);
	void Add(const Artist& d);
	bool Remove(const string& s);
	Artist* Find(const string& artist);
	void RemoveAll();
	//Artist operator[](int i); */
	void Print();
	int GetCount();
};

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	Artist a1("fqf", "01.10.1000", "01.20.1000"), a2("fasfsaf", "10.20.1000", "10.20.3000");
	List l;
	system("pause");
	for (int i = 0; i < 5; i++) {
		l += (a1);
		l += (a2);

	}
	l.Print();
	cout << endl;
	l.RemoveAll();
	system("pause");
	return 0;
}

List::List()
{
	this->_head = this;
	this->_left = NULL;
	this->_right = NULL;
	this->_main = this;
}

List::List(const Artist& d)
{
	this->_data = d;
	this->_count = 1;
	this->_head = this;
	this->_left = NULL;
	this->_right = NULL;
	this->_main = this;
}

List :: ~List()
{
	if (this == this->_main) {
		RemoveAll();
	}
}
List& List :: operator=(const List& l) {
	if (this == &l) {
		return *this;
	}
	List* cptr;
	cptr = l._head;
	while (cptr != NULL) {
		this->Add(cptr->_data);
		cptr = cptr->_right;
	}
	return *this;
}

void List::Add(const Artist& d)
{
	if (this->_count == 0)
	{
		this->_data = d;
		this->_head = this;
		this->_main = this;
		this->_count = 1;
		return;
	}
	List* cptr, *pptr;
	cptr = this->_head;
	pptr = NULL;
	while (cptr != NULL) {
		if (cptr->_data > d) {
			break;
		}
		pptr = cptr;
		cptr = cptr->_right;
	}
	List* _new = new List(d);
	_new->_main = this;
	_new->_head = this->_head;
	_new->_left = pptr;
	_new->_right = cptr;
	_new->_count = -1;
	this->_count++;
	if (cptr != NULL) {
		
		if (pptr != NULL) {
			pptr->_right = _new;
		}
		else {
			this->_head = _new;			
		}
		cptr->_left = _new;
		_new->_right = cptr;
	}
	else
	{
		if (pptr != NULL) {
			pptr->_right = _new;
		}	
	}
}

void List::Print()
{
	List* cptr;
	cptr = this->_head;

	while (cptr != NULL) {
		cout << endl;
		cptr->_data.PrintData();
		cptr = cptr->_right;
	}

}

int List::GetCount() {
	int i = this->_count;
	return i;
}

bool List :: Remove(const string& s)
{
	List* cptr, * pptr, *r;
	cptr = this->_head;
	pptr = NULL;
	int n = this->_count;
	for(int i = 0; (i < n) && (cptr != NULL); i++ )
	{
		if (IsInStr(cptr->_data.GetArtist(), s)) 
		{
			if (i == 0)
			{
				r = cptr->_right;
				r->_left = NULL;
				this->_head = r;
			}
			if ((i > 0) && i < (this->_count - 1))
			{
				r = cptr->_right;
				pptr->_right = r;
				r->_left = pptr;
			}
			if (i == (this->_count - 1))
			{
				pptr->_right = NULL;
			}
			if (cptr == this->_main) 
			{
				this->_left = NULL;
				this->_right = NULL;
				this->_count--;
				return true;
			}
			delete cptr;
			this->_count--;
			return true;
		}
		pptr = cptr;
		cptr = cptr->_right;
	}
	return false;
}


const List operator+(const List& s, const Artist& d)
{
	List _new = s;
	_new += d;
	return _new;
}

List& List ::operator+=(const Artist& d)
{
	this->Add(d);
	return *this;
}


const List operator-(const List& s, const string& artist)
{
	List _new = s;
	_new -= artist;
	return _new;
}

List& List ::operator-=(const string& artist)
{
	this->Remove(artist);
	return *this;
}

Artist* List::Find(const string &artist)
{
	List *cptr;
	int n = this->_count;
	cptr = this->_head;
	for (int i = 0; (i < n) && (cptr != NULL); i++)
	{
		if (IsInStr(cptr->_data.GetArtist(), artist))
		{
			return new Artist(cptr->_data);
		}
		cptr = cptr->_right;
	}
	return NULL;
}

void List :: RemoveAll()
{
	List *cptr, *pptr, *p;
	int n = this->_count;
	cptr = this->_head;
	while(cptr != NULL)
	{
		pptr = cptr;
		cptr = cptr->_right;
		if (pptr != this->_main)
		{
			delete pptr;	
		}
		
		this->_count--;
	}
	this->_head = this->_main;
	this->_right = NULL;
	this->_left = NULL;
}






