using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {


        [Test]
        public void ContactCreationTest()
        {
            
            ContactData contact = new ContactData("43", "43");
            contact.Middlename = "43";
   
            app.Contacts.CreateContact(contact);

            app.Navigator.LogOut();
        }     
  
    }
}