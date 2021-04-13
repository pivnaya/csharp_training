using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(new GroupData("testname"));
            }

            GroupData group = GroupData.GetAll()[0];

            List<ContactData> oldGroupContactsList = group.GetContacts();

            List<ContactData> notGroupContacts = group.GetExceptContacts();

            if (notGroupContacts.Count == 0)
            {
                 app.Contacts.Create(new ContactData("Petya", "Stepkin"));
            }
            ContactData contact = group.GetExceptContacts().First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newGroupContactsList = group.GetContacts();
            oldGroupContactsList.Add(contact);
            newGroupContactsList.Sort();
            oldGroupContactsList.Sort();

            Assert.AreEqual(oldGroupContactsList, newGroupContactsList);
        }
    }
}
