#include "Artist.h"
#include <iostream>
#include "Utils.h"
using namespace std;



Artist::Artist(const string artist, const string dateFrom, const string dateTo)
{
	this->_artist = string(artist);
	if ((this->_artist.length() % 2) != 0) {
		this->_artist += ' ';
	}
	string* s1 = ParseToThree(dateFrom, '.');
	string* s2 = ParseToThree(dateTo, '.');
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = ToInt(s1[i]);
		this->_dateOfDeath[i] = ToInt(s2[i]);
	}
	delete[] s1;
	delete[] s2;
	 
}

bool Artist ::operator==(const Artist& d)
{
	bool condition1 = (this->_artist == d._artist);
	bool condition2 = (this->_dateOfBirth[0] == d._dateOfBirth[0]) && (this->_dateOfBirth[1] == d._dateOfBirth[1]) &&
		(this->_dateOfBirth[2] == d._dateOfBirth[2]);
	bool condition3 = (this->_dateOfDeath[0] == d._dateOfDeath[0]) && (this->_dateOfDeath[1] == d._dateOfDeath[1]) &&
		(this->_dateOfDeath[2] == d._dateOfDeath[2]);
	return (condition1 && condition2  && condition3);
}

bool Artist ::operator!=(const Artist& d)
{
	return !(*this == d);
}

bool Artist :: operator>(const Artist& d) {
	int life1 = this->_dateOfDeath[2] * 365 + this->_dateOfDeath[1] * 30 + this->_dateOfDeath[0] -
		this->_dateOfBirth[2] * 365 + this->_dateOfBirth[1] * 30 + this->_dateOfBirth[0];
	int life2 = d._dateOfDeath[2] * 365 + d._dateOfDeath[1] * 30 + d._dateOfDeath[0] -
		d._dateOfBirth[2] * 365 + d._dateOfBirth[1] * 30 + d._dateOfBirth[0];
	return life1 > life2;
}

Artist& Artist ::operator=(const Artist& d)
{
	this->_artist = d._artist;
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = d._dateOfBirth[i];
		this->_dateOfDeath[i] = d._dateOfDeath[i];
	}
	return *this;
}

void Artist::PrintData()
{
	int n = (this->_artist.size() > 10 ? this->_artist.size() : 10);
	string s1(n + 2, '='), s2(n + 2, '-'), s3((n - 10) / 2, ' ');
	cout << "#" + s1 + "#\n";
	cout << "# " + this->_artist + string(n - this->_artist.size(), ' ') + " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1]) + '.'
		+ to_string(this->_dateOfBirth[2]) + s3 + " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1]) + '.'
		+ to_string(this->_dateOfDeath[2]) + s3 + " #\n";
	cout << "#" + s1 + "#\n";
}