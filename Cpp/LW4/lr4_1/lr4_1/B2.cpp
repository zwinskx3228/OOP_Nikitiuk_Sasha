#include "B2.h"

B2::B2() {
    cout << "B2 constructor. Enter value for B2: ";
    cin >> value;
    cout << "B2: no parents.\n";
}

void B2::show() {
    cout << "Class B2, value = " << value << endl;
}

B2::~B2() {
    cout << "Destructor B2, deleting value " << value << endl;
}