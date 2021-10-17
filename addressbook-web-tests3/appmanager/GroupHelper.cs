using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase

    {
     
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            RetutnToGrpoupsPage();
            return this;

        }

        
        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            RetutnToGrpoupsPage();
            return this;
           
        }

        

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupsCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            RetutnToGrpoupsPage();
            return this;
        }

        private List<GroupData> groupCashe = null;

        
        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCashe.Add(new GroupData(element.Text){                   
                        Id = element.FindElement(By.TagName("input")).GetAttribute("valie")
                    });

                }

            }

            return new List<GroupData>(groupCashe);
        }
        public GroupHelper InitGroupsCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);                      
            return this;
        }
       
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            if (IsElementPresent(By.Name("selected[]")))
            {
                driver.FindElement(By.XPath("//div[@id='content']/form/span[ " + (index+1) + "]/input")).Click();
            }
            //InitGroupsCreation();
            //FillGroupForm(GroupData group);
            //SubmitGroupModification();



            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
            return this;
        }
        public GroupHelper RetutnToGrpoupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
