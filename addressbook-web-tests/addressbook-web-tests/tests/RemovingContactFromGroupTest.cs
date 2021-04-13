using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(new GroupData("testname"));
            }

            GroupData group = GroupData.GetAll()[0];
            
            if (group.GetContacts().Count == 0)
            {
                if (ContactData.GetAll().Count == 0)
                {
                    app.Contacts.Create(new ContactData("Petya", "Stepkin"));
                }
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
            }

            List<ContactData> oldGroupContactsList = group.GetContacts();
            ContactData contactToRemoved = oldGroupContactsList.First();

            app.Contacts.RemoveContactFromGroup(contactToRemoved, group);

            List<ContactData> newGroupContactsList = group.GetContacts();
            oldGroupContactsList.RemoveAt(0);
            newGroupContactsList.Sort();
            oldGroupContactsList.Sort();

            Assert.AreEqual(oldGroupContactsList, newGroupContactsList);

            foreach (ContactData contact in newGroupContactsList)
            {
                Assert.AreNotEqual(contact.Id, contactToRemoved.Id);
            }
        }
    }
}
