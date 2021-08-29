using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccauntData("admin","secret"));
            GoToGroupsPage();
            InitGroupsCreation();
            GroupData group = new GroupData("111");
            group.Header = "222";
            group.Footer = "333";
            FillGroupForm(group);
            SubmitGroupCreation();
            RetutnToGrpoupsPage();
            LogOut();
        }
  
    }
}
