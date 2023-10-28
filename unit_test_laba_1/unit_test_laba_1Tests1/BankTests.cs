using Microsoft.VisualStudio.TestTools.UnitTesting;
using unit_test_laba_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace unit_test_laba_1.Tests
{
    [TestClass()]
    public class BankTests
    {
        #region "тесты Павела Потехина"

        // проверка исключений метода
            [TestMethod()]
            public void get_accountTest()
            {
                Bank test_bank = new Bank();
            
                test_bank.add_account(new Bank_account(new User("Джордж Смит", "Паттон", ""), "5213 8765 3456 7890"));
                
                Assert.ThrowsException<System.ArgumentException>(() => test_bank.add_account(new Bank_account(new User("Александр", "Васильевич", "Суворов"), "5213 8765 3456 7890")) );

            }

        // стандартное поведение метода
            [TestMethod()]
            public void get_accountTest_Throws()
            {
                Bank test_bank = new Bank();

                Bank_account test_bank_Account = new Bank_account(new User("Джордж Смит", "Паттон", ""), "5213 8765 3456 7890");

                test_bank.add_account(test_bank_Account);

                Bank_account? delta_bank_account = test_bank.get_account("5213 8765 3456 7890");

                Assert.AreEqual(test_bank_Account, delta_bank_account);

            }

        #endregion
    }
}