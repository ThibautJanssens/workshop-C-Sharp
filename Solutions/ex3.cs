using System;

namespace Workshop
{
    class Program
    {
        private static Random random = new Random();
        private static int SIZE = 10;
        static void Main(string[] args)
        {
            int[] table = InitialiseTab();

            int min = table[0], max = table[0], sum = 0;

            for (int i = 0; i < SIZE; i++)
            {
                if (min >= table[i])
                {
                    min = table[i];
                }
                if (max <= table[i])
                {
                    max = table[i];
                }
                sum += table[i];
            }

            ShowTab(table);
            Console.WriteLine("Min = {0},\n Max = {1},\n Sum = {2},\n Average = {3}", min, max, sum, sum / SIZE);
        }

        private static int[] InitialiseTab()
        {
            int[] table = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                table[i] = random.Next(1, 101);
            }
            return table;
        }

        private static void ShowTab(int[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine(table[i]);
            }

        }
    }
}