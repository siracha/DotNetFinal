using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeThomas_Final
{
    class Member : User
    {
        public string _email { get; set; }
        public Member(string name, string password) : base(name, password)
        {
            this._name = name;
            this._password = password;
        }
        public Member(string name, string password,string email): base(name,password)
        {
            this._name = name;
            this._password = password;
            this._email = email;
        }
    }
}
