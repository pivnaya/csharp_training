using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            GoToManageProjectPage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project_id')]/../.."));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.FindElement(By.XPath("td[1]")).Text));
            }
            return projects;
        }

        public void GoToManageProjectPage()
        {
            manager.Menu.Manage();
            manager.Menu.ManageProject();
        }

        public void Create(ProjectData project)
        {
            GoToManageProjectPage();
            InitProjectCreation();
            InputProjectName(project.Name);
            SubmitProjectCreation();
            GoToManageProjectPage();
        }

        public void Remove(int index)
        {
            GoToManageProjectPage();
            InitProjectModification(index);
            RemoveProject();
            SubmitProjectRemoval();
            GoToManageProjectPage();
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Создать новый проект')]")).Click();
        }

        public void InputProjectName(string projectName)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(projectName);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void InitProjectModification(int index)
        {
            driver.FindElements(By.XPath("//a[contains(@href,'manage_proj_edit_page.php?project_id')]"))[index].Click();
        }

        public void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void SubmitProjectRemoval()
        {
            RemoveProject();
        }
    }
}
