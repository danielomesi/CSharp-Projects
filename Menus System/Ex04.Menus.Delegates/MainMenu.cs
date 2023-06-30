using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const int k_MinChoice = 0;

        private SubMenuItem m_MenuMain;
        private Stack m_MenusStack;

        public MainMenu(string i_Name)
        {
            m_MenuMain = new SubMenuItem(i_Name);
            m_MenusStack = new Stack();
            m_MenusStack.Push(m_MenuMain);
        }

        public SubMenuItem MenuMain
        {
            get
            {
                return m_MenuMain;
            }
        }

        public void RunMenu()
        {
            SubMenuItem currentDisplayedMenu;
            int menuChoice, maxChoice;

            while (!isEmpty())
            {
                try
                {
                    currentDisplayedMenu = m_MenusStack.Peek() as SubMenuItem;
                    maxChoice = currentDisplayedMenu.MenuItems.Count();
                    showMenu(currentDisplayedMenu, maxChoice);
                    menuChoice = getMenuChoiceInRange(maxChoice);
                    Console.Clear();
                    if (menuChoice != k_MinChoice)
                    {
                        runUserChoice(currentDisplayedMenu, menuChoice);
                    }
                    else
                    {
                        m_MenusStack.Pop();
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

        private void runUserChoice(SubMenuItem i_CurrentDisplayedMenu, int i_UserChoice)
        {
            MenuItem menuItem = i_CurrentDisplayedMenu.MenuItems[i_UserChoice - 1];
            ExecutableItem executableItem;

            executableItem = menuItem as ExecutableItem;
            if (executableItem != null)
            {
                executableItem.OnClick();
            }
            else
            {
                m_MenusStack.Push(menuItem);
            }
        }

        private bool isEmpty()
        {
            bool v_IsEmpty = true;

            if(m_MenusStack.Count != 0)
            {
                v_IsEmpty = false;
            }

            return v_IsEmpty;
        }

        private void showMenu(SubMenuItem i_SubMenu, int i_MaxChoice)
        {
            Console.WriteLine($"**{i_SubMenu.Name}**");
            Console.WriteLine("=====================");
            i_SubMenu.ShowMenu();
            showOptionOfBackOrExit();
            printBackOrExitInInstructionsByType(i_MaxChoice);
        }

        private void showOptionOfBackOrExit()
        {
            Console.Write("0 --> ");

            if (m_MenusStack.Count == 1) // if the stack size is 1, means that we currently in the main menu.
            {
                Console.WriteLine("Exit");
            }
            else
            {
                Console.WriteLine("Back");
            }
        }

        private void printBackOrExitInInstructionsByType(int i_MaxChoice)
        {
            Console.Write($"Enter your request: ({k_MinChoice + 1} to {i_MaxChoice} or press '0' to ");

            if (m_MenusStack.Count == 1)
            {
                Console.WriteLine("Exit)");
            }
            else
            {
                Console.WriteLine("Back)");
            }
        }

        private int getMenuChoiceInRange(int i_MaxChoice)
        {
            string choice;
            int choiceInNum;

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
    }
}
