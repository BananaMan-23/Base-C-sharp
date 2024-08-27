using System;
using Utils;
using Drink;
using Profile;


namespace CoffeeMachine
{
    class Coffe
    {
        private bool _isOn;
        private int _LevelWater;
        private int _LevelCoffe;
        private int _LevelMilk;
        private List<Drinks> _RecipeDrink;
        private Dictionary<string, ProfileMenu> _Profiles;

        public Coffe()
        {
            _isOn = false;
            _LevelWater = 0;
            _LevelCoffe = 0;
            _LevelMilk = 0;
            _RecipeDrink = new List<Drinks>();
            InitProfile();
        }
        public bool IsOn { get; set; }
        public int LevelWater { get; set; }
        public bool LevelCoffe { get; set; }
        public int LevelMilk { get; set; }
        public List<Drinks>? RecipeDrink { get; }

        private void InitProfile()
        {
            _Profiles = new Dictionary<string, ProfileMenu>
            {
                {"espresso", new ProfileMenu("espresso", 20, 0)},
                {"capuccino", new ProfileMenu("capuccino", 15, 50)},
                {"latte", new ProfileMenu("latte", 15, 75)},
            };

        }

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
            if (_LevelWater + value > 500)
            {
                Console.WriteLine("Уровень воды превышен!");
            }
            _LevelWater += value;
        }

        public void AddCoffe(int value)
        {
            if (_LevelCoffe + value > 250)
            {
                Console.WriteLine("Уровень Кофе слишком высок!");
            }
            _LevelCoffe += value;
        }

        public void AddMilk(int value)
        {
            if (_LevelMilk + value > 500)
            {
                Console.WriteLine("Слишком много молока!");
            }
            _LevelMilk += value;
        }

        public void PrepareDrink(TypeDrink type, int cups, string profileName)
        {
            if (!_isOn)
            {
                Console.WriteLine("Аппарат выключен!");
                return;
            }
            if (!_Profiles.TryGetValue(profileName, out var profile))
            {
                Console.WriteLine("Профиль не найден");
                return;
            }
            int coffeNeed = profile.CoffeValue * cups;
            int milkNeed = profile.MilkValue * cups;
            if (_LevelCoffe < coffeNeed || _LevelMilk < milkNeed)
            {
                Console.WriteLine("Недостаточно кофе и молока");
                return;
            }
            _LevelCoffe -= coffeNeed;
            _LevelMilk -= milkNeed;

            Drinks drink = new Drinks(type, profile);
            _RecipeDrink.Add(drink);
            Console.WriteLine($"Приготовлен {drink.ProfileMenu.Name} с {coffeNeed}гр. кофе и {milkNeed}мл. молока");
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
            Console.WriteLine($"Готовый {drink.ProfileMenu.Name} с {drink.ProfileMenu.CoffeValue}гр. кофе и {drink.ProfileMenu.MilkValue}гр. молока");
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
                case "espresso":
                    Console.WriteLine("Еспрессо 20гр. кофе");
                    break;
                case "capuccino":
                    Console.WriteLine("Капучино 20гр. кофе и 50мл. молока");
                    break;
                case "latte":
                    Console.WriteLine("Латте 15гр. кофе и 50мл. молока");
                    break;
                default:
                    Console.WriteLine("Напиток не найден");
                    break;
            }
        }
    }
}