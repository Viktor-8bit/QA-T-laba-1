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

            Tinkow.accounts = new List<Bank_account>()
            {
                new Bank_account(new User("Михаил", "Юрьевич", "Лермонтов"),        "5213 8765 3456 7890"),

                new Bank_account(new User("Сергей", "Сергеевич", "Есенин"),         "7895 6543 2109 8765"),

                new Bank_account(new User("Федор", "Иванович", "Тютчев"),           "1234 5678 9012 3456"),

                new Bank_account(new User("Владимир", "Владимирович", "Маяковский"),"2345 6789 0123 4567"),

                new Bank_account(new User("Анна", "Андреевна", "Ахматова"),         "3456 7890 1234 5678"),
            };


            Bank_account b1 = new Bank_account( new User("Амогус", "сус", "Импостер"), "2234 5678 9012 3456");

            b1.deposit_money(2000);

            Tinkow.accounts.Add(b1);

            var accaunt1 = Tinkow.get_account("2234 5678 9012 3456");

            print(accaunt1);

            var accaunt = Tinkow.get_account("2345 6789 0123 4567");
            print(accaunt);


            accaunt.deposit_money(900.90M);

            accaunt.cash_money(0.57M);

            print(accaunt);


        }
    }
}