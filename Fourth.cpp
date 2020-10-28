#include <iostream>


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
	Line(int* cords) : TwoDFigure(cords, this->_limit) {};
	void SetCords(int* cords);
	void Draw();
};


int main()
{
	
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
	glClear(GL_COLOR_BUFFER_BIT);
	glColor3ub(145, 30, 66);

	glBegin(GL_TRIANGLES);

	glVertex3f(0.0f, 0.8f, 0.0f); //верхняя вершина

	glVertex3f(-0.4f, 0.4f, 0.0f); //левая вершина

	glVertex3f(0.4f, 0.4f, 0.0f); //правая вершина

	glEnd();

	glFlush();
}
