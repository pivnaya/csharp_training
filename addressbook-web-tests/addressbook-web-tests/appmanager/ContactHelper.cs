﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        internal ContactHelper Create()
        {
            InitContactCreation();
            FillContactForm(new ContactData("Vasya", "Pupkin"));
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public List<ContactData> GetContactsList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.FindElement(By.XPath("td[3]")).Text, element.FindElement(By.XPath("td[2]")).Text));
            }
            return contacts;
        }

        public ContactHelper RemoveFromContactPage(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            RemoveContact();
            return this;
        }

        public ContactHelper RemoveFromHomePage(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@value='Update'])")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }
    }
}
