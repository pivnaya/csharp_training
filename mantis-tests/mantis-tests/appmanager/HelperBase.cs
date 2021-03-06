﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace mantis_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitElement(By by, int sec = 3)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(sec)).Until(drv => drv.FindElement(by));
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.0/mantisbt-2.25.0/login_page.php";
        }
    }
}