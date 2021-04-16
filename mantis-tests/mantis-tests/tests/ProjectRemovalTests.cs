using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {
        [Test]
        public void TestProjectRemove()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Name = "testproject"
            };

            if (app.API.GetProjectsCount(account) == 0)
            {
                app.API.ProjectCreate(account, project);
            }

            app.Auth.LoginByAdmin();

            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }

}
