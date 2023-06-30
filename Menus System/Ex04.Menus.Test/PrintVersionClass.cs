using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class PrintVersionClass : IExecutable
    {
        public void printVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805{0}", Environment.NewLine);
        }

        public void Execute()
        {
            printVersion();
        }
    }
}