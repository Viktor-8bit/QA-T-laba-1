using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;


namespace unit_test_laba_1
{


    [TestFixture]
    public class bank_test
    {

        private Bank bank = new Bank();
        Bank_account ba1;


        [SetUp]
        protected void SetUp()
        {
            // задаем данные для тестирования 
            this.bank.accounts = new List<Bank_account>();
            this.ba1 = new Bank_account(new User("Александр", "Александрович", "Пушкин"), "6123 9876 5432 1012");
 
            // кладем 1000.05 денег на счет 6123 9876 5432 1012
            ba1.deposit_money(1000.05M);
            bank.accounts.Add(ba1);

            var bank_account_freeze = new Bank_account(new User("Анна", "Андреевна", "Ахматова"), "3456 7890 1234 5678");

            // кладем 500.91 денег на счет 3456 7890 1234 5678
            bank_account_freeze.deposit_money(500.91M);
            bank_account_freeze.freeze_bank_account();

            bank.accounts.Add(bank_account_freeze);


        }

        // Тестируем поиск по номеру карты
        [Test]
        public void GetAccount()
        {
            Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
            Assert.AreEqual(expected_bank, ba1);

        }

        // Проверка состояния - с замороженного счета нельзя снимать деньги
        [Test]
        public void FreezeDepositMoney()
        {
            // замороженный счет
            Bank_account expected_bank = bank.get_account("3456 7890 1234 5678");
            decimal excepted_balance = expected_bank.Balance;
            
            expected_bank.cash_money(100);
            expected_bank.deposit_money(900);

            Assert.AreEqual(expected_bank.deposit_money(900), operation_result.error);
            Assert.AreEqual(expected_bank.cash_money(100), operation_result.error);

            // у замороженного счета баланс не меняется
            Assert.AreEqual(excepted_balance, expected_bank.Balance);
        }

        // проверка на то, чтобы в функцию снятия и добавления денег не попали отрицательные значения
        [Test]
        public void MinusCashAndDeposit() 
        {

            Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
            decimal excepted_balance = expected_bank.Balance;

            Assert.AreEqual(expected_bank.cash_money(-900.85M), operation_result.error);
            Assert.AreEqual(expected_bank.deposit_money(-54.34M), operation_result.error);
            Assert.AreEqual(excepted_balance, expected_bank.Balance);

        }

        // проверка на попытку снятия больше, чем есть на счету
        [Test]
        public void CashMoreThanYouHave()
        {
            Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
            decimal excepted_balance = expected_bank.Balance;

            Assert.AreEqual(expected_bank.cash_money(excepted_balance + 1000), operation_result.error);

            Assert.AreEqual(excepted_balance, expected_bank.Balance);

        }


    }
}
