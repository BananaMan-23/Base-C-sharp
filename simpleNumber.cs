using System;

namespace simpleNumber
{
    public class Simple
    {
        private int maxValue;
        private int minValue;

        public Simple(int min, int max)
        {
            this.minValue = min;
            this.maxValue = max;
        }

        public void FindNumber()
        {
            Console.WriteLine("Простые числа в заданном диапазоне:");
            for (int i = minValue; i <= maxValue; i++)
            {
                if(IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;
            var limit = (int)Math.Floor(Math.Sqrt(num));
            for(int i = 3; i < limit; i+=2)
            {
                if(num % i  == 0) return false;
            }
            return true;
        }
    }
}