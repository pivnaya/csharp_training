using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveContactFromContactPageTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create();
            }
            app.Contacts.RemoveFromContactPage(1);
        }

        [Test]
        public void RemoveContactFromHomePageTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create();
            }
            app.Contacts.RemoveFromHomePage(1);
        }
    }
}

