#include <iostream>
#include <string>
#include "Artist.h"
#include "Stack_unit.h"

using namespace std;
string* ParseToThree(const string s, const char c);
long ToInt(const string &s);

class List {
private:
	Artist _data;
	List* _left;
	List* _right;
	List* _head;
	int _count = 0;
public:
	List();
	List(const Artist& d);
	void Add(const Artist& d);
  /*void Remove(const Artist& d);
	Artist Find(const char* artist);
	void RemoveAll();
	void Print();
	Artist operator[](int i); */
	List& operator=(const List& l);
};

int main(int argc, char* argv[])
{	
	return 0;
}

List::List() {
	this->_head = this;
	this->_left = this->_right = NULL;
}

List::List(const Artist& d) {
	this->_data = d;
	this->_left = this->_right = NULL;
	this->_head = this;
	this->_count = 1;
}

List& List :: operator=(const List& l) {
	this->_data = l._data;
	this->_left = l._left;
	this->_right = l._right;
	this->_head = l._head;
	this->_count = l._count;
	return *this;
}

void List::Add(const Artist& d)
{
	if (this->_count == 0)
	{
		this->_data = d;
		this->_head = this;
		this->_count = 1;
		return;
	}

	List* cptr, *pptr;
	cptr = pptr = this->_head;
	while (cptr != NULL) {
		if (cptr->_data > d) {
			break;
		}
		pptr = cptr;
		cptr = cptr->_right;
	}

	if (cptr != NULL) {
		List* _new = new List(d);
		_new->_head = this->_head;
		_new->_left = pptr;
		_new->_right = cptr;
		_new->_count = -1;
		this->_head->_count++;
		return;
	}
	else
	{
		List* _new = new List(d);
		_new->_head = this->_head;
		_new->_left = pptr;
		_new->_count = -1;
		this->_head->_count++;
		return;
	}
}





