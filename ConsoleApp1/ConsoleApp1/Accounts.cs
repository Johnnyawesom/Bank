using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_1
{
    public enum AccountType
    {
        checkingAccount,
        savingsAccount,
        consumerAccount
    }

    interface IAccount
    {
        public int ID { get; }
        public AccountType GetType { get; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public static int _accountCounter = 1;

        virtual void AddInterests() { }
    }

    class CheckingAccount : IAccount
    {
        int id;
        string name;
        double balance = 0;
        AccountType getType;

        // Constructor
        public CheckingAccount(string _name)
        {
            this.id = IAccount._accountCounter++;
            this.name = _name;
            this.getType = AccountType.checkingAccount;

            Logging.Log($"Created account: ID {this.id} - Account name: {this.name} - Account type: {this.getType}");
        }

        // properties
        public AccountType GetType { get { return getType; } }
        public int ID { get { return this.id; } }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Balance
        {
            get { return this.balance; }
            set
            {
                this.balance += value;
                Logging.Log($"Account: ID {this.id} - Account name: {this.name} - Balance changed from: {this.Balance - value} => {this.balance}");
            }
        }
        public void AddInterests()
        {

            this.balance *= 1.005;
        }
    }

    class SavingsAccount : IAccount
    {
        int id;
        string name;
        double balance = 0;
        AccountType getType;

        // Constructor
        public SavingsAccount(string _name)
        {
            this.id = IAccount._accountCounter++;
            this.name = _name;
            this.getType = AccountType.savingsAccount;

            Logging.Log($"Created account: ID {this.id} - Account name: {this.name} - Account type: {this.getType}");
        }

        // properties
        public AccountType GetType { get { return getType; } }
        public int ID { get { return this.id; } }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Balance
        {
            get { return this.balance; }
            set
            {
                this.balance += value;
                Logging.Log($"Account: ID {this.id} - Account name: {this.name} - Balance changed from: {this.Balance - value} => {this.balance}");
            }
        }
        public void AddInterests()
        {
            if (this.balance < 50000)
            {
                this.balance *= 1.01;
            }
            if (this.balance < 100000)
            {
                this.balance *= 1.02;
            }
            if (this.balance > 100000)
            {
                this.balance *= 1.03;
            }
        }
    }

    class ConsumerAccount : IAccount
    {
        int id;
        string name;
        double balance = 0;
        AccountType getType;

        // Constructor
        public ConsumerAccount(string _name)
        {
            this.id = IAccount._accountCounter++;
            this.name = _name;
            this.getType = AccountType.consumerAccount;

            Logging.Log($"Created account: ID {this.id} - Account name: {this.name} - Account type: {this.getType}");
        }

        // properties
        public AccountType GetType { get { return getType; } }
        public int ID { get { return this.id; } }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Balance
        {
            get { return this.balance; }
            set
            {
                this.balance += value;
                Logging.Log($"Account: ID {this.id} - Account name: {this.name} - Balance changed from: {this.Balance - value} => {this.balance}");
            }
        }
        public void AddInterests()
        {
            if (this.balance >= 0)
            {
                this.balance *= 1.005;
            }
            else
            {
                this.balance += (this.balance * -1.05);
            }
        }
    }
}
