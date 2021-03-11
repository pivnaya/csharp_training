using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create();

            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(new ContactData("Vasya", "Pupkin"));
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

