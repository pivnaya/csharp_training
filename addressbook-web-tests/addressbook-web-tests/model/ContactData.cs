using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Id { get; set; }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return (Firstname + Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "firstName: " + Firstname + " lastName: " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            int result = Lastname.CompareTo(other.Lastname);

            if (result != 0)
            {
                return result;
            }

            return Firstname.CompareTo(other.Firstname);
        }



    }
}
