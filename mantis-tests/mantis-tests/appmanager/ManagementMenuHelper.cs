using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void Manage()
        {
            driver.FindElement(By.XPath("//span[contains(text(), 'Управление')]")).Click();
        }

        public void ManageProject()
        {
            driver.FindElement(By.XPath("//a[contains(text(), 'Управление проектами')]")).Click();
        }

    }
}


