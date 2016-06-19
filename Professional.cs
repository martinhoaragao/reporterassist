using System;
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


        public void AddProject(int id, string title, string note, DateTime begin, DateTime end, State state)
        {
            Project project = new Project(title, note, begin, end, state);
            projects.Add(id, project);
        }

        public void RemoveProject(int index)
        {
            projects.Remove(index);
        }

        public void AddTask(int id, int idProject, string title, string note, State state)
        {
            projects[idProject].AddTask(id, title, note, state);
        }

        public void AddAudio(int id, string path, int idProject)
        {
            projects[idProject].AddAudio(id, path);
        }

        public void AddImage(int id, string path, int idProject)
        {
            projects[idProject].AddImage(id, path);
        }

        public void AddVideo(int id, string path, int idProject)
        {
            projects[idProject].AddVideo(id, path);
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

        Dictionary<int, Project> Projects
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

