using System;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler, Octan95, Octan96, Octan98
    }

    internal class Fuel : Engine
    {
        private eFuelType m_FuelType;
        private float m_VolumeStatusInLiters;
        private float m_MaxVolumeInLiters;

        public float VolumeStatusInLiters
        {
            get
            {
                return m_VolumeStatusInLiters;
            }
        }

        public float MaxVolumeInLiters
        {
            get
            {
                return m_MaxVolumeInLiters;
            }
        }

        public override void SetEngineData(object[] i_Arguments)
        {
            m_FuelType = (eFuelType)i_Arguments[0];
            m_MaxVolumeInLiters = (float)i_Arguments[1];
            m_VolumeStatusInLiters = (float)i_Arguments[2];
        }

        public void Refuel(eFuelType i_FuelType, float i_AmountToFill)
        {
            float sumOfFuels;
            float maxCurrentAmountToFill = m_MaxVolumeInLiters - m_VolumeStatusInLiters;

           if (i_FuelType != m_FuelType)
            {
                throw new OwnArgumentException("fuel type");
            }

            sumOfFuels = i_AmountToFill + m_VolumeStatusInLiters;
            if (sumOfFuels > m_MaxVolumeInLiters)
            {
                throw new ValueOutOfRangeException(0, maxCurrentAmountToFill);
            }

            m_VolumeStatusInLiters = sumOfFuels;
        }

        public override string getEngineDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Fuel type: {0}\nTank maximum capacity: {1} liters\nCurrent fuel volume: {2} liters\n", m_FuelType.ToString(), m_MaxVolumeInLiters, m_VolumeStatusInLiters);

            return formattedStr;
        }

        public override float GetEngineCapacityStatus()
        {
            return ((m_VolumeStatusInLiters / m_MaxVolumeInLiters) * 100.0f);
        }
    }
}
