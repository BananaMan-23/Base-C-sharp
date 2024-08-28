using System;
using Profile;
using Utils;

namespace Drink
{
    class Drinks
    {
        public TypeDrink Type { get; }
        public ProfileMenu ProfileMenu { get; }

        public Drinks(TypeDrink type, ProfileMenu profileMenu)
        {
            Type = type;
            ProfileMenu = profileMenu;
        }
    }
}