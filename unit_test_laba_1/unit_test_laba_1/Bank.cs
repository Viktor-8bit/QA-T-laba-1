using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public class Bank
    {

        protected List<IBank_account> accounts { get; set; } = new List<IBank_account>();


        public void add_account(IBank_account account)
        {
            if (this.accounts.Count == 0)
            {
                this.accounts.Add(account);
            }
            else if ( this.get_account(account.account_number) is null )
            {
                this.accounts.Add(account);
            } 
            else
            {
                throw new ArgumentException($"{nameof(account)} уже существует аккаунт с таким банковским номером !!!!");
            }
        }

        public IBank_account? get_account(string account_number)
        {
            var account = accounts.FirstOrDefault<IBank_account>(account => account.account_number == account_number);

            if (account == null)
            {
                return account;
            }

            if (!account.account_number.Equals(account_number) )
            {
                throw new InvalidOperationException($"{nameof(account_number)} найден неверный элемент");
            }

            return account;
        }

        public Bank() 
        { 
        }
    }
}
