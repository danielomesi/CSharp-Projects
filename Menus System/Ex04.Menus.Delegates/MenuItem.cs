using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        protected readonly string r_Name;

        public MenuItem(string i_ItemName)
        {
            r_Name = i_ItemName;
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }
    }
}
