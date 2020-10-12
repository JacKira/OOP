#include <iostream>

using namespace std;

class MyData
{
  protected:
	int a = 0;

  public:
	bool operator==(MyData a);
	bool operator!=(MyData a);
	MyData(int a);
	MyData(){};
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
	Stack& operator=(const Stack& s);
	
};

int main(int argc, char *argv[])
{
	MyData a(1);
	Stack b(a);
	bool flag = a == b.data;
	cout << "Equals : " << flag << endl;
	system("pause");
	return 0;
}

bool MyData :: operator==(MyData b)
{
	return (this->a == b.a);
}

bool MyData :: operator!=(MyData b)
{
	return (this->a != b.a);
}

MyData ::MyData(int a)
{
	this->a = a;
}

Stack &Stack :: operator=(const Stack &s)
{
	this->data = s.data;
	this->ptr = s.ptr;
	return *this;
}

/*
Vector operator+(const Vector &v1, const Vector &v2){
	Vector _new = v1;
	_new += v2;
	return _new;
}

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
