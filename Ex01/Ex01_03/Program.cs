using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            startProgram();

            Console.ReadKey();
        }

        private static void startProgram()
        {
            int heightInput = getUserInput();

            Ex01_02.Program.printDiamond(heightInput);
        }

        private static int getUserInput()
        {
            int height;

            Console.WriteLine("Please enter wanted height");

            string userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out height))
            {
                Console.WriteLine("Wrong input! Please try again");
                userInput = Console.ReadLine();
            }

            if (height % 2 == 0)
            {
                height++;
            }

            return height;
        }
    }
}
