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
    public class UserTests
    {

        #region "Тесты Алексея Ткачева"

        // проверка исключений
            [TestMethod()]
            public void user_constructor_throw()
            {
                Assert.ThrowsException<System.ArgumentException>(() => new User("", "", "Моракс") );
            }

        // стандартное поведение метода
            [TestMethod()]
            public void player_print()
            {
                User test_user = new User("Тарталья", "Чайльд", "Петрович");

                Assert.AreEqual(test_user.print(), "Тарталья Чайльд Петрович");
            }

        #endregion
    }
}