using System;

namespace Workshop
{
    class Program
    {

        static void Main(string[] args)
        {
            int min, max, current;

            Console.WriteLine("Please enter a min");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a max");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a current nomber");
            current = Convert.ToInt32(Console.ReadLine());

            if (min > max)
            {
                Console.WriteLine("Go back to primary school to learn the difference between min and max...");
            }
            else if (current > min && current < max)
            {
                Console.WriteLine("Current is in between min and max.");
            }
            else if (current < min)
            {
                Console.WriteLine("Current is lower than min.");
            }
            else if (current > max)
            {
                Console.WriteLine("Current is greater than max.");
            }
        }

    }
}