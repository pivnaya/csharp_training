using NUnit.Framework;
using TechTalk.SpecFlow;
using WebAddressbookTests;

namespace addressbook_web_tests.bdd
{
    [Binding]
    public class LoginSteps
    {
        private ApplicationManager app
        {
            get { return ApplicationManager.GetInstance(); }
        }

        [Given(@"A user is logged out")]
        public void GivenAUserIsLoggedOut()
        {
            app.Auth.Logout();
        }

        [When(@"I login with username ""(.*)"" and password ""(.*)""")]
        public void WhenILoginWithValidCredentials(string username, string password)
        {
            AccountData account = new AccountData(username, password);
            ScenarioContext.Current.Add("account", account);
            app.Auth.Login(account);
        }

        [Then(@"I have logged in")]
        public void ThenIHaveLoggedIn()
        {
            AccountData account = ScenarioContext.Current.Get<AccountData>("account");
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Then(@"I have not logged in")]
        public void ThenIHaveNotLoggedIn()
        {
            AccountData account = ScenarioContext.Current.Get<AccountData>("account");
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
