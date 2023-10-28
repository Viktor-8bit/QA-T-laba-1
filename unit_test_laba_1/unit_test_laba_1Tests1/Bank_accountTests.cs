using Microsoft.VisualStudio.TestTools.UnitTesting;
using unit_test_laba_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1.Tests
{
    [TestClass()]
    public class Bank_accountTests
    {

        #region "тесты Кожевникова Ивана"

        // стандартное поведение конструктора Bank_account

            [TestMethod()]
            public void Bank_account_constructor()
            {
                Bank_account test_bank_account = new Bank_account(new User("Ли", "Цзи", ""), "4356 1345 8891 3456");
                Assert.IsNotNull(test_bank_account);
            }

        // иключение конструктора Bank_account

            [TestMethod()]
            public void Bank_account_constructor_throw()
            {
                Assert.ThrowsException<System.ArgumentException>(() => new Bank_account(new User("Ли", "Цзи", ""), "23423  3224332 4356 1345 8891 3456123") );
            }

        // стандартное поведение метода print

            [TestMethod()]
            public void printTest()
            {
                Bank_account test_bank_account = new Bank_account(new User("Зенон", "Элейский", ""), "4356 1345 8891 3456");

                Assert.AreEqual(" user: Зенон Элейский ; \n user_balance: 0$; \n serial nuber: 4356 1345 8891 3456 ", test_bank_account.print());
            }


        // стандартное поведение метода deposit_money

            [TestMethod()]
            public void deposit_moneyTest()
            {
                Bank_account test_account = new Bank_account(new User("Ньютон", "Лаэртович", ""), "4356 1345 5891 3456");
                test_account.deposit_money(350.0M);
                Assert.AreEqual(test_account.Balance, 350.0M);
            }

        // исключения метода 

            [TestMethod()]
            public void deposit_moneyTest_throw()
            {
                Bank_account test_account = new Bank_account(new User("Ньютон", "Лаэртович", ""), "4356 1345 5891 3456");

                test_account.deposit_money(350.0M);

                Assert.ThrowsException<System.InvalidOperationException>(() => test_account.deposit_money(-100M));

                test_account.freeze_bank_account();

                Assert.ThrowsException<System.InvalidOperationException>(() => test_account.deposit_money(100M));
            }

        // стандартное поведение метода  
            
            [TestMethod()]
            public void cash_moneyTest()
            {
                Bank_account test_account = new Bank_account(new User("Ньютон", "Лаэртович", ""), "4356 1345 5891 3456");

                test_account.deposit_money(350.0M);
                test_account.cash_money(150.67M);
                Assert.AreEqual(test_account.Balance, 199.33M);
            }

        // исключение метода

            [TestMethod()]
            public void cash_moneyTest_throw()
            {
                Bank_account test_account = new Bank_account(new User("Ньютон", "Лаэртович", ""), "4356 1345 5891 3456");

                test_account.deposit_money(350.0M);
                test_account.cash_money(150.67M);

                Assert.ThrowsException<System.InvalidOperationException>(() => test_account.cash_money(-100M));
                test_account.freeze_bank_account();
                Assert.ThrowsException<System.InvalidOperationException>(() => test_account.deposit_money(100M));
            }

        // стандартное поведение при заморозке счета 

            [TestMethod()]
            public void freeze_bank_accountTest()
            {

                Bank_account test_account = new Bank_account(new User("Ньютон", "Лаэртович", ""), "4356 1345 5891 3456");

                test_account.deposit_money(350.0M);
                test_account.cash_money(150.67M);

                test_account.freeze_bank_account();
                
                // проглатываем исключение так-как снимать и класть на замороженный счет нельзя
                try
                {
                    test_account.deposit_money(350.0M);
                    test_account.cash_money(150.67M);
                } catch { }
                
                Assert.AreEqual(test_account.Balance, 199.33M);
                Assert.AreEqual(test_account.Balance, 199.33M);

            }




        #endregion
    }
}