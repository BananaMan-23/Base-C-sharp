using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

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
        }
    }
    
}