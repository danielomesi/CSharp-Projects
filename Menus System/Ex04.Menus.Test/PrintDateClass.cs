using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintDateClass : IExecutable
    {
        public void printDate()
        {
            DateTime today = DateTime.Today;

            Console.WriteLine("The date today is: {0}{1}", today.ToShortDateString(), Environment.NewLine);
        }

        public void Execute()
        {
            printDate();
        }
    }
}