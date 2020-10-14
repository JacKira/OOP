#include "Artist.h"
#include <iostream>
using namespace std;
Artist::Artist(const string artist, const string dateFrom, const string dateTo)
{
	this->_artist = string(artist);
	if ((this->_artist.length() % 2) != 0) {
		this->_artist += ' ';
	}
	this->_dateOfBirth = string(dateFrom);
	this->_dateOfDeath = string(dateTo);
}

bool Artist ::operator==(const Artist& d)
{
	return ((this->_artist == d._artist) && (this->_dateOfBirth == d._dateOfBirth) && (this->_dateOfDeath == d._dateOfDeath));
}

bool Artist ::operator!=(const Artist& d)
{
	return !(*this == d);
}

void Artist::PrintData()
{
	int n = (this->_artist.size() > this->_dateOfBirth.size() ? this->_artist.size() : this->_dateOfBirth.size());
	string s1(n + 2, '='), s2(n + 2, '-'), s3((n - this->_dateOfDeath.size()) / 2, ' ');
	cout << "#" + s1 + "#\n";
	cout << "# " + this->_artist + string(n - this->_artist.size(), ' ') + " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + this->_dateOfBirth + s3 + " #\n";
	cout << "#" + s2 + "#\n";
	cout << "# " + s3 + this->_dateOfDeath + s3 + " #\n";
	cout << "#" + s1 + "#\n";
}