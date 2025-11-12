#pragma once
#include "persona.h"

class teacher : public persona {
    string position;
    int stag;

public:
    teacher(string pib, string date, string city, string phone, string position, int stag);
    void info() const override;
};
