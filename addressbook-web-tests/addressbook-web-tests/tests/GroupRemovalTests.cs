using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupPresent())
            {
                app.Groups.Create(new GroupData("testname"));
            }
            app.Groups.Remove(1);
        }
    }
}

