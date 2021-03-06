﻿using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        private string allEmails;

        private string fullInfo;

        private string birthday;

        private string anniversary;

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }

        [Column(Name = "lastname"), NotNull]
        public string Lastname { get; set; }

        [Column(Name = "id"), NotNull, PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated"), NotNull]
        public string Deprecated { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string SecondHomePhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string MiddleName { get; set; }

        public string Company { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Fax { get; set; }

        public string Homepage { get; set; }

        public string BirthDay { get; set; }

        public string BirthMonth { get; set; }

        public string BirthYear { get; set; }

        public string AnniversaryDay { get; set; }

        public string AnniversaryMonth { get; set; }

        public string AnniversaryYear { get; set; }

        public string SecondAddress { get; set; }

        public string Comment { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone) + CleanUpPhone(SecondHomePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, @"[ \-()]", "") + "\r\n";
        }

        public string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        public string FormatValue(string prefix, string value, string suffix)
        {
            if (value == null || value == "")
            {
                return "";
            }
            return (prefix + value.Trim()).Trim() + suffix;
        }

        public string FormatValue(string value, string suffix)
        {
            return FormatValue("", value, suffix);
        }

        public string FormatYear(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            int diff = DateTime.Now.Year - Int32.Parse(value);
            return $"{value} ({diff})";
        }

        public string FullInfo
        {
            get
            {
                if (fullInfo != null)
                {
                    return fullInfo;
                }
                else
                {
                    return (
                        FormatValue(
                            FormatValue(
                                FormatValue(Firstname, " ") + FormatValue(MiddleName, " ") + FormatValue(Lastname, ""),
                                "\r\n"
                            ) +
                            FormatValue(Nickname, "\r\n") +
                            FormatValue(Title, "\r\n") +
                            FormatValue(Company, "\r\n") +
                            FormatValue(Address, "\r\n"),
                            "\r\n\r\n"
                        ) +
                        FormatValue(
                            FormatValue("H: ", HomePhone, "\r\n") +
                            FormatValue("M: ", MobilePhone, "\r\n") +
                            FormatValue("W: ", WorkPhone, "\r\n") +
                            FormatValue("F: ", Fax, "\r\n"),
                            "\r\n\r\n"
                        ) +
                        FormatValue(
                            FormatValue(AllEmails, "\r\n") +
                            FormatValue("Homepage:\r\n", Homepage, "\r\n"),
                            "\r\n\r\n"
                        ) +
                        FormatValue(
                            FormatValue("Birthday ", Birthday, "\r\n") +
                            FormatValue("Anniversary ", Anniversary, "\r\n"),
                            "\r\n\r\n"
                        ) +
                        FormatValue(SecondAddress, "\r\n\r\n") +
                        FormatValue("P: ", SecondHomePhone, "\r\n\r\n") +
                        FormatValue(Comment, "")
                    ).Trim();
                }
            }
            set
            {
                fullInfo = value;
            }
        }

        public string Birthday
        {
            get
            {
                if (birthday != null)
                {
                    return birthday;
                }
                else
                {
                    return (FormatValue(BirthDay, ". ") + FormatValue(BirthMonth, " ") + FormatYear(BirthYear)).Trim();
                }
            }
            set
            {
                birthday = value;
            }
        }

        public string Anniversary
        {
            get
            {
                if (anniversary != null)
                {
                    return anniversary;
                }
                else
                {
                    return (FormatValue(AnniversaryDay, ". ") + FormatValue(AnniversaryMonth, " ") + FormatYear(AnniversaryYear)).Trim();
                }
            }
            set
            {
                anniversary = value;
            }
        }

        public ContactData()
        {
        }

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
            return "firstName: " + Firstname + "\nlastName: " + Lastname;
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "00.00.0000 0:00:00") 
                            select c).ToList();
            }
        }
    }
}
