#include <iostream>
#include <stack>
#include <vector>
#include <windows.h>

#include "abiturient.h"
#include "student.h"
#include "teacher.h"

using namespace std;

void addToStack(stack<persona*>& st);
void vuvid(const vector<persona*>& people);
void search(const vector<persona*>& people);

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
        int a = p->age();
        if (a >= minage && a <= maxage) {
            p->info();
            found = true;
        }
    }

    if (!found)
        cout << "Немає персон у цьому дiапазонi вiку.\n";
}

void addToStack(stack<persona*>& st) {
    int type;
    string s;

    cout << "Кого додати?\n1 - Абiтурiєнт\n2 - Студент\n3 - Викладач\nВаш вибiр: ";
    getline(cin, s);
    type = stoi(s);

    string pib, dob, city, phone;
    cout << "ПIБ: "; getline(cin, pib);
    cout << "Дата народження (DD.MM.YYYY): "; getline(cin, dob);
    cout << "Заклад: "; getline(cin, city);
    cout << "Телефон: "; getline(cin, phone);

    if (type == 1) {
        string spec;
        cout << "Спецiальнiсть: "; getline(cin, spec);
        st.push(new abiturient(pib, dob, city, phone, spec));
    }
    else if (type == 2) {
        string dep, courseStr;
        cout << "Вiддiлення: "; getline(cin, dep);
        cout << "Курс: "; getline(cin, courseStr);
        st.push(new student(pib, dob, city, phone, dep, stoi(courseStr)));
    }
    else if (type == 3) {
        string pos, expStr;
        cout << "Посада: "; getline(cin, pos);
        cout << "Стаж (рокiв): "; getline(cin, expStr);
        st.push(new teacher(pib, dob, city, phone, pos, stoi(expStr)));
    }
    else {
        cout << "Невiрний вибiр.\n";
    }
}

int main() {
    setlocale(LC_ALL, "ukr");
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    stack<persona*> st;

    vector<persona*> people;

    st.push(new student("Нiкiтюк Олександра", "03.04.2008", "ХПФК", "38068...", "ПI", 3));
    st.push(new student("Iванов Петро", "10.10.2007", "ХПФК", "38050...", "ПI", 2));
    st.push(new teacher("Коваленко Марiя", "25.02.1980", "ХПФК", "380501234567", "Доцент", 15));

    while (!st.empty()) {
        people.push_back(st.top());
        st.pop();
    }

    int choice;

    do {
        cout << "\n=== МЕНЮ ===\n"
            << "1 - Додати персону (у STACK)\n"
            << "2 - Перемістити STACK -> VECTOR\n"
            << "3 - Вивести базу VECTOR\n"
            << "4 - Пошук за віком\n"
            << "0 - Вихід\n"
            << "Ваш вибір: ";

        cin >> choice;
        cin.ignore();
        cout << endl;

        switch (choice) {
        case 1:
            addToStack(st);
            break;

        case 2:
            while (!st.empty()) {
                people.push_back(st.top());
                st.pop();
            }
            cout << "Перенесено!\n";
            break;

        case 3:
            cout << "===== БАЗА ПЕРСОН =====\n";
            vuvid(people);
            break;

        case 4:
            search(people);
            break;

        case 0:
            cout << "Вихід...\n";
            break;

        default:
            cout << "Невірний вибір!\n";
        }

    } while (choice != 0);

    for (auto p : people) delete p;

    return 0;
}