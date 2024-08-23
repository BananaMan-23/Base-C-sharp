﻿using System;
using taskTwo;
using simpleNumber;

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
        }
        
    }
    
}