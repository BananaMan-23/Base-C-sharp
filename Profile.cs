using System;

namespace Profile
{
    public class ProfileMenu
    {
        public string Name { get; set; }
        public int CoffeValue { get; set; }
        public int MilkValue { get; set; }

        public ProfileMenu(string name, int coffeValue, int milkValue)
        {
            Name = name;
            CoffeValue = coffeValue;
            MilkValue = milkValue;
        }
    }
}