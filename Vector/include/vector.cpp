#include <iostream>
#include "vector.h"


Vector ::Vector()
{
  int n = this->Count;
    for (int i = 0; i < n; i++){
    this->data[i] = 0;
  }
}

Vector :: Vector(double a)
{
  int n = this->Count;
    for (int i = 0; i < n; i++)
    {
    this->data[i] = a;
  }
}

Vector:: Vector(const Vector &v)
{
  int n = this->Count;
    for (int i = 0; i < n; i++)
  {
    this->data[i] = v.data[i];
  }
}

double &Vector :: operator[](unsigned long i) { return data[i]; }

double Vector :: operator[](unsigned long i) const  { return data[i]; }

Vector &Vector :: operator=(const Vector &v)
{
    int n = this->Count;
    for (int i = 0; i < n; i++)
    {
        this->data[i] = v.data[i];
    }
    return *this;
}

Vector &Vector :: operator+=(const Vector &v)
{
    int n = this->Count;
    for (int i = 0; i < n; i++)
    {
        this->data[i] += v.data[i];
    }
    return *this;
}

Vector &Vector :: operator-=(const Vector &v)
{
    int n = this->Count;
    for (int i = 0; i < n; i++)
    {
        this->data[i] -= v.data[i];
    }
    return *this;
}

Vector &Vector :: operator*=(double a)
{
    int n = this->Count;
    for (int i = 0; i < n; i++)
    {
        this->data[i] *= a;
    }
    return *this;
}

Vector &Vector :: operator/=(double a)
{
    int n = this->Count;
    for (int i = 0; i < n; i++)
    {
        this->data[i] /= a;
    }
    return *this;
}

bool operator==(const Vector &v1, const Vector &v2) {
    int n = v1.Count;
    for(int i = 0; i< n; i++){
        if(v1[i] != v2[i]){
            return false;
        }
    }
    return true;
}

bool operator!=(const Vector &v1, const Vector &v2) {
    int n = v1.Count;
    for(int i = 0; i< n; i++){
        if(v1[i] != v2[i]){
            return true;
        }
    }
    return false;
}

Vector operator+(const Vector &v1, const Vector &v2){
    Vector _new = v1;
    _new += v2;
    return _new;
}

Vector operator-(const Vector &v1, const Vector &v2){
    Vector _new = v1;
    _new -= v2;
    return _new;
}

Vector Vector :: operator-() const{
    Vector _new;
    _new[0] = -data[0];
    _new[1] = -data[1];
    _new[2] = -data[2];
    return _new;
}

Vector operator*(const Vector &v1, double a){
    Vector _new = v1;
    _new *= a;
    return _new;
}

Vector operator*(double a, const Vector &v1){
    Vector _new = v1;
    _new *= a;
    return _new;
}

Vector operator/(const Vector &v1, double a){
    Vector _new = v1;
    _new /= a;
    return _new;
}

double operator^(const Vector &v1, const Vector &v2){
    return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
}


