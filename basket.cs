using System;

namespace basket
{
    public class BasketItem
    {
        private List<string> products = new List<string>();

        public void AddProduct(string product)
        {
            products.Add(product);
        }

        public void PrintBasket()
        {
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
    }
}