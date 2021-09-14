using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.RemoveContact(1);
        }
    }
}
