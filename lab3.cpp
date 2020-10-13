#include <iostream>

using namespace std;

class MyData
{
protected:
	int a = 0;

public:
	bool operator==(const MyData& d);
	bool operator!=(const MyData& d);
	MyData(int a);
	MyData() {};
	MyData& operator=(const MyData& d);
	void PrintData();
};

class Stack
{
private:
	int length = 1;
public:
	MyData data;
	Stack* ptr;
	Stack(MyData a)
	{
		data = a;
		ptr = NULL;
	};
	Stack()
	{
		ptr = NULL;
	};
	~Stack();
	Stack& operator=(const Stack& s);
	friend Stack operator+(Stack& a, const MyData& d);
	Stack& operator+=(const MyData& d);
	friend Stack operator-(Stack& a, const MyData& d);
	Stack& operator-=(const MyData& d);
	void push(const MyData& d);
	MyData& pop();
	void RemoveAll();
};

int main(int argc, char* argv[])
{
	MyData a(1);
	Stack s(a);
	for(int i = 0; i < 100000; i++)
		s.push(a);
	system("pause");
	s.~Stack();
	system("pause");
	return 0;
}

MyData::MyData(int a)
{
	this->a = a;
}

bool MyData ::operator==(const MyData& d)
{
	return (this->a == d.a);
}

bool MyData ::operator!=(const MyData& d)
{
	return (this->a != d.a);
}

void MyData::PrintData()
{
	cout << this->a << endl;
}

Stack& Stack ::operator=(const Stack& s)
{
	this->data = s.data;
	this->ptr = s.ptr;
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
	push(d);
	return *this;
}

MyData& MyData ::operator=(const MyData& d)
{
	this->a = d.a;
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
	pop();
	return *this;
}

void Stack::push(const MyData& d)
{
	Stack* p = new Stack(this->data);
	(*p).ptr = this->ptr;
	(*p).length = 0;
	this->length++;
	this->data = d;
	this->ptr = p;
}

MyData& Stack::pop()
{
	MyData a = this->data;
	Stack* p = ptr->ptr;
	MyData d = ptr->data;
	delete this->ptr;
	this->data = d;
	this->ptr = p;
	return a;
};

void Stack::RemoveAll() {
	Stack* cptr, * pptr;
	cptr = this->ptr;
	while (cptr != NULL)
	{
		pptr = cptr;
		cptr = cptr->ptr;
		delete pptr;
		pptr = NULL;
	}
	this->ptr = NULL;
}

Stack :: ~Stack() {
	if (length > 1) {
		RemoveAll();
	}
}
