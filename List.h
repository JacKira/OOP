#pragma once
#include "Artist.h"
#include "Utils.h"
#include <iostream>

using namespace std;

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
