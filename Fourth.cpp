#include <iostream>
#include "bgi/graphics.h"
using namespace std;

class TwoDFigure
{
protected:
	int* _cords = NULL;
	int _cordsCount = 0;
public:
	TwoDFigure() {};
	TwoDFigure(int* cords, int n);
	virtual void Draw() = 0;
	virtual void SetCords(int *cords) = 0;
	int* GetCords();
	int GetCordsCount();
};

class Line : public TwoDFigure
{
private:
	const int _limit = 2;
public:
	Line(int* cords) : TwoDFigure(cords, 2) {};
	void SetCords(int* cords);
	void Draw();
};


int main()
{
	int mas[4] = { 0, 0, 50, 50 };
	Line l(mas);
	l.Draw();
	system("pause");
	return 0;
}

int* TwoDFigure::GetCords() {
	int n = this->_cordsCount;
	int *_new = new int[n * 2];
	for (int i = 0; i < n; i++)
	{
		_new[i * 2] = _cords[i * 2];
		_new[i * 2 + 1] = _cords[i * 2 + 1];
	}
	return _new;
}

TwoDFigure::TwoDFigure(int* cords, int n)
{
	if (cords != NULL)
	{
		this->_cordsCount = n;
		this->_cords = new int[n * 2];
		for (int i = 0; i < n; i++)
		{
			this->_cords[i * 2] = cords[i * 2];
			this->_cords[i * 2 + 1] = cords[i * 2 + 1];
		}
	}
	
}

int TwoDFigure::GetCordsCount()
{
	int n = _cordsCount;
	return n;
}

void Line::SetCords(int * cords)
{
	for (int i = 0; i < this->_limit; i++) {
		this->_cords[i * 2] = cords[i * 2];
		this->_cords[i * 2 + 1] = cords[i * 2 + 1];
	}
}

void Line::Draw()
{
	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	line(_cords[0], _cords[1], _cords[2], _cords[3]);
	system("pause");
	closegraph();
}
