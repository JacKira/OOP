#pragma once
#include <string>
#include <fstream>
using namespace std;
class Artist
{
private:
	void PrintDataWithWidth();
protected:
	string _artist = "\0";
	int _dateOfBirth[3] = { 0, 0, 0 };
	int _dateOfDeath[3] = { 0, 0, 0 };

public:
	bool operator==(const Artist& d);
	bool operator!=(const Artist& d);
	bool operator>(const Artist& d);
	Artist(ifstream &finstr);
	Artist(const string artist, const string dateFrom, const string dateTo);
	Artist() {};
	Artist& operator=(const Artist& d);
	void PrintDataRow();
	void InputDataRowFromFileTxt(ifstream &fin);
	int InputDataRowFromFileBin(ifstream &fin);
	void PrintDataRowToFileTxt(ofstream &fout, int width = 60);
	void PrintDataRowToFileBin(ofstream &fout, int width = 60);
	string GetArtist();
};

