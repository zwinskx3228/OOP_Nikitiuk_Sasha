using System;
using System.Xml.Linq;

namespace lr8_3
{
    public partial class Student
    {
        public Student(string name, int course)
        {
            Name = name;
            Course = course;

            // Викликаємо partial-метод — якщо він реалізований, виконається,
            // якщо ні — виклик і визначення видаляються компілятором.
            Validate();
        }

        partial void Validate()
        {
            if (Course < 1 || Course > 4)
            {
                Console.WriteLine("Error: Course must be between 1 and 4!");
            }
        }

        public void Info()
        {
            Console.WriteLine($"Student: {Name}, course: {Course}");
        }
    }
}