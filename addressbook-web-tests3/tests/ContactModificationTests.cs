using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("55", "66");
            newData.Middlename = "77";

            app.Contacts.ModifyContact(1, newData);
        }
    }
}

