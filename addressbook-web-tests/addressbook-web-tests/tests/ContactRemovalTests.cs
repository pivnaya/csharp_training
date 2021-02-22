using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void RemoveContactFromContactPageTest()
        {
            app.Contacts.RemoveFromContactPage(1);
        }

        [Test]
        public void RemoveContactFromHomePageTest()
        {
            app.Contacts.RemoveFromHomePage(1);
        }
    }
}

