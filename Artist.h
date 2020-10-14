#pragma once
#include <string>
using namespace std;
class Artist
{
protected:
	string _artist = "\0";
	string _dateOfBirth = "\0";
	string _dateOfDeath = "\0";

public:
	bool operator==(const Artist& d);
	bool operator!=(const Artist& d);
	Artist(const string artist, const string dateFrom, const string dateTo);
	Artist() {};
	Artist& operator=(const Artist& d);
	void PrintData();
};

