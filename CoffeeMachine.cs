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

        public void PrepareDrink(TypeDrink type)
        {
            if (!_isOn)
            {
                Console.WriteLine("Аппарат выключен!");
            }
            if (type == TypeDrink.Espresso && _LevelCoffe < 10)
            {
                Console.WriteLine("Недостаточно кофе");
            }
            if (type == TypeDrink.Capuccino && _LevelCoffe < 10 && _LevelMilk < 50)
            {
                Console.WriteLine("Недостаточно кофе и молока");
            }
            if (type == TypeDrink.Latte && _LevelCoffe < 15 && _LevelMilk < 100)
            {
                Console.WriteLine("Недостаточно кофе и молока");
            }

            Drinks drink = new Drinks(type, _LevelCoffe, _LevelMilk);
            _RecipeDrink.Add(drink);
            _LevelCoffe -= 10;
            _LevelMilk -= 20;
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
    }
}