using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10)));
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, "contacts.xml");
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(fileName));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, "contacts.json");
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(fileName));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

