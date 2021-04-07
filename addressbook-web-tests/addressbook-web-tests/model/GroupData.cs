using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; } = "";

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; } = "";

        [Column(Name = "group_id"), NotNull, PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated"), NotNull]
        public string Deprecated { get; set; }

        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name: " + Name + "\nheader: " + Header + "\nfooter: " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups.Where(x => x.Deprecated == "00.00.0000 0:00:00") 
                            select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                            from gcr in db.GCR.Where(p => p.GroupId == Id 
                                && p.ContactId == c.Id 
                                && c.Deprecated == "00.00.0000 0:00:00")
                            select c).Distinct().ToList();
            }
        }
    }
}
