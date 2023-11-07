using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_test_laba_1
{
    public class User : IUser
    {

        public string first_name { get; private set; }
        public string patronymic { get; private set; }
        public string last_name { get; private set; }

        public User(string name, string patronymic, string last_name) { 
                if (name.Equals("") || patronymic.Equals(""))
                {
                    throw new ArgumentException($"{nameof(name)} {nameof(patronymic)} ошибка обязательных полей для заполнения");
                }
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
