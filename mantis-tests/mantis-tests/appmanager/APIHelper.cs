using System;
using System.Collections;
using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void DeleteProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }

        public int GetProjectsCount(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            return client.mc_projects_get_user_accessible(account.Name, account.Password).Length;
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            
            List<ProjectData> projects = new List<ProjectData>();
            foreach(Mantis.ProjectData mantisProject in mantisProjects)
            {
                projects.Add(new ProjectData() { Name = mantisProject.name, Id = mantisProject.id });
            }
            return projects;
        }

        public void ProjectCreate(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }
    }
}
