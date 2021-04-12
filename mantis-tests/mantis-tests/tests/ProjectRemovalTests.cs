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
            app.Auth.LoginByAdmin();

            if (app.Projects.GetProjectsList().Count == 0)
            {
                app.Projects.Create(new ProjectData("testproject"));
            }

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            app.Projects.Remove(0);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }

}
