using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : MainMenu
    {
        private IExecutable m_Executable;

        public MenuItem(string i_Name) : base(i_Name)
        {
            m_Executable = null;
        }

        public IExecutable Executable
        {
            get
            {
                return m_Executable;
            }
        }

        // Set the executable only when the data member is null, so the executable won't be overwrite after first set.
        public void InitializeExecutable(IExecutable i_Executable)
        {
            if (!IsExecutable())
            {
                m_Executable = i_Executable;
            }
        }

        public bool IsExecutable()
        {
            bool v_IsExecutable = true;

            if (m_Executable == null)
            {
                v_IsExecutable = false;
            }

            return v_IsExecutable;
        }
    }
}
