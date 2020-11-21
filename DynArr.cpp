#include "DynArr.h"


void DynArr::OutputArr()
{
	string s = string(11 * n + 1, '=');
	cout << s << endl;
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			printf("|%10.3f", arr[i * n + j]);
		}
		cout << "|" << endl;
		cout << s << endl;
	}
}



double* DynArr::GetArr(int m, int n)
{
	double* new_arr = new double[m * n];
	return new_arr;
}

DynArr::DynArr(int m, int n)
{
	this->m = m;
	this->n = n;
	arr = GetArr(m, n);
}

DynArr::DynArr(double* arr, int m, int n)
{
	SetArr(arr, m, n);
}

double* DynArr::GetArr()
{
	double* new_arr = new double[m * n];
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			new_arr[i * n + j] = arr[i * n + j];
		}
	}
	return new_arr;
}


void DynArr::InputArrFromTxt(char filename[])
{
	ifstream fin(filename);
	if (!fin)
		cout << "Error!" << endl;
	else
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				fin >> arr[i * n + j];
			}
		}
	}
	fin.close();
}

void DynArr::InputArrFromBin(char filename[])
{
	ifstream fin(filename, ios::binary);
	if (!fin)
		cout << "Error!" << endl;
	else
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				fin.read((char*)& arr[i * n + j], sizeof(arr[i * n + j]));
			}
		}
	}
	fin.close();
}


void DynArr::OutputArrToFileTxt(char filename[]) {
	ofstream fout(filename);
	if (!fout)
		cout << "Error!" << endl;
	else
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				fout << arr[i * n + j] << ' ';
			}
			fout << endl;
		}
	}
	fout.close();
}


void DynArr::OutputArrToFileBin(char filename[])
{
	ofstream fbinout(filename, ios::binary | ios::out);
	if (!(fbinout))
	{
		cout << "Error output array in file!" << endl;
	}
	else
	{
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				fbinout.write((char*)&arr[i * n + j], sizeof arr[i * n + j]);
			}
		}
	}
	fbinout.close();
}

void DynArr::EditElementInBinFile(char filename[], double new_el, int k, int l)
{
	ofstream fout(filename, ios::binary | ios::out);
	if (!(fout))
	{
		cout << "Error open file!" << endl;
		exit(1);
	}
	else
	{
		int index = (k - 1) * (l - 1) + (l - 1);
		fout.seekp(index, ios::beg);
		fout.write((char*)& new_el, sizeof(new_el));
	}
	fout.close();

}

void DynArr::SetArr(double* arr, int m, int n)
{
	if (this->arr != NULL)
	{
		delete[] this->arr;
	}
	this->m = m;
	this->n = n;
	this->arr = GetArr(m, n);
	for (int i = 0; i < m; i++)
	{
		for (int j = 0; j < n; j++)
		{
			this->arr[i * n + j] = arr[i * n + j];
		}
	}

}

double* DynArr::GetArrAftProc()
{
	int l_m = m / 2;
	double* minmax = new double[l_m];
	for (int i = 0; i < l_m; i++)
	{
		double max = -1e6;
		for (int j = 0; j < n; j++)
		{
			if (arr[(i * 2 + 1) * n + j] < 0)
			{
				max = ((arr[(i * 2 + 1) * n + j] > max) ? arr[(i * 2 + 1) * n + j] : max);
			}
		}
		minmax[i] = max;
	}
	return minmax;
}

void DynArr::PrintSumArr()
{
	int l_n = n / 2;
	for (int j = 0; j < l_n; j++)
	{
		double sum = 0;
		for (int i = 0; i < m; i++)
		{
			if (arr[i * n + j * 2 + 1] < 0)
			{
				sum += arr[i * n + j * 2 + 1];
			}
		}
		cout << "\t" << sum << endl;
	}
}





