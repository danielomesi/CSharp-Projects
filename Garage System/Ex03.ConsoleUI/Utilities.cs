using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Utilities
    {
        public static int GetSingleNumInRange(int i_Start, int i_End)
        {
            string strNum = Console.ReadLine();
            int num;

            if (int.TryParse(strNum, out num))
            {
                if (!(num >= i_Start && num <= i_End))
                {
                    throw new ValueOutOfRangeException(i_Start, i_End);
                }
            }
            else
            {
                throw new OwnFormatException();
            }

            return num;
        }

        public static int GetInteger()
        {
            string strNum = Console.ReadLine();
            int num;

            if(!int.TryParse(strNum, out num))
            {
                throw new OwnFormatException();
            }

            return num;
        }

        public static string GetAlphabeticString()
        {
            string str = Console.ReadLine();
            bool v_isAlphaExist = false; //to make sure that a blank string won't be accepted

            foreach (char ch in str)
            {
                if ((ch != ' ') && !char.IsLetter(ch))
                {
                    throw new OwnFormatException();
                }
                else if (!v_isAlphaExist && char.IsLetter(ch))
                {
                    v_isAlphaExist = true;
                }
            }

            if (!v_isAlphaExist)
            {
                throw new OwnFormatException();
            }

            return str;
        }

        public static string GetNumberAsString(int i_MinNumOfDigits, int i_MaxNumOfDigits)
        {
            string strNumber = Console.ReadLine();
            int strLength = strNumber.Length;

            if(strNumber == "Q") // in order to quit and get back to the main menu.
            {
                return strNumber;
            }

            if (strLength >= i_MinNumOfDigits && strLength <= i_MaxNumOfDigits)
            {
                foreach (char ch in strNumber)
                {
                    if (!char.IsDigit(ch))
                    {
                        throw new OwnFormatException();
                    }
                }
            }
            else
            {
                throw new ValueOutOfRangeException(i_MinNumOfDigits, i_MaxNumOfDigits);
            }

            return strNumber;
        }

        public static eVechilesTypes ConvertVechileTypeToEnum(out eEngineTypes o_EngineType, int i_VechileChoice)
        {
            eVechilesTypes vechileType;

            switch (i_VechileChoice)
            {
                case 1:
                    vechileType = eVechilesTypes.Car;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 2:
                    vechileType = eVechilesTypes.Motorcycle;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 3:
                    vechileType = eVechilesTypes.Truck;
                    o_EngineType = eEngineTypes.Fuel;
                    break;
                case 4:
                    vechileType = eVechilesTypes.Car;
                    o_EngineType = eEngineTypes.Electric;
                    break;
                default:
                    vechileType = eVechilesTypes.Motorcycle;
                    o_EngineType = eEngineTypes.Electric;
                    break;
            }

            return vechileType;
        }

        public static eFuelType ConvertFuelTypeToEnum(int i_FuelTypeChoice)
        {
            eFuelType fuelType;

            switch (i_FuelTypeChoice)
            {
                case 1:
                    fuelType = eFuelType.Soler;
                    break;
                case 2:
                    fuelType = eFuelType.Octan95;
                    break;
                case 3:
                    fuelType = eFuelType.Octan96;
                    break;
                default:
                    fuelType = eFuelType.Octan98;
                    break;
            }

            return fuelType;
        }

        public static eVechileState ConvertVechileStatusToEnum(int i_VechileStateChoice)
        {
            eVechileState vechileState;

            switch (i_VechileStateChoice)
            {
                case 1:
                    vechileState = eVechileState.Repairing;
                    break;
                case 2:
                    vechileState = eVechileState.Repaired;
                    break;
                default:
                    vechileState = eVechileState.Paid;
                    break;
            }

            return vechileState;
        }

        public static float GetFloatNumber()
        {
            string strFloatNum = Console.ReadLine();
            float num;
           
            if (!float.TryParse(strFloatNum, out num))
            {
                throw new OwnFormatException();
            }

            return num;
        }

        // getting also engine detail in order to avoid another creation of DataReader.
        public static object[] GetEngineAndVechileSpecificData(eVechilesTypes i_VechileType, eEngineTypes i_EngineType, ref object[] io_EngineArgumnts)
        {
            DataReader readData;
            object[] specficArguments;

            switch(i_VechileType)
            {
                case eVechilesTypes.Car:
                    readData = new CarDataReader();
                    break;
                case eVechilesTypes.Motorcycle:
                    readData = new MotorcycleDataReader();
                    break;
                default:
                    readData = new TruckDataReader();
                    break;
            }

            io_EngineArgumnts = readData.GetEngineData(i_EngineType);
            specficArguments = readData.GetSpecificData();
            return specficArguments;
        }
    }
}
