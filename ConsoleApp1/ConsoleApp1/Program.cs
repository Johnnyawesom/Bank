using Bank_1;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Bank_1
{
    class Program
    {
        static List<Bank> banks = new List<Bank>();
        // Creating default Bank
        static Bank bank = new Bank("SnydBank");

        static void Main(string[] args)
        {
            bool keepRunning = true;
            do
            {
                int selectedMenuOption = Helper.MultipleChoice(true, "Opret konto", "Indsæt beløb", "Hæv beløb", "Vis saldo", "Alle konti", "Vis status", "Tilskriv rente", "Afslut");

                switch (selectedMenuOption)
                {
                    case 0:
                        {
                            Console.WriteLine("----------Oprettelse af konto----------");
                            Console.Write("Indtast konto navn: ");
                            string inputAccountName = Console.ReadLine();
                            Console.Write("\n1. Løn Konto | 2. Kreditkonto | 3. Opsparingskonto\nØnsket kontotype: ");
                            string inputAccountType = Console.ReadLine();
                            switch (inputAccountType)
                            {
                                case "1":
                                    Console.WriteLine("Konto oprettet med kontonr.: " + bank.CreateAccount(inputAccountName, AccountType.checkingAccount).ID);
                                    break;
                                case "2":
                                    Console.WriteLine("Konto oprettet med kontonr.: " + bank.CreateAccount(inputAccountName, AccountType.savingsAccount).ID);
                                    break;
                                case "3":
                                    Console.WriteLine("Konto oprettet med kontonr.: " + bank.CreateAccount(inputAccountName, AccountType.consumerAccount).ID);
                                    break;
                                default:
                                    Console.WriteLine("Denne kontotype findes ikke!!!");
                                    break;
                            }
                            PressEnter();
                            break;
                        }
                    case 1:
                        {
                            WithdrawDepositMenu("deposit");
                            break;
                        }
                    case 2:
                        {
                            WithdrawDepositMenu("withdraw");
                            break;
                        }
                    case 3:
                        {
                            int accountID, accountUserInput;
                            bool accountExist = true;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("----------Vis Saldo----------");
                                Console.Write("Indtast kontonr.: ");
                                while (!int.TryParse(Console.ReadLine(), out accountUserInput))
                                {
                                    Console.WriteLine("Indtast venligst et tal!!!");
                                    Console.Write("Indtast kontonr.: ");
                                    Logging.Error("Show balance: Please Enter a valid numerical value!");
                                }
                                accountID = bank.Accounts.FindIndex(a => a.ID == accountUserInput);
                                accountExist = accountID == -1 ? true : false;
                                if (accountExist)
                                {
                                    Console.WriteLine("Denne konto findes ikke!!!");
                                    PressEnter();
                                }
                            } while (accountExist);
                            IAccount bankAccount = bank.Accounts[accountID];
                            Console.WriteLine($"Nuværende saldo for (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}: " + bankAccount.Balance);
                            PressEnter();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("----------Alle konti----------");
                            for (int i = 0; i < bank.Accounts.Count; i++)
                                Console.WriteLine($"Kontonr.: {bank.Accounts[i].ID} - Konto navn: {bank.Accounts[i].Name} - Kontotype: {bank.Accounts[i].GetType} - Saldo: {bank.Accounts[i].Balance}");
                            PressEnter();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine($"----------Nuværende status for bank: {bank.Name}----------");
                            double totalSum = 0;
                            for (int i = 0; i < bank.Accounts.Count; i++)
                            {
                                totalSum += bank.Accounts[i].Balance;
                            }
                            Console.WriteLine($"Bankens totale saldo: {totalSum}");
                            PressEnter();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine($"Tilskrevet renter til: {bank.AddInterests()} Konti");
                            break;
                        }
                    case 7:
                        {
                            keepRunning = false;
                            break;
                        }
                    case -1:
                        {
                            keepRunning = false;
                            break;
                        }
                    default:
                        break;
                }
            } while (keepRunning);
        }

        public static void WithdrawDepositMenu(string funcType)
        {
            int accountID, accountUserInput;
            bool accountExist = true;
            do
            {
                Console.Clear();
                Console.WriteLine("----------" + funcType == "withdraw" ? "Hæv" : "Indsæt" + " beløb på konto----------");
                Console.Write("Indtast kontonr.: ");
                while (!int.TryParse(Console.ReadLine(), out accountUserInput))
                {
                    Console.WriteLine("Indtast venligst et tal!!!");
                    Console.Write("Indtast kontonr.: ");
                    Logging.Error("Withdraw / Deposit: Please Enter a valid numerical value!");
                }
                accountID = bank.Accounts.FindIndex(a => a.ID == accountUserInput);
                accountExist = accountID == -1 ? true : false;
                if (accountExist)
                {
                    Console.WriteLine("Denne konto findes ikke!!!");
                    PressEnter();
                }
            } while (accountExist);

            IAccount bankAccount = bank.Accounts[accountID];
            Console.WriteLine("Nuværende saldo: " + bankAccount.Balance);
            if (funcType == "withdraw")
                Console.Write($"Indtast ønsket beløb du ønsker at Hæve på (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}: ");
            else if (funcType == "deposit")
                Console.Write($"Indtast ønsket beløb du ønsker at Indsætte på (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}: ");
            double amount;
            while (!Double.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.Write("Indstast venligst et positivt tal!: ");
                Logging.Error("Withdraw / Deposit: Please Enter a valid possitive numerical value!");
            }

            if (funcType == "withdraw")
                if (bank.Withdraw(accountID, amount))
                    Console.WriteLine($"Beløb: {amount} Hævet på (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}\nNy saldo: {bankAccount.Balance}");
                else
                    Console.WriteLine($"Kan ikke hæve beløb på (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}\nMed saldo: {bankAccount.Balance}");
            else if (funcType == "deposit")
            {
                bank.Deposit(accountID, amount);
                Console.WriteLine($"Beløb: {amount} Indsat på (kontonr.: {bankAccount.ID}) konto: {bankAccount.Name}\nNy saldo: {bankAccount.Balance}");
            }
            PressEnter();
        }
        public static void PressEnter()
        {
            Console.Write("Tryk enter for at forsaette...");
            Console.ReadKey();
        }

    }
}
