#pragma once
#include "B1.h"
#include "B2.h"

class D2 : private B1, public B2 {
public:
    int value;

    D2();
    void show();
    ~D2();
};