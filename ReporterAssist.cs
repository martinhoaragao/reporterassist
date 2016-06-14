using System;
using System.Collections.Generic;
namespace Shared
{
	public class ReporterAssist
	{
		private List<Project> projects;
		private Dictionary<string, Professional> users;
		private string connectedUser;

		public ReporterAssist()
		{
		}

		public bool LogIn(string mail, string password)
		{
			bool ifLogsIn = false;

			if (users.ContainsKey(mail))
			{
				Professional professional = users[mail];

				ifLogsIn = professional.Password == password;
				if (ifLogsIn)
					connectedUser = professional.Name;
			}
			return ifLogsIn;
		}

		public void Logout()
		{
		}

		public void AddProject(string title, DateTime begin)
		{
			Project project = new Project(title, begin);
			projects.Add(project);
		}

		public void RemoveProject(int index)
		{
			projects.RemoveAt(index);
		}

		public void AddUser(string mail, string password, string name)
		{
			Professional professional = new Professional(mail, password, name);
			users.Add(mail, professional);
		}

		// Gets and Sets

		List<Project> Projects
		{
			get
			{
				return projects;
			}
		}

		Dictionary<string, Professional> Users
		{
			get
			{
				return users;
			}
		}

		string ConnectedUser
		{
			get
			{
				return connectedUser;
			}
		}
	}
}

