using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_1
{
    public enum AccountType
    {
        CheckingAccount,

        savingsAccount,

        consumerAccount
    }



    interface IAccount
    {
        public int ID { get; }

        public AccountType GetType { get; }

        public string Name { get; set; }

        public double Balance { get; set; }

        virtual void AddInterests() { }
    }

    class CheckingAccount : IAccount
    {
        int id;
        string name;

    }
}
