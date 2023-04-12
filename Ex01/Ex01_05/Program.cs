using System;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        private const int k_LegalLength = 6;

        public static void Main()
        {
            startProgram();

            Console.ReadKey();
        }
        
        private static void startProgram()
        {
            string userInput = getUserInput();

            getNumberStatistics(userInput);
        }

        private static string getUserInput()
        {
            Console.WriteLine("Please enter a 6-digit integer");

            string userInput = Console.ReadLine();

            while (userInput.Length != k_LegalLength || !isNumber(userInput))
            {
                Console.WriteLine("Wrong input! Please try again");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool isNumber(string i_UserInput)
        {
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!char.IsDigit(i_UserInput[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static void getNumberStatistics(string i_Number)
        {
            int countDigitMod3 = 0, currentDigit, countBiggerDigits = 0, sumDigits = 0;
            
            int leastSignificantDigit = i_Number[i_Number.Length - 1] - '0';

            int minDigit = leastSignificantDigit;

            for (int i = i_Number.Length - 1; i >= 0; i--)
            {
                currentDigit = (int)char.GetNumericValue(i_Number[i]);
                isDigitMod3(currentDigit, ref countDigitMod3);
                isBiggerThanLeastSignificantDigit(currentDigit, leastSignificantDigit, ref countBiggerDigits);
                updateMin(currentDigit, ref minDigit);
                sumDigits += currentDigit;
            }

            double digitsAverage = (double)sumDigits / (double)k_LegalLength;

            printStatistics(countBiggerDigits, minDigit, countDigitMod3, digitsAverage);
        }

        private static void printStatistics(int i_CountBiggerDigits, int i_MinDigit, int i_CountDigitMod3, double i_DigitsAverage)
        {
            string biggerDigitsStats = string.Format("There are {0} digits that are bigger than the least significant digit", i_CountBiggerDigits);

            string minDigitStats = string.Format("The smallest digit is {0}", i_MinDigit);

            string mod3Stats = string.Format("There are {0} digits that can be divided by 3", i_CountDigitMod3);

            string averageStats = string.Format("The average of the digits is {0:F3}", i_DigitsAverage);

            Console.WriteLine(biggerDigitsStats);

            Console.WriteLine(minDigitStats);

            Console.WriteLine(mod3Stats);

            Console.WriteLine(averageStats);
        }

        private static void isDigitMod3(int i_Digit, ref int io_CountDigitMod3)
        {
            if (i_Digit % 3 == 0)
            {
                io_CountDigitMod3++;
            }
        }

        private static void isBiggerThanLeastSignificantDigit(int i_Digit, int i_LeastSignificantDigit, ref int io_CountBiggerDigits)
        {
            if (i_Digit > i_LeastSignificantDigit)
            {
                io_CountBiggerDigits++;
            }
        }

        private static void updateMin(int i_Digit, ref int io_MinDigit)
        {
            if (i_Digit < io_MinDigit)
            {
                io_MinDigit = i_Digit;
            }
        }
    }
}
