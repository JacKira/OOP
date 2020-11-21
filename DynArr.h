#pragma once
#define M 8
#define N 3

#include <string>
#include <iostream>
#include <fstream>

using namespace std;

class DynArr
{
protected:
	double* arr = NULL;
	int m = 0, n = 0;
	double* GetArr(int m, int n);
public:
	DynArr() {};
	~DynArr() { delete[] arr; };
	DynArr(int m, int n);
	DynArr(double* arr, int m, int n);
	double* GetArr();
	double* GetArrAftProc();
	void PrintSumArr();
	void InputArrFromTxt(char filename[]);
	void InputArrFromBin(char filename[]);
	void OutputArr();
	void OutputArrToFileTxt(char filename[]);
	void SetArr(double* arr, int m, int n);
	void OutputArrToFileBin(char filename[]);
	void EditElementInBinFile(char filename[], double new_el, int k, int l);


};
