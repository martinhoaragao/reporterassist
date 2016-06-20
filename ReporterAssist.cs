using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

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
					connectedUser = professional.Mail;
				Console.WriteLine("Mail " + professional.Mail);
			}
			return ifLogsIn;
		}

		public void Logout()
		{
		}

		public void AddProject(int id, string title, string note, DateTime begin, DateTime end, string type, string mail)
		{
			State state = new State(type);
			users[mail].AddProject(id,title, note, begin, end, state);
			//Console.WriteLine("Nr " + users[mail].Projects.Count);
		}

		public void AddProject(string title, string description, DateTime begin, DateTime end)
		{
			users[connectedUser].AddProject(title, description, begin, end);
		}

		public void AddProject(string title, string description, DateTime begin, DateTime end, State state)
		{
			users[connectedUser].AddProject(title, description, begin, end, state);
		}

		public void AddProjectDB(string title, string description, DateTime begin, DateTime end, State state)
		{
			users[connectedUser].AddProjectDB(title, description, begin, end, state.Type);
		}

		public void AddProject(Project proj)
		{
			users[connectedUser].AddProject(proj);
		}

		public void AddUserDB(string mail, string password, string name)
		{
			SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
			SqlCommand sqlComm = new SqlCommand();
			sqlComm = sqlConn.CreateCommand();
			sqlComm.CommandText = @"INSERT INTO Profissional VALUES (@nome, @mail, @password)";
			sqlComm.Parameters.Add("@nome", SqlDbType.VarChar);
			sqlComm.Parameters["@nome"].Value = name;
			sqlComm.Parameters.Add("@mail", SqlDbType.VarChar);
			sqlComm.Parameters["@mail"].Value = mail;
			sqlComm.Parameters.Add("@password", SqlDbType.VarChar);
			sqlComm.Parameters["@password"].Value = password;
			sqlConn.Open();
			sqlComm.ExecuteNonQuery();
			sqlConn.Close();
			AddUser(mail, password, name);
		}

        public void AddUser(string mail, string password, string name)
		{
			Professional professional = new Professional(mail, password, name);
			users.Add(mail, professional);
		}

        public void AddTask(int id, int idProject, string title, string note, string type, string mail)
        {
            State state = new State(type);
            users[mail].AddTask(id, idProject, title, note, state);
        }

		public void AddTaskNDB(int id, int idProject, string title, string note, string type, string mail)
		{
			State state = new State(type);
			users[mail].AddTaskNDB(id, idProject, title, note, state);
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

        public void AddTimeStamp(float timestamp, int idAudio, int idProject, string mail)
        {
            users[mail].AddTimeStamp(timestamp, idAudio, idProject);
        }

        public void AddCoordinate(int idProject, float lat, float lon, DateTime date, string mail)
        {
            users[mail].AddCoordinate(idProject, lat, lon, date);
        }

        public void RemoveProject(string title)
		{
			users[connectedUser].RemoveProject(title);
		}

        public int getIdUser()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idProfissional FROM Profissional  ORDER BY idProfissional DESC", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read() && i < 1)
            {
                i++;
                id = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return id;
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

