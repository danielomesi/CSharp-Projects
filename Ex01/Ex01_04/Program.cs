using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        private const int k_LegalLength = 6;

        private const int k_Start = 0;

        public static void Main()
        {
            startProgram();

            Console.ReadKey();
        }

        private static void startProgram()
        {
            bool v_IsNumberInput = getUserInput(out string userInput, out int numberInput);

            isPalindrome(userInput);

            // The string contains numbers only.
            if (v_IsNumberInput) 
            {
                isNumberMod3(numberInput);
            }
            else
            {
                countUpperCase(userInput);
            }
        }

        private static void countUpperCase(string i_UserInput)
        {
            int upperCaseCounter = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (i_UserInput[i] >= 'A' && i_UserInput[i] <= 'Z')
                {
                    upperCaseCounter++;
                }
            }

            Console.WriteLine($"There are {upperCaseCounter} upper case letters in this string");
        }

        private static void isNumberMod3(int i_NumberInput)
        {
            if (i_NumberInput % 3 == 0)
            {
                Console.WriteLine("This number can be divided by 3");
            }
            else
            {
                Console.WriteLine("This number can not be divided by 3");
            }
        }

        private static void isPalindrome(string i_userInput)
        {
            int end = i_userInput.Length - 1;

            if (isPalindromeRec(i_userInput, k_Start, end)) 
            {
                Console.WriteLine("This string is a palindrome");
            }
            else
            {
                Console.WriteLine("This string is not a palindrome");
            }
        }

        private static bool isPalindromeRec(string i_UserInput, int i_Start, int i_End)
        {
            if (i_End <= i_Start)
            {
                return true;
            }

            if (i_UserInput[i_Start] == i_UserInput[i_End])
            {
                return isPalindromeRec(i_UserInput, i_Start + 1, i_End - 1);
            }

            return false;
        }

        // If the string is a number, the method returns true, if the string contains only alphabet characters, the method returns false.
        private static bool getUserInput(out string o_UserInput, out int o_NumberInput)
        {
            // Initialized to false so if the string will not be marked as a number, v_IsNumber will remain false.
            bool v_IsNumber = false;

            Console.WriteLine("Please enter an input");
            o_UserInput = Console.ReadLine();

            while(o_UserInput.Length != k_LegalLength || (!isNumber(o_UserInput, out o_NumberInput, ref v_IsNumber) && !isAlphabet(o_UserInput)))
            {
                Console.WriteLine("Wrong input! Please try again");
                o_UserInput = Console.ReadLine();
            }

            return v_IsNumber;
        }

        private static bool isNumber(string i_UserInput, out int o_NumberInput, ref bool io_IsNumber)
        {
            if(int.TryParse(i_UserInput, out o_NumberInput))
            {
                io_IsNumber = true;
                return true;
            }

            return false;
        }

        private static bool isAlphabet(string i_UserInput)
        {
            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!(char.IsLetter(i_UserInput[i]) && ((i_UserInput[i] >= 'a' && i_UserInput[i] <= 'z') || (i_UserInput[i] >= 'A' && i_UserInput[i] <= 'Z'))))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
