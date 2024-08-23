using System;
using taskTwo;
using simpleNumber;
using basket;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
        // задача 1
        Console.WriteLine("Минимальное и максимальное значения для примитивных типов:");
        Console.WriteLine($"bool: {true}/{false}");
        Console.WriteLine($"byte: {byte.MinValue}/{byte.MaxValue}");
        Console.WriteLine($"short: {short.MinValue}/{short.MaxValue}");
        Console.WriteLine($"ushort: {ushort.MinValue}/{ushort.MaxValue}");
        Console.WriteLine($"int: {int.MinValue}/{int.MaxValue}");
        Console.WriteLine($"long: {long.MinValue}/{long.MaxValue}");
        Console.WriteLine($"float: {float.MinValue}/{float.MaxValue}");
        Console.WriteLine($"double: {double.MinValue}/{double.MaxValue}");
        Console.WriteLine($"char: {char.MaxValue}");

        int[] array = new int[7] { 25, 15, 14, 69, 88, 10, 9,};
        Console.WriteLine("\nМассив int:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }

        object obj = "Пример";
        Console.WriteLine($"\nObject: {obj}");
        Console.ReadLine();

        // задача 2
        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        TaskTwo Number = new TaskTwo(num1, num2);
        Number.SumNumber();
        Console.ReadLine();

        // задача 3
        Console.Write("Введите минимальное число: ");
        int min = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите максимальное число: ");
        int max = Convert.ToInt32(Console.ReadLine());

        Simple simple = new Simple(min, max);
        simple.FindNumber();
        Console.ReadLine();

        // задача 4
        BasketItem basket = new BasketItem();
        while (true)
        {
            Console.Write("Введите название продукта для добавления (или 'q' для выхода): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "q") break;
            basket.AddProduct(input);
        }
        Console.WriteLine("\nПродукты в корзине:");
        basket.PrintBasket();
        Console.ReadLine();

        // задача 5
        Console.WriteLine("Введите пароль: ");
        string password = Console.ReadLine();

        while(true)
            {
                Console.WriteLine("Повторите введеный пароль (или 'q' для выхода): ");
            string value = Console.ReadLine();
            if(value.ToLower() == "q") break;
            if(value == password) break;
        }
        }
        
    }
    
}