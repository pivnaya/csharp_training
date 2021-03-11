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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFromContactPage(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void RemoveContactFromHomePageTest()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFromHomePage(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}

