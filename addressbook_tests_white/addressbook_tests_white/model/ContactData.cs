using System;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(ContactData other)
        {
            int result = LastName.CompareTo(other.LastName);

            if (result != 0)
            {
                return result;
            }

            return FirstName.CompareTo(other.FirstName);
        }

        public bool Equals(ContactData other)
        {
            return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName);
        }
    }
}
