using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public enum eMenuOptions
    {
        AddCustomer = 1, PrintLicensePlates, UpdateVechileState, InflateAllWheelsToMax, RefuelVechile, 
        ChargeVechile, PrintFullVechileData, ExitTheProgram, ExitToMenu, 
    }

    public class ManageUI
    {
        private GarageManager m_Garage;

        // Manager methods:
        public void StartProgram()
        {
            int userChoice;
            bool v_IsRunning = true;
            m_Garage = new GarageManager();

            printWelcomeMessage();
            while(v_IsRunning)
            {
                printMenu();
                userChoice = manageUserChoice();
                executeChoice(userChoice, ref v_IsRunning);
            }

            Console.WriteLine("Thank you for using our garage");
        }

        private int manageUserChoice()
        {
            int userChoice = (int)eMenuOptions.ExitTheProgram;
            bool v_IsRunning = true;

            while (v_IsRunning)
            {
                try
                {
                    userChoice = Utilities.GetSingleNumInRange(1, 8);
                    v_IsRunning = false;
                }
                catch(Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                    printMenu();
                }
            }

            return userChoice;
        }

        private void executeChoice(int i_Choice, ref bool io_IsRunning)
        {
            string licensePlateNumber = null;
            eMenuOptions choice = (eMenuOptions)i_Choice;
            bool v_IsValidData = false;
            
            while (!v_IsValidData)
            {
                try
                {
                    if (choice != eMenuOptions.ExitTheProgram && choice != eMenuOptions.PrintLicensePlates)
                    {
                        licensePlateNumber = getLicensePlateNumber(ref choice);
                    }

                    switch (choice)
                    {
                        case eMenuOptions.AddCustomer:
                            readData(licensePlateNumber);
                            break;
                        case eMenuOptions.PrintLicensePlates:
                            printVechilesLicensePlates();
                            break;
                        case eMenuOptions.UpdateVechileState:
                            updateVechileState(licensePlateNumber);
                            break;
                        case eMenuOptions.InflateAllWheelsToMax:
                            inflateAllWheelsToMax(licensePlateNumber);
                            break;
                        case eMenuOptions.RefuelVechile:
                            refuelVechile(licensePlateNumber);
                            break;
                        case eMenuOptions.ChargeVechile:
                            chargeVechile(licensePlateNumber);
                            break;
                        case eMenuOptions.PrintFullVechileData:
                            printFullVechileData(licensePlateNumber);
                            break;
                        case eMenuOptions.ExitTheProgram:
                            io_IsRunning = false;
                            break;
                        case eMenuOptions.ExitToMenu:
                            break;
                    }

                    v_IsValidData = true;
                }
                catch (Exception i_Exception)
                {
                    Console.WriteLine(i_Exception.Message + " Please Try Again\n");
                }
            }
        }

        // Option #1 methods:
        private void readData(string i_LicensePlateNumber)
        {
            eVechilesTypes eVechileType;
            eEngineTypes eEngineType;
            
            if (!m_Garage.IsCustomerExist(i_LicensePlateNumber))
            {
                readCustomerData(i_LicensePlateNumber, out eVechileType, out eEngineType);
                readVechileData(i_LicensePlateNumber, eVechileType, eEngineType);
            }
            else
            {
                Console.WriteLine("This vechile is already registered. Now its status is updated to 'repairing'");
            }
        }

        private void readCustomerData(string i_LicensePlate, out eVechilesTypes o_VechileType, out eEngineTypes o_EngineType)
        {
            string customerName, customerPhoneNumber;
            int vechileTypeChoice;

            Console.WriteLine("Please enter your name");
            customerName = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter your phone number, note that a valid phone number is 9 or 10 digits long");
            customerPhoneNumber = Utilities.GetNumberAsString(9, 10);
            printVechileTypesMenu();
            vechileTypeChoice = Utilities.GetSingleNumInRange(1, 5);
            o_VechileType = Utilities.ConvertVechileTypeToEnum(out o_EngineType, vechileTypeChoice);
            m_Garage.AddNewCustomer(customerName, customerPhoneNumber, i_LicensePlate, o_VechileType, o_EngineType);
        }

        // The vechile's arguments transfferd to the GarageManager by string arrays.
        // In the head of the GrarageManager's file there is a documentation of what is sent in each array.
        private void readVechileData(string i_LicensePlate, eVechilesTypes i_VechilesType, eEngineTypes i_EngineType)
        {
            string modelName;
            object[] engineArguments = null, wheelsArguments = null, vechileSpecificArguments = null;
            
            try
            {
                Console.WriteLine("Please enter the vechile's model name");
                modelName = Utilities.GetAlphabeticString();
                wheelsArguments = readWheelsData();
                vechileSpecificArguments = Utilities.GetEngineAndVechileSpecificData(i_VechilesType, i_EngineType, ref engineArguments);
                m_Garage.SetVechileDataToCustomer(i_LicensePlate, modelName, vechileSpecificArguments, wheelsArguments, engineArguments);
            }
            catch (Exception i_Exception)
            {
                m_Garage.RemoveCustomerByLicensePlate(i_LicensePlate);
                throw i_Exception;
            }
        }

        private object[] readWheelsData()
        {
            object[] wheelsArguments = new object[2];

            Console.WriteLine("Please enter the wheels manufacturer name");
            wheelsArguments[0] = Utilities.GetAlphabeticString();
            Console.WriteLine("Please enter the wheels current air pressure");
            wheelsArguments[1] = Utilities.GetFloatNumber();
            return wheelsArguments;
        }

        // Option #2 methods:
        private void printVechilesLicensePlates()
        {
            bool v_IsFilter;
            eVechileState? filterChoice;
            List<string> licensePlates;
            int i = 1;

            Console.WriteLine("Please select the wanted filtering status by typing its number, or type 0 to show all license plates");
            printVechileStatuses();
            filterChoice = getFilteringStatus(out v_IsFilter);
            licensePlates = m_Garage.GetVechilesLicensePlatesAsString(v_IsFilter, filterChoice);

            if (licensePlates.Count > 0)
            {
                Console.WriteLine("List of the matching license plates:");
                foreach (string licensePlate in licensePlates)
                {
                    Console.WriteLine($"{i}. {licensePlate}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No license plates found mathching this criteria");
            }

            Console.WriteLine();      
        }

        private eVechileState? getFilteringStatus(out bool o_IsFilter)
        {
            eVechileState? filterChoice = null;
            int userChoice;

            userChoice = Utilities.GetSingleNumInRange(0, 3);
            if (userChoice == 0)
            {
                o_IsFilter = false;
            }
            else
            {
                o_IsFilter = true;
                filterChoice = Utilities.ConvertVechileStatusToEnum(userChoice);
            }

            return filterChoice;
        }

        // Option #3 method:
        private void updateVechileState(string i_LicensePlate)
        {
            int userChoice;
            eVechileState newState;

            Console.WriteLine("Please select new status type for your vechile by typing its number");
            printVechileStatuses();
            userChoice = Utilities.GetSingleNumInRange(1, 3);
            newState = Utilities.ConvertVechileStatusToEnum(userChoice);
            m_Garage.UpdateVechileState(i_LicensePlate, newState);
            Console.WriteLine("Vechile's state has been updated.\n");
        }

        // Option #4 method:
        private void inflateAllWheelsToMax(string i_LicensePlate)
        {
            m_Garage.InflateAllWheelsToMax(i_LicensePlate);
           Console.WriteLine("The air pressure for each wheel is set to maximum\n");
        }

        // Option #5 method:
        private void refuelVechile(string i_LicensePlate)
        {
            float litersToFill;
            int userChoiceOfFuel;
            eFuelType fuelType;

            printFuelTypes();
            userChoiceOfFuel = Utilities.GetSingleNumInRange(1, 4);
            fuelType = Utilities.ConvertFuelTypeToEnum(userChoiceOfFuel);
            Console.WriteLine("Please type the amount of liters you would like to fill");
            litersToFill = Utilities.GetFloatNumber();
            m_Garage.RefuelVechile(i_LicensePlate, fuelType, litersToFill);
            Console.WriteLine("The tank has been filled with the amount requested\n");
        }

        // Option #6 method:
        private void chargeVechile(string i_LicensePlate)
        {
            int minutesToCharge;

            Console.WriteLine("Please type the amount of minutes you would like to charge (as integer)");
            minutesToCharge = int.Parse(Utilities.GetNumberAsString(1, 8));
            m_Garage.ChargeVechile(i_LicensePlate, minutesToCharge);
            Console.WriteLine("The battery has been charged with the amount of minutes requested\n");
        }

        // Option #7 method:
        private void printFullVechileData(string i_LicensePlateNumber)
        {
            string vechileDetails = null;

            vechileDetails = m_Garage.GetVechileDetailsAsString(i_LicensePlateNumber);
            Console.WriteLine("\nVechile's info:");
            Console.WriteLine(vechileDetails);
        }

        // General methods:
        private string getLicensePlateNumber(ref eMenuOptions io_Choice)
        {
            string licensePlate;

            Console.WriteLine("Please enter licencse plate number, note that a valid license plate number is 7 or 8 digits long");
            Console.WriteLine("If you want to get back to the main menu, press Q.");
            licensePlate = Utilities.GetNumberAsString(7, 8);
            if(licensePlate == "Q")
            {
                io_Choice = eMenuOptions.ExitToMenu;
            }

            return licensePlate;
        }

        private void printFuelTypes()
        {
            Console.WriteLine("Please select the fuel type by typing its number");
            Console.WriteLine("1 - Soler");
            Console.WriteLine("2 - Octan95");
            Console.WriteLine("3 - Octan96");
            Console.WriteLine("4 - Octan98");
        }

        private void printVechileTypesMenu()
        {
            Console.WriteLine("Please select the vechile type by typing its number");
            Console.WriteLine("1 - Fueled Car - Fuel type: Octan95 | Tank size: 46 liters | Wheels max air pressure: 33");
            Console.WriteLine("2 - Fueled Motorcycle - Fuel type: Octan98 | Tank size: 6.4 liters | Wheels max air pressure: 31");
            Console.WriteLine("3 - Fueled Truck - Fuel type: Soler | Tank size: 135 liters | Wheels max air pressure: 26");
            Console.WriteLine("4 - Electric Car - Battery size: 5.2 hours | Wheels max air pressure: 33");
            Console.WriteLine("5 - Electric Motorcycle - Battery size: 2.6 hours | Wheels max air pressure: 33");
        }

        private void printWelcomeMessage()
        {
            string welcomeMessage = @"
████████╗██╗  ██╗███████╗     ██████╗  █████╗ ██████╗  █████╗  ██████╗ ███████╗
╚══██╔══╝██║  ██║██╔════╝    ██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔════╝ ██╔════╝
   ██║   ███████║█████╗      ██║  ███╗███████║██████╔╝███████║██║  ███╗█████╗  
   ██║   ██╔══██║██╔══╝      ██║   ██║██╔══██║██╔══██╗██╔══██║██║   ██║██╔══╝  
   ██║   ██║  ██║███████╗    ╚██████╔╝██║  ██║██║  ██║██║  ██║╚██████╔╝███████╗
   ╚═╝   ╚═╝  ╚═╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                               ";
            Console.WriteLine(welcomeMessage);
        }

        private void printMenu()
        {
            Console.WriteLine("Please select the prefered option by typing its number");
            Console.WriteLine("1 - Put a vechile for repair in the garage");
            Console.WriteLine("2 - Print vechiles license plates");
            Console.WriteLine("3 - Update vechile state in garage");
            Console.WriteLine("4 - Inflate all wheels of a vechile to maximum");
            Console.WriteLine("5 - Refuel a vechile's tank");
            Console.WriteLine("6 - Charge a vechile's battery");
            Console.WriteLine("7 - Print vechile's full data");
            Console.WriteLine("8 - Exit");
        }

        private void printVechileStatuses()
        {
            Console.WriteLine("1 - Repairing");
            Console.WriteLine("2 - Repaired");
            Console.WriteLine("3 - Paid");
        }
    }
}
