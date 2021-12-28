using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeThomas_Final
{
    public abstract class User
    {
        public int _userID { get; set; }
        public string _name { get; set; }
        public string _password { get; set; }
        public int _score { get; set; }
        public int _spec_score { get; set; }
        public DateTime _date { get; set; }
        public int _bad_guess { get; set; }
        public int _good_guess { get; set; }

        public User()
        {
            this._userID = 0;
            this._name = "guest";
            this._password = "guest";
            this._score = 0;
            this._spec_score = 0;
            this._bad_guess = 0;
            this._good_guess = 0;
            this._date = DateTime.Now;
        }
        public User(string name, string password)
        {
            this._name = name;
            this._password = password;
            this._score = 0;
            this._spec_score = 0;
            this._bad_guess = 0;
            this._good_guess = 0;
            this._date = DateTime.Now;
        }

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
