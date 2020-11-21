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

Artist::Artist(ifstream &finstr)
{
	InputDataRowFromFileTxt(finstr);
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

void Artist::PrintDataRow()
{
	const int size = 98;
	int n = this->_artist.size();
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " - " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	int m = dateStr.size();
	string s1(size, '=');
	
	cout << "#" + s1 + "#\n# " + this->_artist + string(size - n - m - 4, ' ') + "| " + dateStr + " #\n#" + s1 + "#";
}




void Artist::PrintDataRowToFileTxt(ofstream &fout)
{
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	fout << this->_artist + " " + dateStr + "\n";
}

void Artist::PrintDataRowToFileBin(ofstream &fout)
{
	string dateStr = to_string(this->_dateOfBirth[0]) + '.' + to_string(this->_dateOfBirth[1])
		+ '.' + to_string(this->_dateOfBirth[2]) + " " + to_string(this->_dateOfDeath[0]) + '.' + to_string(this->_dateOfDeath[1])
		+ '.' + to_string(this->_dateOfDeath[2]);
	string outStr = this->_artist + " " + dateStr + "\n";
	fout.write((char*)&outStr, sizeof(outStr));
}





string Artist :: GetArtist() {
	string art = this->_artist;
	return art;
}



void Artist::InputDataRowFromFileTxt(ifstream& fin)
{
	char b;
	string artist, dateFrom, dateTo, s = "";
	fin.get(b);
	//Start read Artsit
	while (b != ' ')
	{
		s += b;
		fin.get(b);
	}
	artist = s;

	fin.get(b);
	while (b == ' ')
	{
		fin.get(b);
	}

	s = "";
	s += b;
	fin.get(b);
	while (b != ' ')
	{
		s += b;
		fin.get(b);
	}
	artist += ' ' + s;
	//Finish read Artist

	//Start read Date of Birth
	fin.get(b);
	while (b == ' ')
	{
		fin.get(b);
	}

	s = "";
	s += b;
	fin.get(b);
	while (b != ' ')
	{
		s += b;
		fin.get(b);
	}
	dateFrom = s;
	//Finish read Date of Birth

	//Start read Datd of Death
	fin.get(b);
	while (b == ' ')
	{
		fin.get(b);
	}

	s = "";
	s += b;
	fin.get(b);
	while ((b != ' ') && (b != '\n'))
	{
		s += b;
		fin.get(b);
	}
	dateTo = s;
	//Finish read Date of Death
	this->_artist = artist;
	string* s1 = ParseToThree(dateFrom, '.');
	string* s2 = ParseToThree(dateTo, '.');
	for (int i = 0; i < 3; i++) {
		this->_dateOfBirth[i] = ToInt(s1[i]);
		this->_dateOfDeath[i] = ToInt(s2[i]);
	}
	delete[] s1;
	delete[] s2;
}