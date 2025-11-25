using System;
using lr8_2 = Tools.MathTools;   
using Tools.Geometry;              

class Program
{
    static void Main()
    {
        // Використовуємо псевдонім MathLib
        lr8_2.Calculator calc = new lr8_2.Calculator();
        int sum = calc.Add(5, 7);
        int mul = calc.Mul(3, 4);

        // Використовуємо клас з Tools.Geometry без псевдоніма
        Square sq = new Square();
        int area = sq.Area(6);

        Console.WriteLine($"5 + 7 = {sum}");
        Console.WriteLine($"3 * 4 = {mul}");
        Console.WriteLine($"Площа квадрата зі стороною 6 = {area}");
    }
}
