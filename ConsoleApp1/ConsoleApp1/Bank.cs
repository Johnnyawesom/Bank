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

        public Bank(string _bankName)
        {
            this.id = IBank._bankcounter++; ;
            this.name = _bankName;
        
        }

    }
        

}
