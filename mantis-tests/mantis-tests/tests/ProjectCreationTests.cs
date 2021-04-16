using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData("testProject");

            List<ProjectData> oldProjects = app.API.GetProjectsList(account);

            ProjectData existingProject = oldProjects.Find(x => x.Name == project.Name);

            if (existingProject != null)
            {
                app.API.DeleteProject(account, existingProject);
                oldProjects.Remove(existingProject);
            }

            app.Auth.LoginByAdmin();

            app.Projects.Create(project);

            List<ProjectData> newProjects = app.API.GetProjectsList(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
