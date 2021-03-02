using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromContactPageTest()
        {
            app.Contacts.RemoveFromContactPage(1);
        }

        [Test]
        public void RemoveContactFromHomePageTest()
        {;
            app.Contacts.RemoveFromHomePage(1);
        }
    }
}

