#include "book.h"
#include <vector>

int main() {
    // прості об'єкти
    setlocale(0, "ukr");
    Book b1;
    Book b2("Кобзар", "Тарас Шевченко", 300.0f);

    b1.setBook("Мистецтво вiйни", "Сунь-Цзи", 250.5f);
    cout << endl;
    cout << "\nОкремi книги:\n";
    b1.print();
    b2.print();
    cout << endl;
    // список книг
    vector<Book> library;
    library.emplace_back("Хатина дядька Тома", "Гаррiєт Бiчер Стоу", 120.0f);
    library.emplace_back("Майстер i Маргарита", "Михайло Булгаков", 220.0f);
    cout << endl;
    cout << "\nСписок книг:\n";
    for (size_t i = 0; i < library.size(); ++i) {
        cout << i + 1 << ". ";
        library[i].print();
    }
    cout << endl;
    return 0;
}
