
using NUnit.Framework;
using unit_test_laba_1;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {

        #region "����� ����������"

        #endregion

        #region "����� �������"

        #endregion


        #region "����� ������"

        #endregion

    }
}


//// ��������� ����� �� ������ �����
//[Test]
//public void GetAccount()
//{
//    Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
//    Assert.AreEqual(expected_bank, ba1);

//}

//// �������� ��������� - � ������������� ����� ������ ������� ������
//[Test]
//public void FreezeDepositMoney()
//{
//    // ������������ ����
//    Bank_account expected_bank = bank.get_account("3456 7890 1234 5678");
//    decimal excepted_balance = expected_bank.Balance;


//    Assert.AreEqual(expected_bank.deposit_money(900), operation_result.error);
//    Assert.AreEqual(expected_bank.cash_money(100), operation_result.error);

//    // � ������������� ����� ������ �� ��������
//    Assert.AreEqual(excepted_balance, expected_bank.Balance);
//}

//// �������� �� ��, ����� � ������� ������ � ���������� ����� �� ������ ������������� ��������
//[Test]
//public void MinusCashAndDeposit()
//{

//    Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
//    decimal excepted_balance = expected_bank.Balance;

//    Assert.AreEqual(expected_bank.cash_money(-900.85M), operation_result.error);
//    Assert.AreEqual(expected_bank.deposit_money(-54.34M), operation_result.error);
//    Assert.AreEqual(excepted_balance, expected_bank.Balance);

//}

//// �������� �� ������� ������ ������, ��� ���� �� �����
//[Test]
//public void CashMoreThanYouHave()
//{
//    Bank_account expected_bank = bank.get_account("6123 9876 5432 1012");
//    decimal excepted_balance = expected_bank.Balance;

//    Assert.AreEqual(expected_bank.cash_money(excepted_balance + 1000), operation_result.error);

//    Assert.AreEqual(excepted_balance, expected_bank.Balance);

//}