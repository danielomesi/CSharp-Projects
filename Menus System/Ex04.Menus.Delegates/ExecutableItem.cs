using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class ExecutableItem : MenuItem
    {
        public event Action ItemClicked;

        public ExecutableItem(string i_ItemName) : base(i_ItemName)
        {
            ItemClicked = null;
        }

        public void OnClick()
        {
            if (ItemClicked != null)
            {
                ItemClicked.Invoke();
            }
        }
    }
}
