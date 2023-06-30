using System;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        // Data Members:
        private string m_ManufacturerName;
        private float m_PressureStatus;
        private float m_MaximumPressure;

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float PressureStatus
        {
            get
            {
                return m_PressureStatus;
            }

            set
            {
                m_PressureStatus = value;
            }
        }

        public float MaximumPressure
        {
            get
            {
                return m_MaximumPressure;
            }

            set
            {
                m_MaximumPressure = value;
            }
        }

        public string getDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Wheel's Manufacturer Name: {0}\nWheel Pressure: {1}\n", m_ManufacturerName, m_PressureStatus);

            return formattedStr;
        }
    }
}
