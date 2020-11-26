#include "Stack_unit.h"
#include "Artist.h"
#include <iostream>

using namespace std;


Stack_unit::Stack_unit(const Artist& a)
{
	this->_data = a;
	this->_ptr = NULL;
	this->_count = 1;
}

Stack_unit::Stack_unit()
{
	this->_ptr = NULL;
}

Stack_unit::Stack_unit(char filename[])
{
	this->_ptr = NULL;
	ifstream fin(filename);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	while (!fin.eof()) {
		this->push(Artist(fin));
	}
	fin.close();
}

Stack_unit& Stack_unit ::operator=(const Stack_unit& s)
{
	this->_data = s._data;
	this->_ptr = s._ptr;
	return *this;
}

Stack_unit operator+(const Stack_unit& s, const Artist& d)
{
	Stack_unit _new = s;
	_new += d;
	return _new;
}

Stack_unit& Stack_unit ::operator+=(const Artist& d)
{
	this->push(d);
	return *this;
}


Stack_unit operator-(const Stack_unit& s, const Artist& d)
{
	Stack_unit _new = s;
	_new -= d;
	return _new;
}

Stack_unit& Stack_unit ::operator-=(const Artist& d)
{
	if (this->_data == d) {
		this->pop();
	}
	return *this;
}

void Stack_unit::push(const Artist& d)
{
	if (this->_count > 0) {
		Stack_unit* p = new Stack_unit(this->_data);
		(*p)._ptr = this->_ptr;
		(*p)._count = -1;
		this->_count++;
		this->_data = d;
		this->_ptr = p;
	}
	else {
		this->_data = d;
		this->_count = 1;
	}
}

Artist Stack_unit::pop()
{
	Artist a = this->_data;
	if (this->_count > 1) {
		Stack_unit* p = _ptr->_ptr;
		Artist d = _ptr->_data;
		delete this->_ptr;
		this->_data = d;
		this->_ptr = p;
		this->_count--;
	}
	else {
		this->_ptr = NULL;
		this->_count = 0;
	}
	return a;
};

void Stack_unit::RemoveAll()
{
	Stack_unit* cptr, * pptr;
	cptr = this->_ptr;
	while (cptr != NULL)
	{
		pptr = cptr;
		cptr = cptr->_ptr;
		delete pptr;
		pptr = NULL;
	}
	this->_ptr = NULL;
	this->_count = 0;
}

Stack_unit :: ~Stack_unit()
{
	if (this->_count > 0) {
		RemoveAll();
	}
}

void Stack_unit::Print()
{
	while (this->_count)
	{
		std::cout << std::endl;
		this->pop().PrintDataRow();
	}
}

void Stack_unit::OutputToFileTxt(char filename[])
{
	ofstream fout(filename);
	if (!fout) {
		cout << "Error open output file\n";
		return;
	}
	while (this->_count)
	{
		this->pop().PrintDataRowToFileTxt(fout);
	}
	fout.close();
}

void Stack_unit::OutputToFileBin(char filename[])
{
	ofstream fout(filename, ios::binary);
	if (!fout) {
		cout << "Error open output file\n";
		return;
	}
	while (this->_count)
	{
		this->pop().PrintDataRowToFileBin(fout);
	}
	fout.close();
}

void Stack_unit::InputFormFileTxt(char filename[])
{
	ifstream fin(filename);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	long pos;
	char b;
	while (!fin.eof()) {
		pos = fin.tellg();
		fin.get(b);
		if (fin.eof()) {
			break;
		}
		else {
			if (b == '\n')
			{
				while (fin.get(b))
				{
					if (b == '\n')
					{
						fin.get(b);
						break;
					}
				}
				break;
			}
			fin.seekg(pos, ios::beg);
		}
		this->push(Artist(fin));
	}
	fin.close();
}

void Stack_unit::InputFormFileBin(char filename[])
{
	ifstream fin(filename, ios::binary);
	if (!fin) {
		cout << "Error open txt file\n";
		return;
	}
	long pos;
	char b;
	while (!fin.eof()) {
		pos = fin.tellg();
		fin.read((char*)&b, sizeof(b));
		if (fin.eof()) {
			break;
		}
		else {
			if (b == '\n')
			{
				while (fin.read((char*)&b, sizeof(b)))
				{
					if (b == '\n')
					{
						fin.read((char*)&b, sizeof(b));;
						break;
					}
				}
				break;
			}
			fin.seekg(pos, ios::beg);
		}
		this->push(Artist(fin));
	}
	fin.close();
}

void Stack_unit::DeleteMaxFromBin(char filename[])
{
	fstream fstr(filename, ios::in | ios::out | ios::binary);
	if (!fstr) {
		cout << "Error open txt file\n";
		return;
	}
	long pos = 0, prwPos = 0, nxtPos = 0, delPos = 0;
	char b;
	bool flag = false;
	Artist max, new_dt;
	while (!fstr.eof()) {
		pos = fstr.tellg();
		fstr.read((char*)&b, sizeof(b));
		if (fstr.eof()) {
			break;
		}
		else {
			fstr.seekg(pos, ios::beg);
		}
		pos = fstr.tellg();
		new_dt.InputDataRowFromFileBin(*(ifstream*)&fstr);
		if (new_dt > max) {
			max = new_dt;
			delPos = pos;
			nxtPos = fstr.tellg();
		}
	}
	fstr.close();
	fstr.open(filename, ios::in | ios::out | ios::binary);
	if (pos == nxtPos) {
		fstr.seekp(delPos, ios::beg);
		b = '\n';
		fstr.write((char*)&b, sizeof(b));
	}
	else {
		while (!fstr.eof()) {
			fstr.seekg(nxtPos, ios::beg);
			new_dt.InputDataRowFromFileBin(*(ifstream*)&fstr);
			nxtPos = fstr.tellg();
			fstr.seekp(delPos, ios::beg);
			new_dt.PrintDataRowToFileBin(*(ofstream*)&fstr);
			delPos = fstr.tellp();
			fstr.seekg(nxtPos, ios::beg);
			fstr.read((char*)&b, sizeof(b));
		}

	}
	fstr.close();
	fstr.open(filename, ios::in | ios::out | ios::binary);
	fstr.seekp(delPos, ios::beg);
	b = '\n';
	fstr.write((char*)&b, sizeof(b));
	fstr.close();
	cout << "\nДолгожитель:\n";
	max.PrintDataRow();
	cout << "\nДолжен быть удален\n";
}

void Stack_unit::ModificationDataFromBin(char filename[], string artist, string date1, string date2)
{
	fstream fstr(filename, ios::in | ios::out | ios::binary);
	if (!fstr) {
		cout << "Error open txt file\n";
		return;
	}
	long pos = 0, prwPos = 0, nxtPos = 0, delPos = 0;
	char b;
	bool flag = false;
	Artist max, new_dt;
	while (!fstr.eof()) {
		pos = fstr.tellg();
		fstr.read((char*)&b, sizeof(b));
		if (fstr.eof()) {
			break;
		}
		else {
			fstr.seekg(pos, ios::beg);
		}
		pos = fstr.tellg();
		new_dt.InputDataRowFromFileBin(*(ifstream*)&fstr);
		if (IsInStr(new_dt.GetArtist(), artist)) {
			flag = true;
			delPos = pos;
			break;

		}
	}
	fstr.close();
	if (!flag) {
		return;
	}
	fstr.open(filename, ios::in | ios::out | ios::binary);
	Artist mod_art(new_dt.GetArtist(), date1, date2);
	fstr.seekp(delPos, ios::beg);
	mod_art.PrintDataRowToFileBin(*(ofstream*)&fstr);
	fstr.close();
}

int Stack_unit::GetCount()
{
	int n = this->_count;
	return n;
}

void Stack_unit::  operator>>(string filename)
{
	if (IsInStr(filename, ".bin")) {
		char* c = &filename[0];
		this->OutputToFileBin(c);
	}

	if (IsInStr(filename, ".txt")) {
		char* c = &filename[0];
		this->OutputToFileTxt(c);
	}
}

void Stack_unit::operator<<(string filename)
{
	if (IsInStr(filename, ".bin")) {
		char* c = &filename[0];
		this->InputFormFileBin(c);
	}

	if (IsInStr(filename, ".txt")) {
		char* c = &filename[0];
		this->InputFormFileTxt(c);
	}
}



Stack_unit& Stack_unit :: operator--() {
	this->pop();
	return *this;
}

Stack_unit& Stack_unit :: operator--(int) {
	this->pop();
	return *this;
}