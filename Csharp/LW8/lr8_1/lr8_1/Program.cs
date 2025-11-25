using lr8_1dll;

internal class Program
{
    static void Main()
    {
        Student s = new Student("Іван Іванов", "2004", "Київ", "123456", "ФІТ", 2);
        Teacher t = new Teacher("Петров П.П.", "1980", "Київ", "987654", "Доцент", 15);

        t.AddStudent(s);

        s.Info();
        Console.WriteLine();
        t.Info();

        Console.ReadKey();
    }
}