using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpacesClass : IExecutable
    {
        public void countSpaces()
        {
            string userInput;
            int numOfSpaces = 0;

            Console.WriteLine("Please enter a sentence");
            userInput = Console.ReadLine();
            foreach (char ch in userInput)
            {
                if (ch == ' ')
                {
                    numOfSpaces++;
                }
            }

            Console.WriteLine("The number of spaces found in the string is {0}{1}", numOfSpaces, Environment.NewLine);
        }

        public void Execute()
        {
            countSpaces();
        }
    }
}