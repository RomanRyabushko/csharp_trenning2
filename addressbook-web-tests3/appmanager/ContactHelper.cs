using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase

    {
     
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {        
        }
               

        public ContactHelper CreateContact(ContactData contact) 
        {
            manager.Navigator.OpenContactPage();
            manager.Navigator.GoToAddNew();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper ModifyContact(int p, ContactData newData)
        {
            manager.Navigator.OpenContactPage();
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper RemoveContact(int c)
        {
            manager.Navigator.OpenContactPage();
            SelectContact(c);
            DeleteContact();
            AlertAccept();
            return this;
        }

        public ContactHelper AlertAccept()
        {
            Assert.IsTrue(Regex.IsMatch(driver.SwitchTo().Alert().Text, "^Delete 1 addresses[\\s\\S]$"));
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[3]/td[8]/a/img")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("middlename"), contact.Middlename);
            return this;
            
        }
        
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
    }
}
