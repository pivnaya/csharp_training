using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Petya", "Stepkin");

            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create();
            }
            app.Contacts.Modify(1, newData);
        }
    }
}

