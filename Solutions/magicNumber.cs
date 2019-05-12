using System;

namespace Algo
{
    class MainClass
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            //variables
            bool play = true;
            int magicNbr, nbrOfTry, choice;

            Console.WriteLine("Welcome to this game of the magic number.");

            //game
            do
            {
                Console.WriteLine("I choosed a number between 1 and 100.");
                Console.WriteLine("Let's see if you can find it.");
                magicNbr = random.Next(1, 101);
                nbrOfTry = 0;

                //while the user is still trying to find the number
                do
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    nbrOfTry++;

                    if (choice < magicNbr)
                    {
                        Console.WriteLine("My number is greater than yours.");
                    }
                    else if(choice > magicNbr)
                    {
                        Console.WriteLine("My number is lower than yours.");    
                    }
                } 
                while (choice != magicNbr); //user found the number

                Console.WriteLine("Congratulations! You found the number in {0} rounds.", nbrOfTry);
                Console.WriteLine("Do you want to continue playing? Y/N.");
                String endChoice = Console.ReadLine();

                while (endChoice != "Y" && endChoice != "y" && endChoice == "N" && endChoice == "n")
                {
                    Console.WriteLine("Not a valid choice. Press Y or N");
                    Console.WriteLine("Do you want to continue playing? Y/N.");
                    endChoice = Console.ReadLine();
                }
                if(endChoice == "N" || endChoice == "n")
                {
                    play = false;
                }
            } 
            while (play); //end of game
            Console.WriteLine("Goodbye, thanks for playing.");
        }
    }
}
