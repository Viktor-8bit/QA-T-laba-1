using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public interface IUser : ICanPrint
    {
        public string first_name { get; }
        public string patronymic { get; }
        public string last_name  { get; }
    }
}
