#pragma once
#include <string>
using namespace std;

class myarr {
public:
    int* arr;
    int n;

public:
    myarr(int size);
    myarr(const myarr& other);         
    myarr& operator=(const myarr& other);
    ~myarr();

    void vvid();
    void vuvid();
    void sort();
    int size();
    void scalar(int k);

    // Перевантаження операторів
    myarr& operator++();       
    myarr& operator--();        
    bool operator!() const;     
    myarr operator*(int k);     
    operator string() const;    
};
