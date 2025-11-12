#pragma once
#include <iostream>
#include <string>
using namespace std;

class persona {
protected:
    string pib;
    string date;
    string city;
    string phone;

public:
    persona(string pib, string date, string city, string phone);
    virtual ~persona() {}

    virtual void info() const = 0;
    int age() const;
};
