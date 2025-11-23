#pragma once
#include "persona.h"

class abiturient : public persona {
    string specialty;

public:
    abiturient(string pib, string date, string city, string phone, string specialty);
    void info() const override;
};
