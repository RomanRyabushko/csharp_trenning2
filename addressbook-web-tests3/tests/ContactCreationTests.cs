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
            app.Navigator.OpenContactPage();
            app.Navigator.GoToAddNew();
            ContactData contact = new ContactData("43", "43");
            contact.Middlename = "43";
            app.Contact
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.Navigator.LogOut();
        }     
  
    }
}