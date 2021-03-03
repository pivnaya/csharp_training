using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newtestname");
            newData.Header = "newtestheader";
            newData.Footer = "newtestfooter";

            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(newData);
            }
            app.Groups.Modify(1, newData);
        }
    }
}
