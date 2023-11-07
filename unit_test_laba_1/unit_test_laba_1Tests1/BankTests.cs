using Microsoft.VisualStudio.TestTools.UnitTesting;
using unit_test_laba_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

using Moq;

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


                var mock_bank_account_A = new Mock<IBank_account>();
                mock_bank_account_A.Setup(x => x.account_number).Returns("5213 8765 3456 7890");

                var mock_bank_account_B = new Mock<IBank_account>();
                mock_bank_account_B.Setup(x => x.account_number).Returns("5213 8765 3456 7890");

                test_bank.add_account(mock_bank_account_A.Object);
                
                Assert.ThrowsException<System.ArgumentException>(() => test_bank.add_account(mock_bank_account_B.Object));

            }

        // стандартное поведение метода
            [TestMethod()]
            public void get_accountTest_Throws()
            {
                Bank test_bank = new Bank();

                var mock_bank_account_A = new Mock<IBank_account>();
                mock_bank_account_A.Setup(x => x.account_number).Returns("5213 8765 3456 7890");

                test_bank.add_account(mock_bank_account_A.Object);

                IBank_account? delta_bank_account = test_bank.get_account("5213 8765 3456 7890");

                Assert.AreEqual(mock_bank_account_A.Object, delta_bank_account);

            }

        #endregion
    }
}