using bank_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_1
{
    interface IBank
    {
        public static int _bankcounter = 1;
    }

    class Bank : IBank
    {
        int id;
        string name;
        List<IAccount> accountList = new List<IAccount>();

        // Constructor
        public Bank(string _bankName)
        {
            this.id = IBank._bankcounter++; ;
            this.name = _bankName;

        }

        // Properties
        public string Name {
            get { return this.id; }
            get { this.name = value; }
        }
        public int ID { get { return this.id } }

        //Methodes
        public IAccount CreateAccount(string name, AccountType accountType)
        {
            IAccount newAccount;
            switch (accountType)
            {
                case AccountType.CheckingAccount(name);
                    this.accountList.Add(newAccount);
                    return newAccount;
                case AccountType.savingsAccount:
                    this.accountList.Add(newAccount);
                    return newAccount;
                case AccountType.consumerAccount:
                    this.accountList.Add(newAccount);
                    return newAccount;
                default
                    return null;
            }
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

    //TODO: Implement Checks when deposet
    public bool Withdraw 

}
