using System;

namespace taskTwo
{
    public class TaskTwo
    {
        private double number1;
        private double number2;

        public TaskTwo(double number1, double number2)
        {
            this.number1 = number1;
            this.number2 = number2;
        }

        public void SumNumber()
        {
            if(number1 > number2)
            {
                Console.WriteLine($"Число {number1} больше числа {number2}");
            }
            else if(number1 < number2)
            {
                Console.WriteLine($"Число {number1} меньше числа {number2}");
            }
            else
            {
                Console.WriteLine("Числа равны");
            }
            double sum = number1 + number2;
            Console.WriteLine($"Сумма чисел {number1} и {number2} = {sum}");
        }
        
    }
}