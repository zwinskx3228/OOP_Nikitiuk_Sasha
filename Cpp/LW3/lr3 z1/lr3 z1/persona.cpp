#include "persona.h"
#include <chrono>
#include <sstream>

persona::persona(string pib, string date, string city, string phone)
    : pib(pib), date(date), city(city), phone(phone) {
}

int persona::age() const {
    int d = 0, m = 0, y = 0;
    char dot; 

    stringstream ss(date);
    ss >> d >> dot >> m >> dot >> y;

    using namespace std::chrono;
    auto now = system_clock::now();
    time_t t = system_clock::to_time_t(now);
    tm now_tm{};
#if defined(_MSC_VER)
    localtime_s(&now_tm, &t); 
#else
    localtime_r(&t, &now_tm); 
#endif

    int year = now_tm.tm_year + 1900;
    int month = now_tm.tm_mon + 1;
    int day = now_tm.tm_mday;

    int age = year - y;
    if ((month < m) || (month == m && day < d))
        age--;

    return age;
}
