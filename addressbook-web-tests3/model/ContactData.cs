using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressBookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;
        private string middlename = "";

        public ContactData(string firstname , string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
    }

}
