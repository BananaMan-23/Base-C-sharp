using System;

namespace Profile
{
    public class ProfileMenu
    {
        public string Name { get; set; }
        public int CoffeValue { get; set; }
        public int MilkValue { get; set; }
        public int WaterValue { get; set; }
        public ProfileMenu(string name, int coffeValue, int milkValue, int waterValue)
        {
            Name = name;
            CoffeValue = coffeValue;
            MilkValue = milkValue;
            WaterValue = waterValue;
        }
    }
}