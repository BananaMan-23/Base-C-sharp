using System;
using CoffeeMachine;
using menuCoffeMachine;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffe coffeMachine = new Coffe();
            CoffeDisplay coffeDisplay = new CoffeDisplay(coffeMachine);
            coffeDisplay.RunMainMenu();
        }
    }
}