using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void TestContactRemoval()
        {
            if (app.Contacts.GetContactList().Count == 0)
            {
                app.Contacts.Add(new ContactData()
                {
                    FirstName = "newFirstNameWhite",
                    LastName = "newLastNameWhite"
                });
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
