#pragma once
#include <string>
#include <fstream>
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
	Artist& operator=(Artist* d);
	void PrintData();
	string GetArtist();
	int* GetBirthDate();
	int* GetDeathDate();
	void SetAtrist(string artist);
	void SetBirthDate(int date[3]);
	void SetDeathDate(int date[3]);
	void InputDataRowFromFileTxt(ifstream& fin);
	void ResetValues();
};

