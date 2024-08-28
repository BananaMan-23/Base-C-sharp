using System;
using Utils;
using Drink;
using Profile;


namespace CoffeeMachine
{
    class Coffe
    {
        private const int MAX_LEVEL_WATER = 1000;
        private const int MAX_LEVEL_COFFEE = 500;
        private const int MAX_LEVEL_MILK = 1000;
        private const int MAX_LEVEL_DIRT = 5;

        private bool _isOn;
        private int _LevelWater;
        private int _LevelCoffe;
        private int _LevelMilk;
        private List<Drinks> _RecipeDrink;
        private Dictionary<string, ProfileMenu> _Profiles;
        private int _LevelDirt;

        public Coffe()
        {
            _isOn = false;
            _LevelWater = 0;
            _LevelCoffe = 0;
            _LevelMilk = 0;
            _LevelDirt = 0;
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
                {"espresso", new ProfileMenu("espresso", 20, 0, 50)},
                {"capuccino", new ProfileMenu("capuccino", 15, 50, 100)},
                {"latte", new ProfileMenu("latte", 15, 75, 75)},
            };

        }

        public void TurnToggle(bool value)
        {
            bool currentState = _isOn;
            bool newState = value;
            if (newState != currentState)
            {
                _isOn = newState;

                if (_isOn)
                {
                    Console.WriteLine("Машина включена!");
                }
                else
                {
                    Console.WriteLine("Машина выключена!");
                }
            }
            else
            {
                Console.WriteLine($"Состояние машины не изменилось. Текущее состояние: {_isOn}");
            }
        }

        public void AddWater(int value)
        {
            if (_LevelWater + value > MAX_LEVEL_WATER)
            {
                Console.WriteLine("Уровень воды превышен!");
            }
            _LevelWater += value;
        }

        public void AddCoffe(int value)
        {
            if (_LevelCoffe + value > MAX_LEVEL_COFFEE)
            {
                Console.WriteLine("Уровень Кофе слишком высок!");
            }
            _LevelCoffe += value;
        }

        public void AddMilk(int value)
        {
            if (_LevelMilk + value > MAX_LEVEL_MILK)
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
            int waterNeed = profile.WaterValue * cups;
            if (_LevelCoffe < coffeNeed || _LevelMilk < milkNeed || _LevelWater < waterNeed || _LevelDirt < MAX_LEVEL_DIRT)
            {
                Console.WriteLine("Недостаточно ингредиентов или требуется чистка");
                return;
            }
            _LevelCoffe -= coffeNeed;
            _LevelMilk -= milkNeed;
            _LevelWater -= waterNeed;
            _LevelDirt += 1;
            if (_LevelDirt < MAX_LEVEL_DIRT)
            {
                Drinks drink = new Drinks(type, profile);
                _RecipeDrink.Add(drink);
                Console.WriteLine($"Приготовлен {drink.ProfileMenu.Name} с {coffeNeed}гр. кофе и {milkNeed}мл. молока");
            }
            else
            {
                Console.WriteLine("Аппарат загрязнен и требуется в чистке!");
            }
        }

        public void CleanMachine()
        {
            if (!_isOn)
            {
                Console.WriteLine("Аппарат выключен!");
            }
            if (_LevelDirt > 0)
            {
                _LevelDirt = 0;
                Console.WriteLine("Аппарат очищен!");
            }
            else
            {
                Console.WriteLine("чистка не требуется!");
            }
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

        public void drinkIngredient(string drinkname)
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