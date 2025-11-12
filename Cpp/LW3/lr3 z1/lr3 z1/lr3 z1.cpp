#include <iostream>
#include <vector>
#include "abiturient.h"
#include "student.h"
#include "teacher.h"
#include <windows.h>
using namespace std;

void vuvid(const vector<persona*>& people) {
    for (auto p : people)
        p->info();
}

void search(const vector<persona*>& people) {
    int minage, maxage;
    cout << "Введiть мiнiмальний i максимальний вiк: ";
    cin >> minage >> maxage;
    cin.ignore();

    bool found = false;
    for (auto p : people) {
        int age = p->age();
        if (age >= minage && age <= maxage) {
            p->info();
            found = true;
        }
    }
    if (!found)
        cout << "Немає персон у цьому дiапазонi вiку.\n";
}


void add(vector<persona*>& people) {
    int type;
    string typeStr;

    cout << "Кого додати?\n1 - Абiтурiєнт\n2 - Студент\n3 - Викладач\nВаш вибiр: ";
    getline(cin, typeStr);
    type = stoi(typeStr);

    string pib, dob, city, phone;
    cout << "ПIБ: "; getline(cin, pib);
    cout << "Дата народження (DD.MM.YYYY): "; getline(cin, dob);
    cout << "Заклад: "; getline(cin, city);
    cout << "Телефон: "; getline(cin, phone);

    if (type == 1) {
        string spec;
        cout << "Спецiальнiсть: "; getline(cin, spec);
        people.push_back(new abiturient(pib, dob, city, phone, spec));
    }
    else if (type == 2) {
        string dep, courseStr;
        int course;
        cout << "Вiддiлення: "; getline(cin, dep);
        cout << "Курс: "; getline(cin, courseStr);
        course = stoi(courseStr);
        people.push_back(new student(pib, dob, city, phone, dep, course));
    }
    else if (type == 3) {
        string pos, expStr;
        int exp;
        cout << "Посада: "; getline(cin, pos);
        cout << "Стаж (рокiв): "; getline(cin, expStr);
        exp = stoi(expStr);
        people.push_back(new teacher(pib, dob, city, phone, pos, exp));
    }
    else {
        cout << "Невiрний вибiр.\n";
    }
}
int main() {
    setlocale(LC_ALL, "ukr");
    SetConsoleCP(1251);      
    SetConsoleOutputCP(1251);
    vector<persona*> people;
    people.push_back(new abiturient("Iваненко Iван Iванович", "12.05.2010", "ХПФК", "380971234567", "Комп’ютерна iнженерiя"));
    people.push_back(new student("Нiкiтюк Олександра Миколаївна", "03.04.2008", "ХПФК", "380683317825", "ПI", 3));
    people.push_back(new teacher("Коваленко Марiя Петрiвна", "25.02.1980", "ХПФК", "380501234567", "Доцент", 15));


    int choice;
    do {
        cout << "\n=== МЕНЮ ===\n"
            << "1 - Додати персону\n"
            << "2 - Вивести базу\n"
            << "3 - Пошук за віком\n"
            << "0 - Вихід\n"
            << "Ваш вибір: ";
        cin >> choice;
        cin.ignore();
		cout << endl;

        switch (choice) {
        case 1: {
            add(people); break;
        }
        case 2: {  
            cout << "===== БАЗА ПЕРСОН =====\n";
            vuvid(people); break;
        }
        case 3: {
            search(people); break;
        }
        case 0: {
            cout << "Вихід...\n"; break;
        }
        default: cout << "Невірний вибір!\n";
        }
    } while (choice != 0);

    for (auto p : people) delete p;
    return 0;
}
