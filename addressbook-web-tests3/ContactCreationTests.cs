﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccauntData("admin", "secret"));
            OpenContactPage();
            GoToAddNew();
            ContactData contact = new ContactData("43","43");
            contact.Middlename = "43";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            LogOut();
        }

        private void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        private void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        private void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
        }

        private void GoToAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private void OpenHomePage()
            {
                driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            }
        private void Login(AccauntData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }