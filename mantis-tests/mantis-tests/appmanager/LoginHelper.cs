using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void LoginByAdmin()
        {
            OpenMainPage();
            TypeUsername("administrator");
            TypePassword("root");
        }

        private void TypeUsername(string username)
        {
            driver.FindElement(By.Id("username")).SendKeys(username);
            Submit();
        }

        private void TypePassword(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            Submit();
        }

        private void Submit()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
    }
}
