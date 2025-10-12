#pragma once
#include <iostream>
#include <string>
using namespace std;

class Book {
private:
    string name;     // назва книги
    string author;   // автор
    float price;     // вартість

public:
    Book();                                // конструктор без параметрів
    Book(const string& n, const string& a, float p); // конструктор з параметрами
    ~Book();                               // деструктор

    // методи
    void setBook(const string& n, const string& a, float p);
    void print() const;

    // геттери
    string getName() const;
    string getAuthor() const;
    float getPrice() const;
};
