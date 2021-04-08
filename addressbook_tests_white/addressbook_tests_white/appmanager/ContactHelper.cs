using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.Finders;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();

            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            TableRows rows = table.Rows;
            foreach (TableRow row in rows)
            {
                list.Add(new ContactData()
                {
                    FirstName = row.Cells[0].Value.ToString(),
                    LastName = row.Cells[1].Value.ToString()
                });
            }
            return list;
        }

        public void Add(ContactData newContact)
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            Window dialog = manager.MainWindow.ModalWindow("Contact Editor");
            dialog.Get<TextBox>("ueFirstNameAddressTextBox").SetValue(newContact.FirstName);
            dialog.Get<TextBox>("ueLastNameAddressTextBox").SetValue(newContact.LastName);
            dialog.Get<Button>("uxSaveAddressButton").Click();
        }

        public void Remove(int index)
        {
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            table.Rows[index].Click();
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            manager.MainWindow.ModalWindow("Question").Get<Button>(SearchCriteria.ByText("Yes")).Click();
        }
    }
}
