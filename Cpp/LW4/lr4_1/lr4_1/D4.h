#pragma once
#include "D1.h"
#include "D2.h"

class D4 : public D1, public D2 {
public:
    int value;

    D4();
    void show();
    ~D4();
};