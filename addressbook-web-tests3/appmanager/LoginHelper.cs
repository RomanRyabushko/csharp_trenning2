using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void Login(AccauntData account)
        {
            if (IsLoggedIn()) 
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();

            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
            
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool IsLoggedIn(AccauntData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }

    }
}
