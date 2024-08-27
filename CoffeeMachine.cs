using System;
using Utils;
using Drink;


namespace CoffeeMachine
{
    class Coffe
    {
        private bool _isOn;
        private int _LevelWater;
        private int _LevelCoffe;
        private int _LevelMilk;
        private List<Drinks> _RecipeDrink;

        public Coffe()
        {
            _isOn = false;
            _LevelWater = 0;
            _LevelCoffe = 0;
            _LevelMilk = 0;
            _RecipeDrink = new List<Drinks>();
        }
        public bool IsOn { get; set; }
        public int LevelWater { get; set; }
        public bool LevelCoffe { get; set; }
        public int LevelMilk { get; set; }
        public List<Drinks>? RecipeDrink { get; }

        public void TurnOn()
        {
            if (_isOn)
            {
                Console.WriteLine("Машина уже включена");
            }
            _isOn = true;
        }

        public void TurnOff()
        {
            if (!_isOn)
            {
                Console.WriteLine("Машина уже выключена");
            }
            _isOn = false;
        }

        public void AddWater(int value)
        {
            if (_LevelWater + value > 250)
            {
                Console.WriteLine("Уровень воды превышен!");
            }
            _LevelWater += value;
        }

        public void AddCoffe(int value)
        {
            if (_LevelCoffe + value > 100)
            {
                Console.WriteLine("Уровень Кофе слишком высок!");
            }
            _LevelCoffe += value;
        }

        public void AddMilk(int value)
        {
            if (_LevelMilk + value > 250)
            {
                Console.WriteLine("Слишком много молока!");
            }
            _LevelMilk += value;
        }

        public void PrepareDrink(TypeDrink type, int cups)
        {
            if (!_isOn)
            {
                Console.WriteLine("Аппарат выключен!");
                return;
            }
            int coffeNeed = 10 * cups;
            int milkneed = 10 * cups;

            switch (type)
            {
                case TypeDrink.Espresso:
                    if (_LevelCoffe < coffeNeed)
                    {
                        Console.WriteLine("Недостаточно кофе!");
                        return;
                    }
                    _LevelCoffe -= coffeNeed;
                    break;
                case TypeDrink.Capuccino:
                    if (_LevelCoffe < coffeNeed || _LevelMilk < milkneed)
                    {
                        Console.WriteLine("Недостаточно кофе и молока!");
                        return;
                    }
                    _LevelCoffe -= coffeNeed;
                    _LevelMilk -= milkneed;
                    break;
                case TypeDrink.Latte:
                    if (_LevelCoffe < coffeNeed || _LevelMilk < milkneed * 2)
                    {
                        Console.WriteLine("Недостаточно кофе и молока!");
                        return;
                    }
                    _LevelCoffe -= coffeNeed;
                    _LevelMilk -= milkneed * 2;
                    break;
            }
            Drinks drink = new Drinks(type, coffeNeed, milkneed);
            _RecipeDrink.Add(drink);
            LogDrink(drink);
        }

        public void CleanMachine()
        {
            if (!_isOn)
            {
                Console.WriteLine("Аппарат выключен!");
            }
            _LevelCoffe = 0;
            _LevelMilk = 0;
            Console.WriteLine("Аппарат очищен!");
        }

        public void LogDrink(Drinks drink)
        {
            Console.WriteLine($"Готовый {drink.Type} с {drink.Coffee}гр. кофе и {drink.Milk}гр. молока");
        }
        public void LogAllDrinks()
        {
            Console.WriteLine("Все приготовленные напитки: ");
            foreach (var drink in _RecipeDrink)
            {
                LogDrink(drink);
            }
        }

        public void drinkRecipe(string drinkname)
        {
            switch (drinkname.ToLower())
            {
                case "Espresso":
                    Console.WriteLine("Еспрессо 20гр. кофе");
                    break;
                case "Capuccino":
                    Console.WriteLine("Капучино 20гр. кофе и 50мл. молока");
                    break;
                case "Latte":
                    Console.WriteLine("Латте 15гр. кофе и 50мл. молока");
                    break;
                default:
                    Console.WriteLine("Напиток не найден");
                    break;
            }
        }
    }
}