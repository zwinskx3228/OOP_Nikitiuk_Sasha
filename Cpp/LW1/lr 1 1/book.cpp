#include "book.h"

// Конструктор без параметрів
Book::Book() : name(""), author(""), price(0.0f) {
    cout << "Створено книгу (порожню)" << endl;
}

// Конструктор з параметрами
Book::Book(const string& n, const string& a, float p) : name(n), author(a), price(p) {
    cout << "Створено книгу: " << name << endl;
}

// Деструктор
Book::~Book() {
    cout << "Видалено книгу: " << name << endl;
}

// Задати значення
void Book::setBook(const string& n, const string& a, float p) {
    name = n;
    author = a;
    price = p;
}

// Вивід
void Book::print() const {
    cout << "Назва: " << name
        << "\tАвтор: " << author
        << "\tЦiна: " << price << " грн" << endl;
}

// Геттери
string Book::getName() const { return name; }
string Book::getAuthor() const { return author; }
float Book::getPrice() const { return price; }
