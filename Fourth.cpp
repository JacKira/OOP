#include <iostream>
#include "graphics.h"
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

class TwoDLine : public TwoDFigure
{
public:
	TwoDLine(int* cords) : TwoDFigure(cords, 2) { };
	void SetCords(int* cords);
	void Draw();
private:
	const int _limit = 2;
};

class TwoDRectangle : public TwoDFigure
{

public:
	TwoDRectangle(int* cords) : TwoDFigure(cords, 2) {};
	void SetCords(int* cords);
	void Draw();
private:
	const int _limit = 2;

};

class TwoDCircle : public TwoDFigure 
{
public:
	TwoDCircle(int* cords, int radius) : TwoDFigure(cords, 1) { this->_rad = radius; };
	void SetCords(int* cords);
	void SetRadius(int r);
	int GetRadius();
	void Draw();
private:
	int _rad = 0;
	const int _limit = 1;
};




int main()
{
	int mas[4] = { 10, 10, 300, 300 };
	int mas2[2] = { 300, 300 };
	int radius = 50;
	TwoDLine l(mas);
	l.Draw();
	TwoDRectangle rect(mas);
	rect.Draw();
	TwoDCircle crcl(mas2, radius);
	crcl.Draw();
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

void TwoDLine::SetCords(int * cords)
{
	for (int i = 0; i < this->_limit; i++) {
		this->_cords[i * 2] = cords[i * 2];
		this->_cords[i * 2 + 1] = cords[i * 2 + 1];
	}
}

void TwoDLine::Draw()
{
	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	line(_cords[0], _cords[1], _cords[2], _cords[3]);
	system("pause");
	closegraph();
}


void TwoDRectangle::SetCords(int* cords)
{
	for (int i = 0; i < this->_limit; i++) {
		this->_cords[i * 2] = cords[i * 2];
		this->_cords[i * 2 + 1] = cords[i * 2 + 1];
	}
}

void TwoDRectangle::Draw()
{
	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	rectangle(_cords[0], _cords[1], _cords[2], _cords[3]);
	system("pause");
	closegraph();
}

void TwoDCircle::SetCords(int* cords)
{
	for (int i = 0; i < this->_limit; i++) {
		this->_cords[i * 2] = cords[i * 2];
		this->_cords[i * 2 + 1] = cords[i * 2 + 1];
	}
}

void TwoDCircle::SetRadius(int r)
{
	this->_rad = r;
}

int TwoDCircle::GetRadius()
{
	int r = this->_rad;
	return r;
}

void TwoDCircle::Draw()
{
	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	circle(this->_cords[0], this->_cords[1], this->_rad);
	system("pause");
	closegraph();
}