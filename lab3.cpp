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
	int count = 0;
public:
	MyData data;
	Stack* ptr;
	Stack(MyData a)
	{
		data = a;
		ptr = NULL;
		count = 1;
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
	MyData pop();
	void RemoveAll();
	void PrintStack();
	int GetCount();
};

int main(int argc, char* argv[])
{
	MyData a(1);
	Stack s;
	
	cout << s.GetCount() << endl;
	for (int i = 0; i < 100000; i++)
		s.push(a);
	cout << s.GetCount() << endl;
	for (int i = 0; i < 99995; i++)
		s -= a;
	cout << s.GetCount() << endl;
	s.PrintStack();
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
	if (data == d) {
		pop();
	}
	return *this;
}

void Stack::push(const MyData& d)
{
	if (count > 0) {
		Stack* p = new Stack(this->data);
		(*p).ptr = this->ptr;
		(*p).count = -1;
		this->count++;
		this->data = d;
		this->ptr = p;
	}
	else {
		this->data = d;
		this->count = 1;
	}
}

MyData Stack::pop()
{
	MyData a = this->data;
	if (count > 1) {
		Stack* p = ptr->ptr;
		MyData d = ptr->data;
		delete this->ptr;
		this->data = d;
		this->ptr = p;
	}
	else {
		this->ptr = NULL;
	}
	this->count--;
	return a;
};

void Stack::RemoveAll()
{
	Stack* cptr, *pptr;
	cptr = this->ptr;
	while (cptr != NULL)
	{
		pptr = cptr;
		cptr = cptr->ptr;
		delete pptr;
		pptr = NULL;
	}
	this->ptr = NULL;
	this->count = 0;
}

Stack :: ~Stack()
{
	if (count > 0) {
		RemoveAll();
	}
}

void Stack::PrintStack()
{
	while (this->count)
	{
		pop().PrintData();
	} 
}

int Stack::GetCount()
{
	int n = count;
	return n;
}
