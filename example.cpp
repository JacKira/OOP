#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
		cout << "Switch без использования break в каждой ветке в цикле от 1 до 5\n";
	for (int i = 1; i <= 5; i++)
	{
		switch (i)
		{
			case 1: cout << i << '\n';
			case 2: cout << i << '\n';
			case 3: cout << i << '\n';
			case 4: cout << i << '\n';
			case 5: cout << i << '\n';
		}
	}
	
		cout << "\nSwitch с использованием break в каждой ветке в цикле от 6 до 10\n";
	for (int i = 5; i <= 10; i++)
	{
		switch (i)
		{
			case 10: cout << i << '\n'; break;
			case 9: cout << i << '\n'; break;
			case 8: cout << i << '\n'; break;
			case 7: cout << i << '\n'; break;
			case 6: cout << i << '\n'; break;
		}
	}
}