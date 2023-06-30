using System;

namespace Ex03.GarageLogic
{
    public class OwnFormatException : FormatException
    {
        public override string Message
        {
            get
            {
                return "Data received in the wrong format.";
            }
        }
    }
}
