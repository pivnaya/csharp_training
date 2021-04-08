using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void TestContactCreation()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newContact = new ContactData()
            {
                FirstName = "newFirstNameWhite",
                LastName = "newLastNameWhite"
            };

            app.Contacts.Add(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
