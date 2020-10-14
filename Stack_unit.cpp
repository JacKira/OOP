#include "Stack_unit.h"
#include "Artist.h"
Stack_unit::Stack_unit(const Artist& a)
{
	this->_data = a;
	this->_ptr = NULL;
	this->_count = 1;
}

Stack_unit::Stack_unit()
{
	this->_ptr = NULL;
}

Stack_unit& Stack_unit ::operator=(const Stack_unit& s)
{
	this->_data = s._data;
	this->_ptr = s._ptr;
	return *this;
}

Stack_unit operator+(const Stack_unit& s, const Artist& d)
{
	Stack_unit _new = s;
	_new += d;
	return _new;
}

Stack_unit& Stack_unit ::operator+=(const Artist& d)
{
	this->push(d);
	return *this;
}

Artist& Artist ::operator=(const Artist& d)
{
	this->_artist = d._artist;
	this->_dateOfBirth = d._dateOfBirth;
	this->_dateOfDeath = d._dateOfDeath;
	return *this;
}

Stack_unit operator-(const Stack_unit& s, const Artist& d)
{
	Stack_unit _new = s;
	_new -= d;
	return _new;
}

Stack_unit& Stack_unit ::operator-=(const Artist& d)
{
	if (this->_data == d) {
		this->pop();
	}
	return *this;
}

void Stack_unit::push(const Artist& d)
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

Artist Stack_unit::pop()
{
	Artist a = this->_data;
	if (this->_count > 1) {
		Stack_unit* p = _ptr->_ptr;
		Artist d = _ptr->_data;
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

void Stack_unit::RemoveAll()
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

Stack_unit :: ~Stack_unit()
{
	if (this->_count > 0) {
		RemoveAll();
	}
}

void Stack_unit::PrintStack()
{
	while (this->_count)
	{
		pop().PrintData();
	}
}

int Stack_unit::GetCount()
{
	int n = this->_count;
	return n;
}