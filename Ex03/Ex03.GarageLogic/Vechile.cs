using System;

namespace Ex03.GarageLogic
{
    internal abstract class Vechile 
    {
        // Data Members:
        protected string m_ModelName;
        protected string m_LicensePlateNumber;
        protected float m_CapacityStatus;
        protected Wheel[] m_Wheels;
        protected Engine m_Engine;

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public string LicensePlateNumber 
        {
            get
            {
                return m_LicensePlateNumber;
            }

            set
            {
                m_LicensePlateNumber = value;
            }
        }

        public float CapacityStatus
        {
            get
            {
                 return m_CapacityStatus;
            }

            set
            {
                m_CapacityStatus = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                m_Engine = value;
            }
        }

        public void UpdateBasicData(string i_ModelName, float i_CapacityStatus)
        {
            m_ModelName = i_ModelName;
            m_CapacityStatus = i_CapacityStatus;
        }

        protected void setWheelsData(string i_ManufacturerName, float i_CurrentWheelPressure, float i_MaximumWheelPressure)
        {
            if(i_CurrentWheelPressure > i_MaximumWheelPressure)
            {
                throw new OwnArgumentException("wheel pressure");
            }

            for(int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i] = new Wheel();
                m_Wheels[i].ManufacturerName = i_ManufacturerName;
                m_Wheels[i].MaximumPressure = i_MaximumWheelPressure;
                m_Wheels[i].PressureStatus = i_CurrentWheelPressure;
            }
        }

        public string getBasicVechileDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("License plate number: {0}\nModel: {1}\n" + "Capacity Status: {2}%\n", m_LicensePlateNumber, m_ModelName, m_CapacityStatus.ToString("F2"));

            return formattedStr;
        }

        // Abstrac Methods:
        public abstract void UpdateSpecificData(object[] i_Arguments, object[] i_WheelArguments, object[] i_EngineArguments);

        public abstract string getSpecificVechileDetailsAsString();
    }
}
