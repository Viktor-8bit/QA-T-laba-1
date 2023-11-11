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
            [DataRow("", "", "Семенов")]
            [DataRow("", "", "Артемов")]
            [DataRow("", "", "Алессев")]
            [DataRow("", "", "Сергеевич")]
            public void user_constructor_throw(string name, string patronymic, string last_name)
                {
                    Assert.ThrowsException<System.ArgumentException>(() => new User(name, patronymic, last_name) );
                }

        // стандартное поведение метода
            [TestMethod()]
            [DataRow("Алексей", "Кожевников", "")]
            [DataRow("Алекс", "Потехин", "Генадиевич")]
            [DataRow("Иван", "Ткачев", "Виталиевич")]
            [DataRow("Максим", "Конавалов", "Алексеевич")]
            public void player_print(string name, string patronymic, string last_name)
            {
                User test_user = new User(name, patronymic, last_name);

                Assert.AreEqual(test_user.print(), $"{name} {patronymic} {last_name}");;
            }

        #endregion
    }
}