#include "D1.h"

D1::D1() {
    cout << "D1 constructor. Enter value for D1: ";
    cin >> value;
    cout << "D1: inherits PUBLIC from B1\n";
}

void D1::show() {
    cout << "Class D1, value = " << value << endl;
    B1::show();
}

D1::~D1() {
    cout << "Destructor D1, deleting value " << value << endl;
}