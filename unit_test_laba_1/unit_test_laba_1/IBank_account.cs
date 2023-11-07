using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public interface IBank_account : ICanPrint
    {
        
        string account_number { get; }

        decimal Balance { get; }

        operation_result deposit_money(decimal money);

        operation_result cash_money(decimal cash);
    }
}
