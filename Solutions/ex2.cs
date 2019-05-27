using System;

namespace Workshop
{
    class Program
    {

        static void Main(string[] args)
        {
            int i = 0;
            while (i <= 100)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }

            /*
             for (int i=0; i <=100; i++){
                if(i%2 ==0){
                    Console.WriteLine(i);    
                }
             }
            */
        }

    }
}