using System;

namespace Ex03.GarageLogic
{
    internal class Truck : Vechile
    {
        // Const Members:
        private const float k_MaxAirPressure = 26;
        private const int k_NumOfWheels = 14;

        // Data Members:
        private bool m_IsContainToxicMaterial;
        private float m_CargoVolume;

        public override void UpdateSpecificData(object[] i_Arguments, object[] i_WheelArguments, object[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData((string)i_WheelArguments[0], (float)i_WheelArguments[1], k_MaxAirPressure);
            m_IsContainToxicMaterial = (bool)i_Arguments[0];
            m_CargoVolume = (float)i_Arguments[1];
            m_Engine.SetEngineData(i_EngineArguments);
        }
        
        public override string getSpecificVechileDetailsAsString()
        {
            string formattedStr, isToxic;

            if (m_IsContainToxicMaterial)
            {
                isToxic = "Yes";
            }
            else
            {
                isToxic = "No";
            }

            formattedStr = string.Format("Does the truck contain toxic material: {0}\nCargo Volume: {1} cc\n", isToxic, m_CargoVolume);

            return formattedStr;
        }
    }
}
