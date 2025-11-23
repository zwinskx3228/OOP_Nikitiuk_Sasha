#include "D4.h"

D4::D4() {
    cout << "D4 constructor. Enter value for D4: ";
    cin >> value;
    cout << "D4: inherits PUBLIC from D1 and PUBLIC from D2\n";
}

void D4::show() {
    cout << "Class D4, value = " << value << endl;
    cout << "\nParents of D4:\n";
    D1::show();
    D2::show();
}

D4::~D4() {
    cout << "Destructor D4, deleting value " << value << endl;
}