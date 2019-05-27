using System;

namespace Workshop
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (i % 5 == 0 && i % 7 == 0)
                {
                    Console.WriteLine("Ding Ding Bottle");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Ding Ding");
                }
                else if (i % 7 == 0)
                {
                    Console.WriteLine("Bottle");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}