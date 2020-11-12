#include "Utils.h"

string* ParseToThree(const string str, const char c)
{
	char* s = new char[str.size() + 1];
	strcpy(s, str.c_str());
	char* p = strtok(s, &c);
	string* new_str = new string[3];
	for (int i = 0; i < 3; i++)
	{
		new_str[i] = string(p);
		if (new_str[i].size() == 0) {
			return NULL;
		}
		p = strtok(NULL, &c);
	}
	delete p;
	delete[] s;
	return new_str;
}

long ToInt(const string& s)
{
	long i;
	i = 0;
	int n = s.size();
	for (int j = 0; j < n; j++) {
		if (s[j] >= '0' && s[j] <= '9') {
			i = i * 10 + (s[j] - '0');
		}
		else
		{
			return -1;
		}
	}
	return i;
}

bool IsInStr(const string& s, const string& ps)
{
	int pos = s.find(ps);
	if (pos != std::string::npos)
	{

		return true;
	}
	else
	{
		return false;
	}
}

// FOURTH TASK
int GetRowCount()
{
	int m;
	cout << "Введите количество строк\n";
	cin >> m;
	system("cls");
	return m;
}

int GetColCount()
{
	int n;
	cout << "Введите количество столбцов\n";
	cin >> n;
	system("cls");
	return n;
}