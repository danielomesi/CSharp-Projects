using System;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A1, A2, AA, B1
    }

    internal class Motorcycle : Vechile
    {
        // Const Members:
        private const float k_MaxAirPressure = 31;
        private const int k_NumOfWheels = 2;

        // Data Members:
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public override void UpdateSpecificData(object[] i_Arguments, object[] i_WheelArguments, object[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData((string)i_WheelArguments[0], (float)i_WheelArguments[1], k_MaxAirPressure);
            m_LicenseType = (eLicenseType)i_Arguments[0];
            m_EngineVolume = (int)i_Arguments[1];
            m_Engine.SetEngineData(i_EngineArguments);
        }

        public override string getSpecificVechileDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("License Type: {0}\nEngine Volume: {1} cc\n", m_LicenseType.ToString(), m_EngineVolume);

            return formattedStr;
        }
    }
}
