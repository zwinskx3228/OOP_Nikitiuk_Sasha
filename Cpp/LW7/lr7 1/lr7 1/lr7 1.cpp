#include <iostream>
#include <stack>
#include <vector>
#include <algorithm>
#include <iomanip>      // для форматування виводу
#include <cstdlib>      // rand, srand
#include <ctime>        // time()

using namespace std;

int main()
{
    setlocale(0, "ukr");
    // Щоб rand() давав різні числа
    srand((unsigned)time(nullptr));

    stack<float> st;        // Перший контейнер — stack<float>
    vector<float> vec;      // Другий контейнер — vector<float>

    int n;

    cout << "---------------------------------------------\n";
    cout << "   ВВЕДІТЬ КІЛЬКІСТЬ ЕЛЕМЕНТІВ (n): ";
    cin >> n;
    cout << "---------------------------------------------\n\n";

    // Перевірка коректності
    if (n <= 0) {
        cout << "Помилка: n повинно бути > 0.\n";
        return 0;
    }

    // Заповнення стеку випадковими числами
    cout << "Заповнення stack випадковими float значеннями...\n";
    for (int i = 0; i < n; i++) {
        float value = (rand() % 1000) / 10.0f; // від 0.0 до 99.9
        st.push(value);
    }

    // Перенесення зі стеку у вектор
    cout << "\nПеренесення зі stack у vector...\n";
    while (!st.empty()) {
        vec.push_back(st.top());
        st.pop();
    }

    // Вивід вектора
    cout << "\nЕлементи vector:\n";
    cout << "---------------------------------------------\n";
    for (float x : vec)
        cout << fixed << setprecision(2) << x << "   ";
    cout << "\n---------------------------------------------\n\n";

    // Сума
    float total = 0;
    for (float x : vec) total += x;

    cout << "Сума всіх елементів: "
        << fixed << setprecision(2) << total << "\n\n";

    // Сортування
    sort(vec.begin(), vec.end());

    cout << "Відсортований vector (за зростанням):\n";
    cout << "---------------------------------------------\n";
    for (float x : vec)
        cout << fixed << setprecision(2) << x << "   ";
    cout << "\n---------------------------------------------\n\n";

    // Вивід у зворотному порядку з видаленням
    cout << "Відсортований у спадаючому порядку (pop_back):\n";
    cout << "---------------------------------------------\n";
    while (!vec.empty()) {
        cout << fixed << setprecision(2) << vec.back() << "   ";
        vec.pop_back();
    }
    cout << "\n---------------------------------------------\n\n";

    system("pause");
    return 0;
}