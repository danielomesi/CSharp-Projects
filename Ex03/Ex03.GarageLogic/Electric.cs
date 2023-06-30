using System;

namespace Ex03.GarageLogic
{
    internal class Electric : Engine
    {
        // Data Members:
        private float m_HoursLeftInBattery;
        private float m_MaxHoursInBattery;

        public float HoursLeftInBattery
        {
            get
            {
                return m_HoursLeftInBattery;
            }
        }

        public float MaxHoursInBattery
        {
            get
            {
                return m_MaxHoursInBattery;
            }
        }

        public override void SetEngineData(object[] i_Arguments)
        {
            m_MaxHoursInBattery = (float)i_Arguments[0];
            m_HoursLeftInBattery = (float)i_Arguments[1];
        }

        internal void ChargeBattery(float i_HoursToCharge)
        {
            float sumOfBatteryHours;
            float maxCurrentAmountToCharge = m_MaxHoursInBattery - m_HoursLeftInBattery;

            sumOfBatteryHours = i_HoursToCharge + m_HoursLeftInBattery;
            if (sumOfBatteryHours > m_MaxHoursInBattery)
            {
                throw new ValueOutOfRangeException(0, (maxCurrentAmountToCharge * 60.0f));
            }

            m_HoursLeftInBattery = sumOfBatteryHours;
        }

        public override string getEngineDetailsAsString()
        {
            string formattedStr;

            formattedStr = string.Format("Battery maximum capacity: {0} hours\nBattery Status: {1} hours left\n", m_MaxHoursInBattery, m_HoursLeftInBattery);

            return formattedStr;
        }

        public override float GetEngineCapacityStatus()
        {
            return ((m_HoursLeftInBattery / m_MaxHoursInBattery) * 100.0f);
        }
    }
}
