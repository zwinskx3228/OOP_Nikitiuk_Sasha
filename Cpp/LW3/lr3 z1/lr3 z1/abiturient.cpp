#include "abiturient.h"
#include <iostream>
using namespace std;

abiturient::abiturient(string pib, string date, string city, string phone, string specialty)
    : persona(pib, date, city, phone), specialty(specialty) {
}

void abiturient::info() const {
    cout << "Абiтурiєнт: " << pib << endl;
    cout << "Дата народження: " << date << " (Вiк: " << age() << ")" << endl;
    cout << "Заклад: " << city << endl;
    cout << "Телефон: " << phone << endl;
    cout << "Спецiальнiсть: " << specialty << endl;
    cout << "-----------------------------\n";
}
