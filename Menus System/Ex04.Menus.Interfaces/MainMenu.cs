using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const int k_MinChoice = 0;

        protected readonly string r_MenuName;
        protected List<MenuItem> m_MenuItems = null;

        public MainMenu(string i_MenuName)
        {
            r_MenuName = i_MenuName;
        }

        public string MenuName
        {
            get
            {
                return r_MenuName;
            }
        }

        public void RunMenu()
        {
            int userChoice;
            bool v_isRuning = true;

            while (v_isRuning)
            {
                try
                {
                    showMenu();
                    userChoice = getMenuChoiceInRange(m_MenuItems.Count);
                    Console.Clear();
                    if (userChoice != k_MinChoice)
                    {
                        runUserChoice(userChoice);
                    }
                    else
                    {
                        v_isRuning = false;
                    }
                }
                catch (FormatException i_FormatException)
                {
                    Console.WriteLine("Wrong format enetred! An integer is expected. Please try again");
                }
                catch (ArgumentException i_ArgumentException)
                {
                    Console.WriteLine($"Wrong range entered! Please try again");
                }
            }
        }

        private void showMenu()
        {
            int index = 1;

            Console.WriteLine($"**{r_MenuName}**");
            Console.WriteLine("=====================");
            foreach (MenuItem item in m_MenuItems)
            {
                Console.WriteLine($"{index} --> {item.r_MenuName}");
                index++;
            }

            printBackOrExitByType();
        }

        private void printBackOrExitByType()
        {
            if (this is MenuItem)
            {
                Console.WriteLine("0 --> Back");
            }
            else
            {
                Console.WriteLine("0 --> Exit");
            }
        }

        private int getMenuChoiceInRange(int i_MaxChoice)
        {
            string choice;
            int choiceInNum;

            printBackOrExitInInstructionsByType(i_MaxChoice);
            choice = Console.ReadLine();

            if (!int.TryParse(choice, out choiceInNum))
            {
                throw new FormatException();
            }

            if (choiceInNum < k_MinChoice || choiceInNum > i_MaxChoice)
            {
                throw new ArgumentException();
            }

            return choiceInNum;
        }

        private void printBackOrExitInInstructionsByType(int i_MaxChoice)
        {
            Console.Write($"Enter your request: ({k_MinChoice + 1} to {i_MaxChoice} or press '0' to ");

            if (this is MenuItem)
            {
                Console.WriteLine("Back)");
            }
            else
            {
                Console.WriteLine("Exit)");
            }
        }

        private void runUserChoice(int i_UserChoice)
        {
            MenuItem menuItem = m_MenuItems[i_UserChoice - 1];

            if (menuItem.IsExecutable())
            {
                menuItem.Executable.Execute();
            }
            else
            {
                menuItem.RunMenu();
            }
        }

        public void AddItemToMenu(MenuItem i_MenuItem)
        {
            if (m_MenuItems == null)
            {
                m_MenuItems = new List<MenuItem>();
            }

            m_MenuItems.Add(i_MenuItem);
        }

        public void RemoveItemFromMenu(MenuItem i_MenuItem)
        {
            m_MenuItems.Remove(i_MenuItem);
        }
    }
}
