#include <iostream>
#include "B1.h"
#include "B2.h"
#include "D1.h"
#include "D2.h"
#include "D4.h"
using namespace std;

int main() {

    cout << "\n=== Creating object D4 ===\n";
    D4 obj;

    cout << "\n=== SHOW ALL ===\n";
    obj.show();

    cout << "\n=== PROGRAM END — destructors start ===\n";
    return 0;
}