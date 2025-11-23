#include "teacher.h"
#include "student.h"
#include <iostream>
using namespace std;

teacher::teacher(string pib, string date, string city, string phone, string position, int stag)
    : persona(pib, date, city, phone), position(position), stag(stag) {
}

void teacher::addStudent(student* s) {
    students.push_back(s);
}

void teacher::info() const {
    cout << "Викладач: " << pib << endl;
    cout << "Дата народження: " << date << " (Вiк: " << age() << ")" << endl;
    cout << "Заклад: " << city << endl;
    cout << "Телефон: " << phone << endl;
    cout << "Посада: " << position << endl;
    cout << "Стаж: " << stag << " рокiв" << endl;

    cout << "Студенти цього викладача:\n";
    if (students.empty())
        cout << "  Немає студентiв.\n";
    else {
        for (auto s : students) {
            cout << "  - " << s->age() << " років | " << endl;
            s->info();
        }
    }

    cout << "-----------------------------\n";
}