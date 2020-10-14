#pragma once
#include "Artist.h"
using namespace std;
class Stack_unit
{
private:
	int _count = 0;
	Artist _data;
	Stack_unit* _ptr;
	
public:
	Stack_unit(const Artist &a);
	Stack_unit();
	~Stack_unit();
	Stack_unit& operator=(const Stack_unit& s);
	friend Stack_unit operator+(Stack_unit& a, const Artist& d);
	Stack_unit& operator+=(const Artist& d);
	friend Stack_unit operator-(Stack_unit& a, const Artist& d);
	Stack_unit& operator-=(const Artist& d);
	void RemoveAll();
	void Print();
	void push(const Artist& d);
	Artist pop();
	int GetCount();
};

