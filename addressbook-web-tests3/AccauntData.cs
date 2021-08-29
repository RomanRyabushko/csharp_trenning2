using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressBookTests
{
    class AccauntData
    {
        private string username;
        private string password;

        public AccauntData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}

   

