#include "arr.h"
#include <iostream>
#include <sstream>
using namespace std;

myarr::myarr(int size)
{
    n = size;
    arr = new int[n];
}

myarr::myarr(const myarr& other) {
    n = other.n;
    arr = new int[n];
    for (int i = 0; i < n; i++) arr[i] = other.arr[i];
}

myarr& myarr::operator=(const myarr& other) {
    if (this == &other) return *this; 
    delete[] arr;
    n = other.n;
    arr = new int[n];
    for (int i = 0; i < n; i++) arr[i] = other.arr[i];
    return *this;
}
myarr::~myarr()
{
    delete[] arr;
}

void myarr::vvid()
{
    cout << "Введiть " << n << " елементiв масиву:\n";
    for (int i = 0; i < n; i++) {
        cout << "Елемент [" << i << "]: ";
        cin >> arr[i];
    }
}

void myarr::vuvid()
{
    cout << "Масив: ";
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;
}

void myarr::sort()
{
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                int t = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = t;
            }
        }
    }
}

int myarr::size()
{
    return n;
}

void myarr::scalar(int k)
{
    for (int i = 0; i < n; i++) {
        arr[i] *= k;
    }
}

myarr& myarr::operator++() {
    for (int i = 0; i < n; i++) arr[i]++;
    return *this;
}

myarr& myarr::operator--() {
    for (int i = 0; i < n; i++) arr[i]--;
    return *this;
}

bool myarr::operator!() const {
    for (int i = 0; i < n - 1; i++) {
        if (arr[i] > arr[i + 1])
            return true; 
    }
    return false;
}

myarr myarr::operator*(int k) {
    myarr result(n);
    for (int i = 0; i < n; i++)
        result.arr[i] = arr[i] * k;
    return result;
}

myarr::operator string() const {
    stringstream ss;
    for (int i = 0; i < n; i++) {
        ss << arr[i];
        if (i != n - 1) ss << " ";
    }
    return ss.str();
}
