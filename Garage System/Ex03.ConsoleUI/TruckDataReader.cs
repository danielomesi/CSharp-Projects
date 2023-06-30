using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class TruckDataReader : DataReader
    {
        private const float k_MaxFuelTank = 135;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        public override object[] GetSpecificData()
        {
            int isToxic;
            bool isToxicStr;
            object[] truckArguments = new object[2];

            Console.WriteLine("If the truck carries dangerous material, type 1, else - type 0");
            isToxic = Utilities.GetSingleNumInRange(0, 1);
            if (isToxic == 1)
            {
                isToxicStr = true;
            }
            else
            {
                isToxicStr = false;
            }

            truckArguments[0] = isToxicStr;
            Console.WriteLine("Please enter the cargo volume");
            truckArguments[1] = Utilities.GetFloatNumber();

            return truckArguments;
        }

        public override object[] GetEngineData(eEngineTypes i_EngineType)
        {
            object[] engineArguments = null;

            if (i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = createFuelDataArray(k_TruckFuelType, k_MaxFuelTank);
            }
            else
            {
                throw new OwnArgumentException("electric truck");
            }

            return engineArguments;
        }
    }
}
