using System;
using System.Collections.Generic;
namespace Shared
{
	public class ReporterAssist
	{
		private Dictionary<string, Professional> users;
		private string connectedUser;

		public ReporterAssist()
		{
			users = new Dictionary<string, Professional>();
			AddUser("belo", "belinho", "Belo");
			connectedUser = "belo";
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

		public void AddProject(Project project)
		{
			users[connectedUser].AddProject(project);
		}

		public void AddProject(string title, string description, DateTime begin, DateTime end)
		{
			users[connectedUser].AddProject(title, description, begin, end);
		}

		public void AddUser(string mail, string password, string name)
		{
			Professional professional = new Professional(mail, password, name);
			users.Add(mail, professional);
		}

		public void AddTask(int idProject, string title, string note, string type)
		{
			State state = new State(type);
			users[connectedUser].AddTask(idProject, title, note, state);
		}

		public void AddTask(int idProject, Task task)
		{
			users[connectedUser].AddTask(idProject, task);
		}

		public void AddAudio(string path, int idProject)
		{
			users[connectedUser].AddAudio(path, idProject);
		}

		public void AddImage(string path, int idProject)
		{
			users[connectedUser].AddImage(path, idProject);
		}

		public void AddVideo(string path, int idProject)
		{
			users[connectedUser].AddVideo(path, idProject);
		}

		public void AddTimeStamp(float timestamp, int idAudio, int idProject)
		{
			users[connectedUser].AddTimeStamp(timestamp, idAudio, idProject);
		}

		public void AddCoordinate(int idProject, float lat, float lon, DateTime date)
		{
			users[connectedUser].AddCoordinate(idProject, lat, lon, date);
		}

		public void RemoveProject(string title)
		{
			users[connectedUser].RemoveProject(title);
		}

		// Gets and Sets
		public Dictionary<int, Project> Projects
		{
			get
			{
				return users[connectedUser].Projects;
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

