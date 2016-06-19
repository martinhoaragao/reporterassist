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

		public void AddProject(int id, string title, string note, DateTime begin, DateTime end, string type, string mail)
		{
			State state = new State(type);
			users[mail].AddProject(id, title, note, begin, end, state);
		}

		public void AddUser(int id, string mail, string password, string name)
		{
			Professional professional = new Professional(mail, password, name);
			users.Add(mail, professional);
		}

		public void AddTask(int id, int idProject, string title, string note, string type, string mail)
		{
			State state = new State(type);
			users[mail].AddTask(id, idProject, title, note, state);
		}

		public void AddAudio(int id, string path, int idProject, string mail)
		{
			users[mail].AddAudio(id, path, idProject);
		}

		public void AddImage(int id, string path, int idProject, string mail)
		{
			users[mail].AddImage(id, path, idProject);
		}

		public void AddVideo(int id, string path, int idProject, string mail)
		{
			users[mail].AddVideo(id, path, idProject);
		}

		public void AddTimeStamp(float timestamp, int idAudio, int idProject, string mail)
		{
			users[mail].AddTimeStamp(timestamp, idAudio, idProject);
		}

		public void AddCoordinate(int idProject, float lat, float lon, DateTime date, string mail)
		{
			users[mail].AddCoordinate(idProject, lat, lon, date);
		}

		// Gets and Sets

		Dictionary<string, Professional> Users
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

