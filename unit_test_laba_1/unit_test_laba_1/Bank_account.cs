using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public enum operation_result 
    {
        success,
        error,
    }

    public class Bank_account : IBank_account
    {

        protected bool is_freez { get; set; } = false;

        public bool IsFreez
        {
            get
            {
                return is_freez;
            }
        }

        public IUser User             { get; }
        
        public string account_number { get; }

        protected decimal balance    { get; set; }

        public decimal Balance { get { return balance; } }

        // формат банковского номера 5213 8765 3456 7890
        public Bank_account(IUser user, string accaunt_number)
        {
            Regex regex = new Regex("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}");
            var pattern = @"\b\d{4} \d{4} \d{4} \d{4}\b";

            if (Regex.IsMatch(accaunt_number, pattern) && accaunt_number.Length == 19)
            {
                this.account_number = accaunt_number;
                this.User = user;
            } else
            {
                throw new ArgumentException($"{nameof(accaunt_number)} неправильное значение номера"); 
            }
        }

        // накинуть деньги
        public operation_result deposit_money(decimal money)
        {

            if (this.is_freez == false && money > 0)
            {
                this.balance += money;
                return operation_result.success;
            }
            else
            {
                throw new InvalidOperationException($"{nameof(is_freez)} {nameof(money)} аневерные аргументы или счет заморожен");
            }
        }

        // обналичить деньги
        public operation_result cash_money(decimal cash)
        {
            if (cash < this.balance && this.is_freez == false && cash > 0)
            {
                this.balance -= cash;
                return operation_result.success;
            }
            else
            {
                throw new InvalidOperationException($"{nameof(is_freez)} {nameof(cash)} аневерные аргументы или счет заморожен");
            }
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
