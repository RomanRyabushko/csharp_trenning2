using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredantials()
        {
           // prepare
            app.Auth.Logout();
            // action
            AccauntData account = new AccauntData("admin", "secret");
            app.Auth.Login(account);
            // verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]

        public void LoginWithInvalidCredantials()
        {
            // prepare
            app.Auth.Logout();

            // action
            AccauntData account = new AccauntData("admin", "123456");
            app.Auth.Login(account);
            // verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
