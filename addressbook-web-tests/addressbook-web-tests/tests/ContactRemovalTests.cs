using NUnit.Framework;
using System.Collections.Generic;

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

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.RemoveFromContactPage(0);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void RemoveContactFromHomePageTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.RemoveFromHomePage(0);

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

