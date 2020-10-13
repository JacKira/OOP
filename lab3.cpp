#include <iostream>

using namespace std;

class MyData
{
  protected:
	int a = 0;

  public:
	bool operator==(const MyData &d);
	bool operator!=(const MyData &d);
	MyData(int a);
	MyData &operator=(const MyData &d);
	MyData(){};
	void PrintData();
};

class Stack
{
  public:
	MyData data;
	Stack *ptr;
	Stack(MyData a)
	{
		data = a;
		ptr = NULL;
	};
	Stack()
	{
		ptr = NULL;
	};
	~Stack(){};
	Stack &operator=(const Stack &s);
	friend Stack operator+(Stack &a, const MyData &d);
	Stack &operator+=(const MyData &d);
	friend Stack operator-(Stack &a, const MyData &d);
	Stack &operator-=(const MyData &d);
	void push(const MyData &d);
	MyData &pop();
};

int main(int argc, char *argv[])
{
	
	MyData a1(1), a2(2), a3(3), a4(4), a5(5);
	Stack b(a1);
	b.push(a2);
	b.push(a3);
	b.push(a4);
	b.push(a5);
	MyData c = b.pop();
	
	/*
	Stack c;
	c = b;
	c += a1;
	c += a2;
	c += a3;
	*/
	Stack *cptr, *pptr;
	cptr = &b;
	while (1)
	{
		cptr->data.PrintData();
		pptr = cptr;
		cptr = cptr->ptr;
		if (cptr == NULL)
		{
			break;
		}
	}
    /*MyData d(1);
    MyData f;
    f = d;
	bool flag = f == d;
	cout << "Equals : " << flag << endl;*/
	system("pause");
	return 0;
}

bool MyData ::operator==(const MyData &d)
{
	return (this->a == d.a);
}

bool MyData ::operator!=(const MyData &d)
{
	return (this->a != d.a);
}

MyData ::MyData(int a)
{
	this->a = a;
}

Stack &Stack ::operator=(const Stack &s)
{
	this->data = s.data;
	this->ptr = s.ptr;
	return *this;
}

Stack operator+(const Stack &s, const MyData &d)
{
	Stack _new = s;
	_new += d;
	return _new;
}

Stack &Stack ::operator+=(const MyData &d)
{
	push(d);
	return *this;
}

void Stack ::push(const MyData &d)
{
	Stack *p = new Stack(this->data);
	(*p).ptr = this->ptr;
	this->data = d;
	this->ptr = p;
}

MyData &MyData ::operator=(const MyData &d)
{
	this->a = d.a;
	return *this;
}

MyData &Stack ::pop()
{
	MyData a = this->data;
	Stack *p = ptr->ptr;
	MyData d = ptr->data;
    this->data = d;
    this->ptr = p;
	return a;
};



Stack operator-(const Stack &s, const MyData &d)
{
	Stack _new = s;
	_new -= d;
	return _new;
}

Stack &Stack ::operator-=(const MyData &d)
{
	pop();
	return *this;
}


void MyData :: PrintData()
{
	cout << this->a << endl;
}
/*
Vector operator-(const Vector &v1, const Vector &v2){
	Vector _new = v1;
	_new -= v2;
	return _new;
}
Vector &Vector :: operator=(const Vector &v)
{
	int n = this->Count;
	for (int i = 0; i < n; i++)
	{
		this->data[i] = v.data[i];
	}
	return *this;
}
Vector &Vector :: operator+=(const Vector &v)
{
	int n = this->Count;
	for (int i = 0; i < n; i++)
	{
		this->data[i] += v.data[i];
	}
	return *this;
}
Vector &Vector :: operator-=(const Vector &v)
{
	int n = this->Count;
	for (int i = 0; i < n; i++)
	{
		this->data[i] -= v.data[i];
	}
	return *this;
}
*/