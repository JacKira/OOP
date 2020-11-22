#pragma once
#include "Artist.h"
#include <iostream>

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
	Stack_unit(char filename[]);
	~Stack_unit();
	Stack_unit& operator=(const Stack_unit& s);
	friend Stack_unit operator+(Stack_unit& a, const Artist& d);
	Stack_unit& operator+=(const Artist& d);
	friend Stack_unit operator-(Stack_unit& a, const Artist& d);
	Stack_unit& operator-=(const Artist& d);
	Stack_unit& operator--();
	Stack_unit& operator--(int);
	void RemoveAll();
	void Print();
	void OutputToFileTxt(char filename[]);
	void OutputToFileBin(char filename[]);
	void InputFormFileTxt(char filename[]);
	void InputFormFileBin(char filename[]);
	void DeleteMaxFromBin(char filename[]);
	void push(const Artist& d);
	Artist pop();
	int GetCount();
};

