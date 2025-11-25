using System;
using System.Security.Policy;

namespace lr8_1dll
{
    public class Abiturient : Persona
    {
        public string Specialty { get; set; }

        public Abiturient(string pib, string date, string city, string phone,
                          string specialty)
            : base(pib, date, city, phone)
        {
            Specialty = specialty;
        }

        public override void Info()
        {
            Console.WriteLine("Абітурієнт:");
            Console.WriteLine($"ПІБ: {PIB}");
            Console.WriteLine($"Спеціальність: {Specialty}");
            Console.WriteLine($"Місто: {City}");
            Console.WriteLine($"Телефон: {Phone}");
        }
    }
}
