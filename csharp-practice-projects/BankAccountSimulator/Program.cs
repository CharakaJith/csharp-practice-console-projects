﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankApp app = new BankApp();

            app.Start();
        }
    }
}
