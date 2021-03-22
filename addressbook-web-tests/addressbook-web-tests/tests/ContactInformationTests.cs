using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [SetUp]
        public void TestSetUp()
        {
            if (!app.Contacts.IsContactPresent())
            {
                app.Contacts.Create(new ContactData("Petya", "Stepkin"));
            }
        }

        [Test]
        public void ContactInformationFromHomePageTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void ContactInformationFromDetailsPageTest()
        {
            string contactFromDetailsPage = app.Contacts.GetContactInformationFromDetails(0);
            ContactData contactFromEditForm = app.Contacts.GetContactInformationFromEditForm(0, needFullInfo: true);

            Assert.AreEqual(contactFromEditForm.FullInfo, contactFromDetailsPage);
        }
    }
}