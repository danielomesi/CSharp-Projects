using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintTimeClass : IExecutable
    {
        public void printTime()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("The hour is: {0}{1}", today.ToShortTimeString(), Environment.NewLine);
        }

        public void Execute()
        {
            printTime();
        }
    }
}