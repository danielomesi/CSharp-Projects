using System;

namespace Ex03.GarageLogic
{
    public enum eVechilesTypes
    {
        Car, Motorcycle, Truck
    }

    public enum eEngineTypes
    {
        Fuel, Electric
    }

    internal class VechileCreator
    {
        public static Vechile GetVechileByType(eVechilesTypes i_VechileType, string i_LicenseNumber, eEngineTypes i_EngineType)
        {
            Vechile vechile = null;
            switch (i_VechileType)
            {
                case eVechilesTypes.Car:
                    vechile = new Car();
                    break;
                case eVechilesTypes.Motorcycle:
                    vechile = new Motorcycle();
                    break;
                case eVechilesTypes.Truck:
                    vechile = new Truck();
                    break;
            }

            setEngineByType(vechile, i_EngineType);
            vechile.LicensePlateNumber = i_LicenseNumber;
            return vechile;
        }

        private static void setEngineByType(Vechile i_Vechile, eEngineTypes i_EngineType)
        {
            if(i_EngineType == eEngineTypes.Fuel)
            {
                i_Vechile.Engine = new Fuel();
            }
            else
            {
                i_Vechile.Engine = new Electric();
            }
        }
    }
}
