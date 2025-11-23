#pragma once
#include "persona.h"
#include <vector>

class student; 

class teacher : public persona {
    string position;
    int stag;

    vector<student*> students;

public:
    teacher(string pib, string date, string city, string phone, string position, int stag);

    void addStudent(student* s);  // додати студента (агрегація)
    void info() const override;
};