#include "student.h"
#include <iostream>
using namespace std;

student::student(string pib, string date, string city, string phone, string department, int course)
    : persona(pib, date, city, phone), department(department), course(course) {
}

void student::info() const {
    cout << "Студент: " << pib << endl;
    cout << "Дата народження: " << date << " (Вiк: " << age() << ")" << endl;
    cout << "Заклад: " << city << endl;
    cout << "Телефон: " << phone << endl;
    cout << "Вiддiлення: " << department << endl;
    cout << "Курс: " << course << endl;
    cout << "-----------------------------\n";
}
