using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            app.Auth.LoginByAdmin();

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();

            Random rnd = new Random();
            int value = rnd.Next(0, 30);
            ProjectData project = new ProjectData($"testProject{value}");
            
            app.Projects.Create(project);

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }

}
