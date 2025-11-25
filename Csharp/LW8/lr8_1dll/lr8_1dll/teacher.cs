using lr8_1dll;
using System;
using System.Collections.Generic;

namespace lr8_1dll
{
    public class Teacher : Persona
    {
        public string Position { get; set; }
        public int Stag { get; set; }

        private readonly List<Student> students = new List<Student>();

        public Teacher(string pib, string date, string city, string phone,
                       string position, int stag)
            : base(pib, date, city, phone)
        {
            Position = position;
            Stag = stag;
        }

        public void AddStudent(Student s)
        {
            if (s != null)
                students.Add(s);
        }

        public override void Info()
        {
            Console.WriteLine("Викладач:");
            Console.WriteLine($"ПІБ: {PIB}");
            Console.WriteLine($"Посада: {Position}");
            Console.WriteLine($"Стаж: {Stag} років");
            Console.WriteLine($"Кількість студентів: {students.Count}");
        }
    }
}