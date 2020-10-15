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
	List* _left;
	List* _right;
	List* _head;
	int _count = 0;
public:
	List();
	List(const Artist& d);
	List operator=(const List& l);
	void Add(const Artist& d);
	bool Remove(const string& s);
	/*Artist Find(const char* artist);
	//void RemoveAll();
	Artist operator[](int i); */
	//friend List operator=(const List& l);
	void Print();
	int GetCount();
};

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "RUS");
	Artist a1("fqf", "01.01.1231", "01.02.1281"), a2("fasfsaf", "01.02.1231", "01.02.1251"), a3("dasdasdasd", "04.03.1211", "01.02.1231"),
		a4("dasdasdasd", "04.03.1211", "01.02.1212");
	List l;
	l.Add(a1);
	l.Add(a2);
	l.Add(a3);
	l.Add(a4);
	List b = l;
	b.Print();
	b.Remove("fqf");
	cout << "\nПосле удаления\n\n";
	b.Print();
	int i = b.GetCount();
	cout << i << endl;
	system("pause");
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

List List :: operator=(const List& l) {
	List _new;
	List* cptr;
	Artist a;
	cptr = l._head;
	while (cptr != NULL) {
		_new.Add(cptr->_data);
		cptr = cptr->_right;
	}
	return _new;
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
	cptr = this->_head;
	pptr = NULL;
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
		if (pptr != NULL) {
			pptr->_right = _new;
		}
		else {
			this->_head = _new;			
		}
		cptr->_left = _new;
		_new->_right = cptr;
		_new->_count = -1;
		this->_count++;
		return;
	}
	else
	{
		List* _new = new List(d);
		_new->_head = this->_head;
		_new->_left = pptr;
		if (pptr != NULL) {
			pptr->_right = _new;
		}
		_new->_count = -1;
		this->_count++;
		return;
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

bool List :: Remove(const string& s) {
	List* cptr, * pptr;
	cptr = this->_head;
	pptr = NULL;
	while (cptr != NULL) {
		if (IsInStr(cptr->_data.GetArtist(), s)) 
		{
			if (cptr == this->_head) {
				if (pptr != NULL) {
					this->_head = pptr;
				}
			}
			if (cptr == this) {
				this->_count = 0;
				return true;;
			}
			if (cptr->_right != NULL) {
				cptr->_right->_left = pptr;
				if (pptr != NULL) {
					pptr->_right = cptr->_right;
				}
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






