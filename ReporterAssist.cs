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
			projects = new List<Project>();
			users = new Dictionary<string, Professional>();
			connectedUser = null;
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

		public void AddProject(Project proj)
		{
			Project project = new Project(proj.Title, proj.Description, proj.Begin, proj.End, proj.Tasks, proj.Attachments, proj.Coordinates);
			projects.Add(project);
		}

		public void AddProject(string _title, string _description, DateTime _begin, DateTime _end)
		{
			Project project = new Project(_title,_description, _begin, _end);
			projects.Add(project);
		}

		public void AddProject(string _title, string _description, DateTime _begin, DateTime _end, State _state)
		{
			Project project = new Project(_title, _description, _begin, _end, _state);
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

		public List<Project> Projects
		{
			get
			{
				return projects;
			}
		}

		public Dictionary<string, Professional> Users
		{
			get
			{
				return users;
			}
		}

		public string ConnectedUser
		{
			get
			{
				return connectedUser;
			}
		}
	}
}

