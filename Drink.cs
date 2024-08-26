using System;
using Utils;

namespace Drink
{
    class Drinks
    {
        public TypeDrink Type { get; }
        public int Coffee { get; }
        public int Milk { get; }

        public Drinks(TypeDrink type, int coffee, int milk)
        {
            Type = type;
            Coffee = coffee;
            Milk = milk;
        }
    }
}