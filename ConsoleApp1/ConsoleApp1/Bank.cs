using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_1
{
    interface IBank
    {
        public static int _bankCounter = 1;
    }

    class Bank : IBank
    {
        int id;
        string name;
        List<IAccount> accountList = new List<IAccount>();

        // Constructor
        public Bank(string _bankName)
        {
            this.id = IBank._bankCounter++; ;
            this.name = _bankName;
        }

        // Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int ID { get { return this.id; } }
        public List<IAccount> Accounts { get { return this.accountList; } }

        // Methodes
        public IAccount CreateAccount(string name, AccountType accountType)
        {
            IAccount newAccount;
            switch (accountType)
            {
                case AccountType.checkingAccount:
                    newAccount = new CheckingAccount(name);
                    this.accountList.Add(newAccount);
                    return newAccount;
                case AccountType.savingsAccount:
                    newAccount = new SavingsAccount(name);
                    this.accountList.Add(newAccount);
                    return newAccount;
                case AccountType.consumerAccount:
                    newAccount = new ConsumerAccount(name);
                    this.accountList.Add(newAccount);
                    return newAccount;
                default:
                    return null;
            }
        }

        public int AddInterests()
        {
            foreach (IAccount account in accountList)
            {
                account.AddInterests();
            }
            return accountList.Count;
        }

        // TODO: Implement checks when withdrawing
        public bool Withdraw(int _accountID, double _amount)
        {
            if (_amount <= accountList[_accountID].Balance)
            {
                accountList[_accountID].Balance = _amount * -1;
                return true;
            }
            else
                return false;

        }
        // TODO: Implement checks when deposeting
        public void Deposit(int _accountID, double _amount)
        {
            accountList[_accountID].Balance = _amount;
        }
    }
}
