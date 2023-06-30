using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class SubMenuItem : MenuItem
    {
        private List<MenuItem> m_MenuItems;

        public SubMenuItem(string i_ItemName) : base(i_ItemName)
        {
            m_MenuItems = new List<MenuItem>();
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return m_MenuItems;
            }

            set
            {
                m_MenuItems = value;
            }
        }

        public void ShowMenu()
        {
            int index = 1;
            foreach (MenuItem menuItem in m_MenuItems)
            {
                Console.WriteLine("{0} --> {1}", index, menuItem.Name);
                index++;
            }
        }

        public void AddItemToMenu(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
        }

        public void RemoveItemFromMenu(MenuItem i_MenuItem)
        {
            m_MenuItems.Remove(i_MenuItem);
        }
    }
}
