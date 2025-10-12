#include <iostream>
#include "arr.h"

using namespace std;
int main()
{   setlocale(0, "ukr");
    int size;
    cout << "Введiть розмiр масиву: ";
    cin >> size;

    myarr arr(size);

    arr.vvid();
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

    return 0;
}