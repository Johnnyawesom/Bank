
using System;
using System.Collections.Generic;
using System.Threading;

namespace Bank_1
{
    class Program
    {
        static List<Bank> Banks = new List<Bank>();
        //creating default Bank
        static Bank bank = new Bank("snydbank");

        static void Main(string[] args)
        {
            bool KeepRunning = true;
            do
            {
                int selectedMenuoption = ConsoleHelper.MultipleChoice(true, "Opret konto")
            }
        }
    }
}