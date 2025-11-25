using System;

namespace lr8_1dll
{
    public abstract class Persona
    {
        public string PIB { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        protected Persona(string pib, string date, string city, string phone)
        {
            PIB = pib;
            Date = date;
            City = city;
            Phone = phone;
        }

        public abstract void Info();

        public int Age()
        {
            if (DateTime.TryParse(Date, out DateTime birth))
            {
                int age = DateTime.Now.Year - birth.Year;
                if (DateTime.Now.DayOfYear < birth.DayOfYear)
                    age--;

                return age;
            }
            return -1;
        }
    }
}