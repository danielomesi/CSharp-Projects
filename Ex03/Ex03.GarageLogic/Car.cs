using System;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        White, Black, Yellow, Red
    }

    internal class Car : Vechile
    {
        // Const Members:
        private const float k_MaxAirPressure = 33;
        private const int k_NumOfWheels = 5;

        // Data Members:
        private eColor m_Color;
        private int m_NumOfDoors;

        public override void UpdateSpecificData(object[] i_Arguments, object[] i_WheelArguments, object[] i_EngineArguments)
        {
            m_Wheels = new Wheel[k_NumOfWheels];
            setWheelsData((string)i_WheelArguments[0], (float) i_WheelArguments[1], k_MaxAirPressure);
            m_Color = (eColor)i_Arguments[0];
            m_NumOfDoors = (int)i_Arguments[1];
            m_Engine.SetEngineData(i_EngineArguments);
        }

        public override string getSpecificVechileDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Car Color: {0}\nNum of Doors: {1}\n", m_Color.ToString(), m_NumOfDoors);

            return formattedStr;
        }
    }
}
