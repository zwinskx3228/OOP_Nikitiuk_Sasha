#pragma once
#include "persona.h"

class student : public persona {
    string department;
    int course;

public:
    student(string pib, string date, string city, string phone, string department, int course);
    void info() const override;
};
