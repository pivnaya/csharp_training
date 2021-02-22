using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newtestname");
            newData.Header = "newtestheader";
            newData.Footer = "newtestfooter";

            app.Groups.Modify(1, newData);
        }
    }
}
