using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

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

        public void AddProjectDB(string title, string note, DateTime begin, DateTime end, string type)
        {
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Estado VALUES (@tipo)";
            sqlComm.Parameters.Add("@tipo", SqlDbType.VarChar);
            sqlComm.Parameters["@tipo"].Value = type;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
            int idState = getIdState();
            int idProfissional = getIdProfissional(this.mail);
            addProjectToDB(title, note, idState, idProfissional, begin, end);
            int id = getProjectId();
            State state = new State(type);
            AddProject(id, title, note, begin, end, state);
        }

        public void AddProject(int id, string title, string note, DateTime begin, DateTime end, State state)
        {
            Project project = new Project(id, title, note, begin, end, state);
            projects.Add(id, project);
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
			projects.Add(proj.Id, proj);
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

        public void AddTask(int id, int idProject, string title, string note, State state)
        {
			projects[idProject].AddTaskDB(title, note, state.Type);
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

        public int getIdState()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idEstado FROM Estado ORDER BY idEstado DESC", conn);
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

        public int getIdProfissional(string mail)
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idProfissional FROM Profissional WHERE email = '" + mail + "'", conn);
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

        public int getProjectId()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTrabalho FROM Trabalho ORDER BY idTrabalho DESC", conn);
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

        public void addProjectToDB(string title, string note, int idState, int idProfissional, DateTime begin, DateTime end)
        {
            SqlConnection sqlConn1 = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm1 = new SqlCommand();
            sqlComm1 = sqlConn1.CreateCommand();
            sqlComm1.CommandText = @"INSERT INTO Trabalho VALUES (@titulo, @nota, @Estado_idEstado, @Profissional_idProfissional, @DataInicio, @DataFim)";
            sqlComm1.Parameters.Add("@titulo", SqlDbType.VarChar);
            sqlComm1.Parameters["@titulo"].Value = title;
            sqlComm1.Parameters.Add("@nota", SqlDbType.VarChar);
            sqlComm1.Parameters["@nota"].Value = note;
            sqlComm1.Parameters.Add("@Estado_idEstado", SqlDbType.Int);
            sqlComm1.Parameters["@Estado_idEstado"].Value = idState;
            sqlComm1.Parameters.Add("@Profissional_idProfissional", SqlDbType.Int);
            sqlComm1.Parameters["@Profissional_idProfissional"].Value = idProfissional;
            sqlComm1.Parameters.Add("@DataInicio", SqlDbType.DateTime);
            sqlComm1.Parameters["@DataInicio"].Value = begin;
            sqlComm1.Parameters.Add("@DataFim", SqlDbType.DateTime);
            sqlComm1.Parameters["@DataFim"].Value = end;
            sqlConn1.Open();
            sqlComm1.ExecuteNonQuery();
            sqlConn1.Close();
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
