using System;
using CoffeeMachine;
using Utils;
using Drink;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee coffeMachine = new Coffee();

            coffeMachine.TurnOn();
            coffeMachine.AddWater(100);
            coffeMachine.AddCoffe(50);
            coffeMachine.AddMilk(100);

            coffeMachine.PrepareDrink(TypeDrink.Espresso);
            coffeMachine.PrepareDrink(TypeDrink.Espresso);
            coffeMachine.PrepareDrink(TypeDrink.Latte);
            coffeMachine.LogDrink(new Drinks(TypeDrink.Espresso, 10, 0));
            coffeMachine.LogDrink(new Drinks(TypeDrink.Capuccino, 10, 20));
            coffeMachine.LogDrink(new Drinks(TypeDrink.Latte, 10, 30));
        }
    }
}