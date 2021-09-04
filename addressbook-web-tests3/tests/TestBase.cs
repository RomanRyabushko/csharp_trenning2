using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace WebAddressBookTests
{
    public class TestBase
    {
        
        protected ApplicationManager app;


        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccauntData("admin", "secret"));
            
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }                 
                         
    }
}
