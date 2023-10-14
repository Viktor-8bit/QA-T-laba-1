using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public class Bank
    {

        public List<Bank_account> accounts { get; set; } = new List<Bank_account>();
        public Bank_account get_account(string account_number)
        {
            var account = accounts.First<Bank_account>(account => account.account_number == account_number);
            return account;
        }

        public Bank() 
        { 
        }
    }
}
