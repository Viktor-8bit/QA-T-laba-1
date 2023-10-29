//using System.ComponentModel;
//using static System.Runtime.InteropServices.JavaScript.JSType;

using System.Runtime.Intrinsics.X86;

namespace unit_test_laba_1
{
    public class Program
    {

        static void print(object obj)
        {
            Console.WriteLine(obj.ToString());
            Console.WriteLine();
        }

        static void print(ICanPrint obj)
        {
            Console.WriteLine(obj.print());
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            Bank Tinkow = new Bank();

            Tinkow.add_account(new Bank_account(new User("Михаил", "Юрьевич", "Лермонтов"), "5213 8765 3456 7890"));
            Tinkow.add_account(new Bank_account(new User("Александр", "Васильевич", "Суворов"), "5213 8765 3456 7891"));

            var my_account = Tinkow.get_account("5213 8765 3456 7890");

            my_account.deposit_money(2000);
            my_account.deposit_money(234.40M);

            print(my_account);

            //for (decimal cash_money = 1M; cash_money < Decimal.MaxValue / 4.5M; cash_money *= 4.5M)
            //{
            //    Console.WriteLine(Decimal.MaxValue - cash_money);
            //}

        }
    }
}