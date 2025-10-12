#include <iostream>
#include "arr.h"
using namespace std;

int main()
{
    setlocale(0, "ukr");

    int size;
    cout << "Введiть розмiр масиву: ";
    cin >> size;

    myarr arr(size);
    arr.vvid();

    cout << "Початковий масив: ";
    arr.vuvid();

    arr.sort();
    cout << "Пiсля сортування: ";
    arr.vuvid();

    cout << "Розмiр масиву: " << arr.size() << endl;

    int k;
    cout << "Введiть число, на яке домножити масив: ";
    cin >> k;
    arr.scalar(k);

    cout << "Пiсля множення: ";
    arr.vuvid();

    cout << "\nПеревiрка операторiв:\n";
    cout << "Масив впорядкований? " << (!arr ? "Нi" : "Так") << endl;

    myarr plus = arr;
    ++plus;
    cout << "Пiсля ++ : ";
    plus.vuvid();

    myarr minus = arr;
    --minus;
    cout << "Пiсля -- : ";
    minus.vuvid();

    myarr times2 = arr * 2;
    cout << "Пiсля множення оператором *2: ";
    times2.vuvid();

    string str = (string)arr;
    cout << "Масив як рядок: \"" << str << "\"" << endl;

    return 0;
}
