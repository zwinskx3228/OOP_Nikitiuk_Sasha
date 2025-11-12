#pragma once
#include <iostream>
#include <string>
using namespace std;

class Book {
private:
    string name;     
    string author;   
    float price;     

public:
    Book();                               
    Book(const string& n, const string& a, float p);
    ~Book();                               

    void setBook(const string& n, const string& a, float p);
    void print() const;

    string getName() const;
    string getAuthor() const;
    float getPrice() const;
};
