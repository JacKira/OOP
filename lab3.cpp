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
	void operator+(MyData a);
	void operator=(Stack a);
	//	friend void operator+(Stack &a, MyData &b);
};

int main(int argc, char *argv[])
{
	MyData a(1);
	Stack b(a);
	b = b + a;
	/*Stack *cptr, *nptr;
	cptr = *b;
	while(crpt != NULL)
	{
		cout << crpt->data << endl;
		nptr = crptr.ptr;
		delele crptr;
		crptr = nptr;
	}*/

	return 0;
}

bool MyData ::operator==(MyData a)
{
	return (this->a == a.a);
}

bool MyData ::operator!=(MyData a)
{
	return (this->a != a.a);
}

MyData ::MyData(int a)
{
	this->a = a;
}

void Stack ::operator+(MyData a)
{
	Stack *p = new Stack(this->data);
	this->ptr = p;
	this->data = a;
}

void Stack::operator=(Stack a)
{
	this->data = a.data;
}
