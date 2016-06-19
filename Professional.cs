using System;
using System.Linq;
using System.Collections.Generic;

namespace Shared
{
	public class Professional
	{
		private string mail;
		private string password;
		private string name;
		private Dictionary<int, Project> projects;


		public Professional(string _mail, string _password, string _name)
		{
			mail = _mail;
			password = _password;
			name = _name;
			projects = new Dictionary<int, Project>();
		}

		public void AddProject(string title, string description, DateTime begin, DateTime end)
		{
			int id;
			if (projects.Count() > 0)
				id = projects.Keys.Max() + 1;
			else id = 0;

			Project project = new Project(id, title, description, begin, end);
			projects.Add(id, project);
		}

		public void AddProject(string title, string description, DateTime begin, DateTime end, State state)
		{
			int id;
			if (projects.Count() > 0)
				id = projects.Keys.Max() + 1;
			else id = 0;

			Project project = new Project(id, title, description, begin, end, state);
			projects.Add(id, project);
		}

		public void AddProject(Project proj)
		{
			int id;
			if (projects.Count() > 0)
				id = projects.Keys.Max() + 1;
			else id = 0;

			projects.Add(id, proj);
		}


		public void RemoveProject(string title)
		{
			foreach (Project project in projects.Values.ToList())
			{
				if (project.Title == title)
					projects.Remove(project.Id);
			}
		}

		public void AddTask(int idProject, string title, string note, State state)
		{
			projects[idProject].AddTask(title, note, state);
		}

		public void AddTask(int idProject, Task task)
		{
			projects[idProject].AddTask(task);
		}


		public void AddAudio(string path, int idProject)
		{
			projects[idProject].AddAudio(path);
		}

		public void AddImage(string path, int idProject)
		{
			projects[idProject].AddImage(path);
		}

		public void AddVideo(string path, int idProject)
		{
			projects[idProject].AddVideo(path);
		}

		public void AddTimeStamp(float timestamp, int idAudio, int idProject)
		{
			projects[idProject].AddTimeStamp(timestamp, idAudio);
		}

		public void AddCoordinate(int idProject, float lat, float lon, DateTime date)
		{
			projects[idProject].AddCoordinate(lat, lon, date);
		}

		// Gets and Sets

		public Dictionary<int, Project> Projects
		{
			get
			{
				return projects;
			}
		}

		public string Mail
		{
			get
			{
				return mail;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		internal bool ContainsKeyUser(string v)
		{
			throw new NotImplementedException();
		}
	}
}
