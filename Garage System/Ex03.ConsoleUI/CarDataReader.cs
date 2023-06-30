using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class CarDataReader : DataReader
    {
        private const float k_MaxFuelTank = 46;
        private const eFuelType k_CarFuelType = eFuelType.Octan95;
        private const float k_MaxBatteryVolume = 5.2f;

        private static eColor ConvertColorTypeToEnum(int i_ColorChoice)
        {
            eColor color;
            switch (i_ColorChoice)
            {
                case 1:
                    color = eColor.Red;
                    break;
                case 2:
                    color = eColor.Black;
                    break;
                case 3:
                    color = eColor.Yellow;
                    break;
                default:
                    color = eColor.White;
                    break;
            }

            return color;
        }

        public override object[] GetSpecificData()
        {
            int colorChoice, numOfDoors;
            object[] carArguments = new object[2];

            printColorMenu();
            colorChoice = Utilities.GetSingleNumInRange(1, 4);
            carArguments[0] = ConvertColorTypeToEnum(colorChoice);
            Console.WriteLine("Please enter the number of doors in your vechile (2,3,4 or 5)");
            numOfDoors = Utilities.GetSingleNumInRange(2, 5);
            carArguments[1] = numOfDoors;

            return carArguments;
        }

        public override object[] GetEngineData(eEngineTypes i_EngineType)
        {
            object[] engineArguments = null;

            if (i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = createFuelDataArray(k_CarFuelType, k_MaxFuelTank);
            }
            else
            {
                engineArguments = createElectricDataArray(k_MaxBatteryVolume);
            }

            return engineArguments;
        }

        private void printColorMenu()
        {
            Console.WriteLine("Please select the prefered option by typing its number");
            Console.WriteLine("1 - Red");
            Console.WriteLine("2 - Black");
            Console.WriteLine("3 - Yellow");
            Console.WriteLine("4 - White");
        }
    }
}
