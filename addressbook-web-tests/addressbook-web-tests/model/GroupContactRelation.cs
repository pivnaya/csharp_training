using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "group_id"), NotNull]
        public string GroupId { get; }

        [Column(Name = "id"), NotNull]
        public string ContactId { get; }
    }
}
