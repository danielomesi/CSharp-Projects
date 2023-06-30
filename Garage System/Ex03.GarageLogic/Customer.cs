using System;

namespace Ex03.GarageLogic
{
    public enum eVechileState
    {
        Repairing, Repaired, Paid
    }

    internal class Customer
    {
        // Data Members:
        private readonly string m_NameOfOwner;
        private readonly string m_PhoneNumberOfOwner;
        private eVechileState m_VechileState;
        private Vechile m_Vechile = null;

        public Customer(string i_Name, string i_PhoneNumber)
        {
            m_NameOfOwner = i_Name;
            m_PhoneNumberOfOwner = i_PhoneNumber;
            VechileState = eVechileState.Repairing;
        }

        internal string NameOfOwner
        {
            get
            {
                return m_NameOfOwner;
            }
        }

        internal Vechile Vechile
        {
            get
            {
                return m_Vechile;
            }

            set
            {
                m_Vechile = value;
            }
        }

        internal eVechileState VechileState
        {
            get
            {
                return m_VechileState;
            }

            set
            {
                m_VechileState = value;
            }
        }
    }
}
