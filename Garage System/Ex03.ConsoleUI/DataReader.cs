using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public abstract class DataReader
    {
        public abstract object[] GetSpecificData();

        public abstract object[] GetEngineData(eEngineTypes i_EngineType);

        protected object[] createFuelDataArray(eFuelType i_FuelType, float i_MaxFuelTank)
        {
            object[] engineArguments = new object[3];
            float currentTankVolume;

            engineArguments[0] = i_FuelType;
            engineArguments[1] = i_MaxFuelTank;
            Console.WriteLine("Please enter the current fuel status in liters");
            currentTankVolume = Utilities.GetFloatNumber();
            engineArguments[2] = currentTankVolume;
            return engineArguments;
        }

        protected object[] createElectricDataArray(float i_MaxBatteryVolume)
        {
            object[] engineArguments = new object[2];
            float currentBatteryHours;

            engineArguments[0] = i_MaxBatteryVolume;
            Console.WriteLine("Pleas enter the amount of hours left in the battery");
            currentBatteryHours = Utilities.GetFloatNumber();
            engineArguments[1] = currentBatteryHours;
            return engineArguments;
        }
    }
}
