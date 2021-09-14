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
    public class NavigationHelper : HelperBase
    {
         private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenContactPage()
        {
            if (driver.Url == baseURL + "/addressbook/" && IsElementPresent(By.Name("selected[]")))
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}

