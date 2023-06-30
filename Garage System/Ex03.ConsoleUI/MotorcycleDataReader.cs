using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class MotorcycleDataReader : DataReader
    {
        private const float k_MaxFuelTank = 6.4f;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
        private const float k_MaxBatteryVolume = 2.6f;

        private static eLicenseType ConvertLicenseTypeToEnum(int i_LicenseTypeChoice)
        {
            eLicenseType licenseType;
            switch (i_LicenseTypeChoice)
            {
                case 1:
                    licenseType = eLicenseType.A1;
                    break;
                case 2:
                    licenseType = eLicenseType.A2;
                    break;
                case 3:
                    licenseType = eLicenseType.AA;
                    break;
                default:
                    licenseType = eLicenseType.B1;
                    break;
            }

            return licenseType;
        }

        public override object[] GetSpecificData()
        {
            int licenseTypeChoice;
            object[] motorArguments = new object[2];

            printLicenseTypeMenu();
            licenseTypeChoice = Utilities.GetSingleNumInRange(1, 4);
            motorArguments[0] = ConvertLicenseTypeToEnum(licenseTypeChoice);
            Console.WriteLine("Please enter the volume capacity of the motor (in CC - Cubic Centimeters)");
            motorArguments[1] = Utilities.GetInteger();

            return motorArguments;
        }

        public override object[] GetEngineData(eEngineTypes i_EngineType)
        {
            object[] engineArguments = null;

            if (i_EngineType == eEngineTypes.Fuel)
            {
                engineArguments = createFuelDataArray(k_MotorcycleFuelType, k_MaxFuelTank);
            }
            else
            {
                engineArguments = createElectricDataArray(k_MaxBatteryVolume);
            }

            return engineArguments;
        }

        private void printLicenseTypeMenu()
        {
            Console.WriteLine("Please select your license type by typing its number");
            Console.WriteLine("1 - A1");
            Console.WriteLine("2 - A2");
            Console.WriteLine("3 - AA");
            Console.WriteLine("4 - B1");
        }
    }
}
