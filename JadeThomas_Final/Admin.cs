using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeThomas_Final
{
    class Admin : Member
    {
        public Admin(string name, string password, string email): base(name, password, email)
        {
            this._name = name;
            this._password = password;
            this._email = email;
        }
    }
}
