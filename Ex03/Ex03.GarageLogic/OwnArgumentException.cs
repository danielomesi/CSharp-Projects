using System;

namespace Ex03.GarageLogic
{
    public class OwnArgumentException : ArgumentException
    {
        private string m_WrongArgument;

        public OwnArgumentException(string i_WorngArgument)
        {
            m_WrongArgument = i_WorngArgument;
        }

        public override string Message
        {
            get
            {
                return "Cannot execute this action to incompabaility of the " + m_WrongArgument + " with the procedure requested.";
            }
        }
    }
}
