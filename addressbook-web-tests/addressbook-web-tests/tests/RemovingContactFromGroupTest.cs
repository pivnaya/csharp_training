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
            GroupData group = GroupData.GetAll()[0];
            
            if (group.GetContacts().Count == 0)
            {
                app.Contacts.AddContactToGroup(ContactData.GetAll()[0], group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData toBeRemoved = oldList.First();

            app.Contacts.RemoveContactFromGroup(toBeRemoved, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

            foreach (ContactData contact in newList)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
