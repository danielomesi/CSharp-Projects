using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Test
    {
        public void StartDelegatesTest()
        {
            Delegates.MainMenu mainMenudDelegates = GetDelegatesMainMenu();
            mainMenudDelegates.RunMenu();

            Console.Clear();

            Interfaces.MainMenu mainMenuInterface = GetInterfacessMainMenu();
            mainMenuInterface.RunMenu();
        }

        private Delegates.MainMenu GetDelegatesMainMenu()
        {
            // Creating main menu object
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegate Main Menu");
            // Creating a main menu's sub menu
            Delegates.SubMenuItem dateAndTimeMenu = new Delegates.SubMenuItem("Show Date/Time");
            // Create and assign action item
            Delegates.ExecutableItem showDateItem = new Delegates.ExecutableItem("Show Date");
            PrintDateClass printDate = new PrintDateClass();
            showDateItem.ItemClicked += printDate.printDate;
            dateAndTimeMenu.AddItemToMenu(showDateItem);
            // Create and assign action item
            Delegates.ExecutableItem showTimeItem = new Delegates.ExecutableItem("Show Time");
            PrintTimeClass printTime = new PrintTimeClass();
            showTimeItem.ItemClicked += printTime.printTime;
            dateAndTimeMenu.AddItemToMenu(showTimeItem);
            // Add the sub menu to the main menu
            mainMenu.MenuMain.AddItemToMenu(dateAndTimeMenu);
            // Creating a main menu's sub menu
            Delegates.SubMenuItem versionAndSpacesMenu = new Delegates.SubMenuItem("Version and Spaces");
            // Create and assign action item
            Delegates.ExecutableItem showVersionItem = new Delegates.ExecutableItem("Show Version");
            PrintVersionClass printVersion = new PrintVersionClass();
            showVersionItem.ItemClicked += printVersion.printVersion;
            versionAndSpacesMenu.AddItemToMenu(showVersionItem);
            // Create and assign action item
            Delegates.ExecutableItem countSpacesItem = new Delegates.ExecutableItem("Count Spaces");
            CountSpacesClass countSpaces = new CountSpacesClass();
            countSpacesItem.ItemClicked += countSpaces.countSpaces;
            versionAndSpacesMenu.AddItemToMenu(countSpacesItem);
            // Add the sub menu to the main menu
            mainMenu.MenuMain.AddItemToMenu(versionAndSpacesMenu);
            // Return the menu
            return mainMenu;
        }

        private Interfaces.MainMenu GetInterfacessMainMenu()
        {
            // Creating main menu object
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interface Main Menu");
            // Creating a main menu's sub menu
            Interfaces.MenuItem dateAndTimeMenu = new Interfaces.MenuItem("Show Date/Time");
            // Create and assign action item
            Interfaces.MenuItem showDateItem = new Interfaces.MenuItem("Show Date");
            PrintDateClass printDate = new PrintDateClass();
            showDateItem.InitializeExecutable(printDate);
            dateAndTimeMenu.AddItemToMenu(showDateItem);
            // Create and assign action item
            Interfaces.MenuItem showTimeItem = new Interfaces.MenuItem("Show Time");
            PrintTimeClass printTime = new PrintTimeClass();
            showTimeItem.InitializeExecutable(printTime);
            dateAndTimeMenu.AddItemToMenu(showTimeItem);
            // Add the sub menu to the main menu
            mainMenu.AddItemToMenu(dateAndTimeMenu);
            // Creating a main menu's sub menu
            Interfaces.MenuItem versionAndSpacesMenu = new Interfaces.MenuItem("Version and Spaces");
            // Create and assign action item
            Interfaces.MenuItem showVersionItem = new Interfaces.MenuItem("Show Version");
            PrintVersionClass printVersion = new PrintVersionClass();
            showVersionItem.InitializeExecutable(printVersion);
            versionAndSpacesMenu.AddItemToMenu(showVersionItem);
            // Create and assign action item
            Interfaces.MenuItem countSpacesItem = new Interfaces.MenuItem("Count Spaces");
            CountSpacesClass countSpaces = new CountSpacesClass();
            countSpacesItem.InitializeExecutable(countSpaces);
            versionAndSpacesMenu.AddItemToMenu(countSpacesItem);
            // Add the sub menu to the main menu
            mainMenu.AddItemToMenu(versionAndSpacesMenu);
            // Return the menu
            return mainMenu;
        }
    }
}