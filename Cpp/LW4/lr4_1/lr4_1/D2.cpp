#include "D2.h"

D2::D2() {
    cout << "D2 constructor. Enter value for D2: ";
    cin >> value;
    cout << "D2: inherits PRIVATE from B1, PUBLIC from B2\n";
}

void D2::show() {
    cout << "Class D2, value = " << value << endl;
    cout << "Accessible parents:\n";
    B2::show();  // public
}

D2::~D2() {
    cout << "Destructor D2, deleting value " << value << endl;
}