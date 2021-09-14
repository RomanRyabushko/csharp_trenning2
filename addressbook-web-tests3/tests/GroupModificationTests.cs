 using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }
    }
}
