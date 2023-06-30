using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        // Data Members:
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                return "The argument entered is out of the range " + m_MinValue + " to " + m_MaxValue + ".";
            }
        }
    }
}
