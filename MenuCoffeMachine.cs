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
            Console.WriteLine("6. Приготовить эспрессо");
            Console.WriteLine("7. Приготовить капуччино");
            Console.WriteLine("8. Приготовить латте");
            Console.WriteLine("9. Очистить кофемашину");
            Console.WriteLine("10. Вывести рецепт напитка");
            Console.WriteLine("11. Вывести все приготовленные напитки: ");
            Console.WriteLine("12. Выход");
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
                        _coffeMachine.TurnOn();
                        break;
                    case 2:
                        _coffeMachine.TurnOff();
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
                        Console.Write("Введите колличество чашек: ");
                        int cupEspresso = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.PrepareDrink(TypeDrink.Espresso, cupEspresso);
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Введите колличество чашек: ");
                        int cupCapuccino = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.PrepareDrink(TypeDrink.Capuccino, cupCapuccino);
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Введите колличество чашек: ");
                        int cupLatte = Convert.ToInt32(Console.ReadLine());
                        _coffeMachine.PrepareDrink(TypeDrink.Latte, cupLatte);
                        break;
                    case 9:
                        Console.Clear();
                        _coffeMachine.CleanMachine();
                        break;
                    case 10:
                        Console.Clear();
                        Console.Write("Введите название напитка; ");
                        string name = Console.ReadLine();
                        _coffeMachine.drinkRecipe(name);
                        break;
                    case 11:
                        Console.Clear();
                        _coffeMachine.LogAllDrinks();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("Выход...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            } while (choice != 12);
        }
    }
}