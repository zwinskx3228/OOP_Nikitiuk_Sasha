#include "B1.h"

B1::B1() {
    cout << "B1 constructor. Enter value for B1: ";
    cin >> value;
    cout << "B1: no parents.\n";
}

void B1::show() {
    cout << "Class B1, value = " << value << endl;
}

B1::~B1() {
    cout << "Destructor B1, deleting value " << value << endl;
}