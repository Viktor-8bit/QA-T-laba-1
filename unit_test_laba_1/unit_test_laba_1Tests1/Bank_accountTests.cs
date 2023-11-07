using Microsoft.VisualStudio.TestTools.UnitTesting;
using unit_test_laba_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

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
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_bank_account = new Bank_account(mock_user.Object, "4356 1345 8891 3456");
            Assert.IsNotNull(test_bank_account);
        }

        // иключение конструктора Bank_account

        [TestMethod()]
        public void Bank_account_constructor_throw()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ли Цзи ");

            Assert.ThrowsException<System.ArgumentException>(() => new Bank_account(mock_user.Object, "23423  3224332 4356 1345 8891 3456123"));
        }

        // стандартное поведение метода print

        [TestMethod()]
        public void printTest()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Зенон Элейский ");

            Bank_account test_bank_account = new Bank_account(mock_user.Object, "4356 1345 8891 3456"); // new User("Зенон", "Элейский", "")

            Assert.AreEqual(" user: Зенон Элейский ; \n user_balance: 0$; \n serial nuber: 4356 1345 8891 3456 ", test_bank_account.print());
        }

        // стандартное поведение метода deposit_money с использованием дипазона значений

        [TestMethod()]
        public void deposit_moneyTest()
        {
            for (decimal deposit_money = 1M; deposit_money < Decimal.MaxValue / 4.5M; deposit_money *= 4.5M)
            {
                DepositOneValue(deposit_money);
            }
        }
        private void DepositOneValue(decimal deposit_money)
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");
            test_account.deposit_money(deposit_money);
            Assert.AreEqual(test_account.Balance, deposit_money);
        }

        // стандартное поведение метода deposit_money

        [TestMethod()]
        public void deposit_moneyTest_2()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");
            test_account.deposit_money(350.0M);
            Assert.AreEqual(test_account.Balance, 350.0M);
        }

        // исключения метода 

        [TestMethod()]
        public void deposit_moneyTest_throw()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");

            test_account.deposit_money(350.0M);

            Assert.ThrowsException<System.InvalidOperationException>(() => test_account.deposit_money(-100M));

            test_account.freeze_bank_account();

            Assert.ThrowsException<System.InvalidOperationException>(() => test_account.deposit_money(100M));
        }

        // стандартное поведение метода с использованием дипазона значений

        [TestMethod()]
        public void cash_moneyTest()
        {
            for (decimal cash_money = 1M; cash_money < Decimal.MaxValue / 4.5M; cash_money *= 4.5M)
            {
                CashOneValue(cash_money);
            }
        }
        private void CashOneValue(decimal cash_money)
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");
            test_account.deposit_money(Decimal.MaxValue);
            test_account.cash_money(cash_money);
            Assert.AreEqual(test_account.Balance, Decimal.MaxValue - cash_money);
        }

        // стандартное поведение метода

        [TestMethod()]
        public void cash_moneyTest_2()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");

            test_account.deposit_money(350.0M);
            test_account.cash_money(150.67M);
            Assert.AreEqual(test_account.Balance, 199.33M);
        }


        // исключение метода

        [TestMethod()]
        public void cash_moneyTest_throw()
        {
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");

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
            var mock_user = new Mock<IUser>();
            mock_user.Setup(x => x.print()).Returns("Ньютон Лаэртович ");

            Bank_account test_account = new Bank_account(mock_user.Object, "4356 1345 5891 3456");

            test_account.deposit_money(350.0M);
            test_account.cash_money(150.67M);

            test_account.freeze_bank_account();

            // проглатываем исключение так-как снимать и класть на замороженный счет нельзя
            try
            {
                test_account.deposit_money(350.0M);
                test_account.cash_money(150.67M);
            }
            catch { }

            Assert.AreEqual(test_account.IsFreez, true);
            Assert.AreEqual(test_account.Balance, 199.33M);
            Assert.AreEqual(test_account.Balance, 199.33M);

        }

        #endregion
    }
}