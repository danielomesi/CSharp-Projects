using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        private const int k_InputHeight = 9;

        private const int k_Start = 1;

        public static void Main()
        {
            printDiamond(k_InputHeight);

            Console.ReadKey();
        }

        public static void printDiamond(int i_Height)
        {
            printDiamondRecursively(i_Height, k_Start);
        }
       
        private static void printDiamondRecursively(int i_Height, int i_NumOfStars)
        {
            if (i_Height == 1)
            {
                printLineOfNStars(i_NumOfStars, i_Height);
                return;
            }

            printLineOfNStars(i_NumOfStars, i_Height);
            printDiamondRecursively(i_Height - 2, i_NumOfStars + 2);
            printLineOfNStars(i_NumOfStars, i_Height);
        }

        private static void printLineOfNStars(int i_NumOfStars, int i_Height)
        {
            int i;
            StringBuilder Line = new StringBuilder();
            for (i = 0; i < i_Height / 2; i++)
            {
                Line.Append(' ');
            }

            for (i = 0; i < i_NumOfStars; i++)
            {
                Line.Append('*');
            }

            Console.WriteLine(Line);
        }
    }
}
