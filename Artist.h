#pragma once
#include <string>
using namespace std;
class Artist
{
protected:
	string _artist = "\0";
	int _dateOfBirth[3] = { 0, 0, 0 };
	int _dateOfDeath[3] = { 0, 0, 0 };

public:
	bool operator==(const Artist& d);
	bool operator!=(const Artist& d);
	bool operator>(const Artist& d);
	Artist(const string artist, const string dateFrom, const string dateTo);
	Artist() {};
	Artist& operator=(const Artist& d);
	void PrintData();
};

