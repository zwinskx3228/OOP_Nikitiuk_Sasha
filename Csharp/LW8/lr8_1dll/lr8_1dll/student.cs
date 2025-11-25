using lr8_1dll;
using System;
using System.Security.Policy;

namespace lr8_1dll
{
    public class Student : Persona
    {
        public string Department { get; set; }
        public int Course { get; set; }

        public Student(string pib, string date, string city, string phone,
                       string department, int course)
            : base(pib, date, city, phone)
        {
            Department = department;
            Course = course;
        }

        public override void Info()
        {
            Console.WriteLine("Студент:");
            Console.WriteLine($"ПІБ: {PIB}");
            Console.WriteLine($"Кафедра: {Department}");
            Console.WriteLine($"Курс: {Course}");
            Console.WriteLine($"Місто: {City}");
            Console.WriteLine($"Телефон: {Phone}");
        }
    }
}