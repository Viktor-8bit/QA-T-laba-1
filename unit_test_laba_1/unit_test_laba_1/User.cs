using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public class User : ICanPrint
    {

        protected string first_name;
        protected string patronymic;
        protected string last_name;

        public User(string name, string patronymic, string last_name) { 
            this.first_name = name;
            this.patronymic = patronymic;
            this.last_name = last_name;
        }

        public string print()
        {
            return $"{first_name} {patronymic} {last_name}";
        }


    }
}
