using System;

namespace Ex01_01
{
    public class Program
    {
        private const int k_NumOfDigits = 8;

        private const int k_SizeOfInput = 3;

        private const int k_DecimalBase = 10;

        public static void Main()
        {
            startProgram();
            Console.ReadKey();
        }

        private static void startProgram()
        {
            int countZeros = 0, countOnes = 0;
            int countNumsMod4 = 0, countNumsDescendingSeries = 0, countNumsPalindrome = 0;

            Console.WriteLine("Please enter 3 binary numbers, each one formed by 8 digits");

            // To avoid using arrays (yet to be learned in courses), it is implemented like this.
            getInputFromUser(out string userInput, ref countZeros, ref countOnes);
            int decimalNumber1 = getStatistics(userInput, ref countNumsMod4, ref countNumsDescendingSeries, ref countNumsPalindrome);

            getInputFromUser(out userInput, ref countZeros, ref countOnes);
            int decimalNumber2 = getStatistics(userInput, ref countNumsMod4, ref countNumsDescendingSeries, ref countNumsPalindrome);

            getInputFromUser(out userInput, ref countZeros, ref countOnes);
            int decimalNumber3 = getStatistics(userInput, ref countNumsMod4, ref countNumsDescendingSeries, ref countNumsPalindrome);

            printSortedDecimals(decimalNumber1, decimalNumber2, decimalNumber3);
            printStatistics(countNumsMod4, countNumsDescendingSeries, countNumsPalindrome, countZeros, countOnes);
        }

        private static void printSortedDecimals(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int firstNumber = i_DecimalNumber1;
            int secondNumber = i_DecimalNumber2;
            int thirdNumber = i_DecimalNumber3;

            if (firstNumber < secondNumber)
            {
                swap(ref firstNumber, ref secondNumber);
            }

            if (secondNumber < thirdNumber)
            {
                swap(ref secondNumber, ref thirdNumber);
            }

            if (firstNumber < secondNumber)
            {
                swap(ref firstNumber, ref secondNumber);
            }

            Console.WriteLine($"{firstNumber}, {secondNumber}, {thirdNumber}"); 
        }

        private static void swap(ref int io_FirstNumber, ref int io_SecondNumber)
        {
            int tempNumber = io_FirstNumber;
            io_FirstNumber = io_SecondNumber;
            io_SecondNumber = tempNumber;
        }

        private static void getInputFromUser(out string o_UserInput, ref int io_CountZeros, ref int io_CountOnes)
        {
            bool v_IsValid = false;
            string userInput = Console.ReadLine();

            while (!v_IsValid)
            {
                if (userInput.Length == k_NumOfDigits && runBinaryCheck(userInput, ref io_CountZeros, ref io_CountOnes))
                {
                    v_IsValid = true;
                }
                else
                {
                    Console.WriteLine("Wrong input! Please try again");
                    userInput = Console.ReadLine();
                }
            }

            o_UserInput = userInput;
        }

        private static int getStatistics(string i_UserInput, ref int io_CountNumsMod4, ref int io_CountNumsDescendingSeries, ref int io_CountNumsPalindrome)
        {
            int currentBinaryNumber = int.Parse(i_UserInput);
            int currentDecimalNumber = binaryToDecimal(currentBinaryNumber);
            isDividedBy4(ref io_CountNumsMod4, currentDecimalNumber);
            isDescendingSeries(ref io_CountNumsDescendingSeries, currentDecimalNumber);
            isPalindrome(ref io_CountNumsPalindrome, currentDecimalNumber);
            return currentDecimalNumber;
        }

        private static bool runBinaryCheck(string i_UserInput, ref int io_CountZeros, ref int io_CountOnes)
        {
            int countZeros = 0, countOnes = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] == '0')
                {
                    countZeros++;
                }
                else if (i_UserInput[i] == '1')
                {
                    countOnes++;
                }
                else
                {
                    return false;
                }
            }

            io_CountZeros += countZeros;
            io_CountOnes += countOnes;
            return true;
        }

        private static void printStatistics(int i_CountNumsMod4, int i_CountNumsDescendingSeries, int i_CountNumsPalindrome, int i_CountZeroes, int i_CountOnes)
        {
            double averageAppearnceOfZero = (double)i_CountZeroes / (double)k_SizeOfInput;
            double averageAppearnceOfOne = (double)i_CountOnes / (double)k_SizeOfInput;

            Console.WriteLine($"Average occurence of digit 0 is {averageAppearnceOfZero:F3} per number");
            Console.WriteLine($"Average occurence of digit 1 is {averageAppearnceOfOne:F3} per number");
            Console.WriteLine($"There are {i_CountNumsMod4} numbers that can be divided by 4");
            Console.WriteLine($"There are {i_CountNumsDescendingSeries} numbers that their digits are considered as descending series");
            Console.WriteLine($"There are {i_CountNumsPalindrome} palindrome numbers");
        }

        private static void isDividedBy4(ref int io_CountNumsMod4, int i_Number)
        {
            if(i_Number % 4 == 0)
            {
                io_CountNumsMod4++;
            }
        }

        private static void isDescendingSeries(ref int io_CountNumsDescendingSeries, int i_Number)
        {
            int lastDigit = i_Number % k_DecimalBase, nextDigit;
            i_Number /= k_DecimalBase;
            while (i_Number > 0)
            {
                nextDigit = i_Number % k_DecimalBase;

                if (lastDigit >= nextDigit)
                {
                    return;
                }

                lastDigit = nextDigit;
                i_Number /= k_DecimalBase;
            }

            io_CountNumsDescendingSeries++;
        }

        private static void isPalindrome(ref int io_CountNumsPalindrome, int i_Number)
        {
            int reversedNumber = 0, copyOfNubmer = i_Number, digit;
            while (copyOfNubmer > 0)
            {
                digit = copyOfNubmer % k_DecimalBase;
                reversedNumber = (reversedNumber * k_DecimalBase) + digit;
                copyOfNubmer /= k_DecimalBase;
            }

            if (reversedNumber == i_Number)
            {
                io_CountNumsPalindrome++;
            }
        }

        private static int binaryToDecimal(int i_BinaryNum)
        {
            int resDecimalNum = 0, lastDigit, exponent = 0;

            while (i_BinaryNum != 0)
            {
                lastDigit = i_BinaryNum % 2;
                i_BinaryNum /= k_DecimalBase;
                resDecimalNum += (int)Math.Pow(2, exponent) * lastDigit;
                exponent++;
            }

            return resDecimalNum;
        }
    }
}
