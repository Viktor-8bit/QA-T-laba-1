using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public enum operation_result 
    {
        success,
        error,
    }

    public class Bank_account : ICanPrint
    {

        protected bool is_freez { get; set; } = false;

        public bool IsFreez
        {
            get
            {
                return is_freez;
            }
        }

        public User User             { get; }
        
        public string account_number { get; }

        protected decimal balance    { get; set; }

        public decimal Balance { get { return balance; } }

        public Bank_account(User user, string accaunt_number)
        {
            this.account_number = accaunt_number;
            this.User = user;
        }

        // накинуть деньги
        public operation_result deposit_money(decimal money)
        {

            if (this.is_freez == false && money > 0)
            {
                this.balance += money;
                return operation_result.success;
            }

            return operation_result.error;
        }

        // обналичить деньги
        public operation_result cash_money(decimal cash)
        {
            if (cash < this.balance && this.is_freez == false && cash > 0)
            {
                this.balance -= cash;
                return operation_result.success;
            }

            return operation_result.error;
        }

        public void freeze_bank_account() 
        { 
            this.is_freez = true;
        }

        // вывод информации о счете
        public string print()
        {

            return $" user: {User.print()}; \n user_balance: {this.Balance}$; \n serial nuber: {this.account_number} ";
        }

    }
}
