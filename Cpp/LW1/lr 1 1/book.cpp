#include "book.h"

Book::Book() : name(""), author(""), price(0.0f) {
    cout << "Створено книгу (порожню)" << endl;
}

Book::Book(const string& n, const string& a, float p) : name(n), author(a), price(p) {
    cout << "Створено книгу: " << name << endl;
}

Book::~Book() {
    cout << "Видалено книгу: " << name << endl;
}

void Book::setBook(const string& n, const string& a, float p) {
    name = n;
    author = a;
    price = p;
}

void Book::print() const {
    cout << "Назва: " << name
        << "\tАвтор: " << author
        << "\tЦiна: " << price << " грн" << endl;
}

string Book::getName() const { return name; }
string Book::getAuthor() const { return author; }
float Book::getPrice() const { return price; }
