using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTests()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator", Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Id = "10"
            };

            IssueData issue = new IssueData()
            {
                Summary = "text",
                Description = "text",
                Category = "General"
            };

            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
