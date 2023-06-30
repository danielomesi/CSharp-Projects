using System;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        public abstract void SetEngineData(object[] i_Arguments);

        public abstract float GetEngineCapacityStatus();

        public abstract string getEngineDetailsAsString();
    }
}
