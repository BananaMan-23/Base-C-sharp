using System;
using CoffeeMachine;
using Utils;
using Drink;

namespace menuCoffeMachine
{
    public class CoffeDisplay
    {
        internal Coffe _coffeMachine;

        internal CoffeDisplay(Coffe coffe)
        {
            this._coffeMachine = coffe;
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("МЕНЮ КОФЕМАШИНЫ:");
            Console.WriteLine("1. Включить кофемашину");
            Console.WriteLine("2. Выключить кофемашину");
            Console.WriteLine("3. Добавить воду");
            Console.WriteLine("4. Добавить кофе");
            Console.WriteLine("5. Добавить молоко");
            Console.WriteLine("6. Приготовить кофе");
            Console.WriteLine("7. Очистить кофемашину");
            Console.WriteLine("8. Вывести рецепт напитка");
            Console.WriteLine("9. Вывести все приготовленные напитки: ");
            Console.WriteLine("10. Выход");
            Console.Write("Введите номер действия: ");
        }

        public int GetUserChoice()
        {
            int choice = 0;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Неверный ввод. Попробуйте снова: ");
            }
            return choice;
        }

        public void RunMainMenu()
        {
            int choice = 0;
            do
            {
                DisplayMainMenu();
                choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        _coffeMachine.TurnToggle(true);
                        break;
                    case 2:
                        Console.Clear();
                        _coffeMachine.TurnToggle(false);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Введите количество воды для добавления (в мл): ");
                        int waterValue = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.AddWater(waterValue);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Введите количество кофе для добавления (в г): ");
                        int coffeValue = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.AddCoffe(coffeValue);
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Введите количество молока для добавления (в мл): ");
                        int milkValue = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.AddMilk(milkValue);
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("Выберите профиль [Espresso/Capuccino/Latte]: ");
                        string coffeProfile = Console.ReadLine().ToLower();
                        Console.Write("Введите колличество чашек: ");
                        int cupCoffe = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.PrepareDrink(TypeDrink.Espresso, cupCoffe, coffeProfile);
                        break;
                    case 7:
                        Console.Clear();
                        _coffeMachine.CleanMachine();
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Введите название напитка; ");
                        string? name = Console.ReadLine();
                        _coffeMachine.drinkIngredient(name!);
                        break;
                    case 9:
                        Console.Clear();
                        _coffeMachine.LogAllDrinks();
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Выход...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            } while (choice != 10);
        }
    }
}