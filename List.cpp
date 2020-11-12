#include "List.h"


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
	List* cptr, * pptr;
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
		cptr->_data.PrintDataRow();
		cptr = cptr->_right;
	}

}

int List::GetCount() {
	int i = this->_count;
	return i;
}

bool List::Remove(const string& s)
{
	List* cptr, * pptr, * r;
	cptr = this->_head;
	pptr = NULL;
	int n = this->_count;
	for (int i = 0; (i < n) && (cptr != NULL); i++)
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

Artist* List::Find(const string& artist)
{
	List* cptr;
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

void List::RemoveAll()
{
	List* cptr, * pptr, * p;
	int n = this->_count;
	cptr = this->_head;
	while (cptr != NULL)
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




