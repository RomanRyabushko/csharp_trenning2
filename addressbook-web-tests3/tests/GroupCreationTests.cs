using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("111");
            group.Header = "222";
            group.Footer = "333";

            
            app.Groups.Create(group);

            //app.Navigator.LogOut();
        }

        [Test]
        public void EmtyGroupCreationTest()
        {
            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            
            app.Groups.Create(group);

            //app.Navigator.LogOut();
        }
    }
}
