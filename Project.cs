using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Shared
{
	public class Project
	{
		private int id;
		private string title;
		private string description;
		private DateTime begin;
		private DateTime end;
		private State state;

		private Dictionary<int, Task> tasks;
		private Dictionary<int, Audio> audios;
		private Dictionary<int, Video> videos;
		private Dictionary<int, Image> images;
		private List <Coordinate> coordinates;

		public Project()
		{
			id = 0;
			title = null;
			begin = new DateTime();
			description = null;
			end = new DateTime();
			state = new State();

			tasks = new Dictionary<int, Task>();
			audios = new Dictionary<int, Audio>();
			videos = new Dictionary<int, Video>();
			images = new Dictionary<int, Image>();
			coordinates = new List<Coordinate>();
		}


		public Project(int _id, string _title, DateTime _begin)
		{
			id = _id;
			title = _title;
			begin = _begin;
			description = null;
			end = new DateTime();
			state = new State();

			tasks = new Dictionary<int, Task>();
			audios = new Dictionary<int, Audio>();
			videos = new Dictionary<int, Video>();
			images = new Dictionary<int, Image>();
			coordinates = new List<Coordinate>();
		}

		public Project(int _id, string _title, string _description, DateTime _begin, DateTime _end)
		{
			id = _id;
			title = _title;
			begin = _begin;
			description = _description;
			end = _end; 
			state = new State();
			tasks = new Dictionary<int, Task>();
			audios = new Dictionary<int, Audio>();
			videos = new Dictionary<int, Video>();
			images = new Dictionary<int, Image>();
			coordinates = new List <Coordinate>();
		}

		public Project(int _id, string _title, string _description, DateTime _begin, DateTime _end, State _state)
		{
			id = _id;
			title = _title;
			description = _description;
			begin = _begin;
			end = _end;
			state = _state;

			tasks = new Dictionary<int, Task>();
			audios = new Dictionary<int, Audio>();
			videos = new Dictionary<int, Video>();
			images = new Dictionary<int, Image>();
			coordinates = new List<Coordinate>();
		}

        public void updateCoordinatesDB()
        {
            int i;
            int idCoordinates = getIdCoordinate();
            for (i = idCoordinates + 1; coordinates[i] != null; i++)
            {
                AddCoordinateDB(coordinates[i].Lat, coordinates[i].Lon, coordinates[i].Date);
            }
        }

        public void updateAttachmentsDB()
        {
            int i;
            int idAudio = getIdAudio(), idAudioMax = 0;
            int idVideo = getIdVideo(), idVideoMax = 0;
            int idImage = getIdImage(), idImageMax = 0;
            if ((audios.Count) > 0) { idAudioMax = audios.Keys.Max(); }
            if ((videos.Count) > 0) { idVideoMax = videos.Keys.Max(); }
            if ((images.Count) > 0) { idImageMax = images.Keys.Max(); }
            for (i = idAudio + 1; i <= idAudioMax; i++)
            {
                string path = audios[i].Path;
                AddAudioDB(path);
            }
            for (i = idVideo + 1; i <= idVideoMax; i++)
            {
                string path = videos[i].Path;
                AddVideoDB(path);
            }
            for (i = idImage + 1; i <= idImageMax; i++)
            {
                string path = images[i].Path;
                AddImageDB(path);
            }
        }

        public void AddAudioDB(string path)
        {
            int idProject = getIdProject(this.title);
            byte[] data = System.IO.File.ReadAllBytes(path);
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Audio VALUES (@audio, @Trabalho_idTrabalho)";
            sqlComm.Parameters.Add("@audio", SqlDbType.VarBinary);
            sqlComm.Parameters["@audio"].Value = data;
            sqlComm.Parameters.Add("@Trabalho_idTrabalho", SqlDbType.Int);
            sqlComm.Parameters["@Trabalho_idTrabalho"].Value = idProject;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
            int idAudio = getIdAudio();
            audios[idAudio].MarkTimestampDBlist();
        }

        public void AddAudio(int id, string path)
        {
            string name = "Audio" + id;
            Audio audio = new Audio(name, path);
            audios.Add(id, audio);
        }

        public void AddImageDB(string path)
        {
            int idProject = getIdProject(this.title);
            byte[] data = System.IO.File.ReadAllBytes(path);
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Imagem VALUES (@imagem, @Trabalho_idTrabalho)";
            sqlComm.Parameters.Add("@imagem", SqlDbType.VarBinary);
            sqlComm.Parameters["@imagem"].Value = data;
            sqlComm.Parameters.Add("@Trabalho_idTrabalho", SqlDbType.Int);
            sqlComm.Parameters["@Trabalho_idTrabalho"].Value = idProject;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void AddImage(int id, string path)
        {
            string name = "Image" + id;
            Image image = new Image(name, path);
            images.Add(id, image);
        }

        public void AddVideoDB(string path)
        {
            int idProject = getIdProject(this.title);
            byte[] data = System.IO.File.ReadAllBytes(path);
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Video VALUES (@video, @Trabalho_idTrabalho)";
            sqlComm.Parameters.Add("@video", SqlDbType.VarBinary);
            sqlComm.Parameters["@video"].Value = data;
            sqlComm.Parameters.Add("@Trabalho_idTrabalho", SqlDbType.Int);
            sqlComm.Parameters["@Trabalho_idTrabalho"].Value = idProject;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void AddVideo(int id, string path)
        {
            string name = "Video" + id;
            Video video = new Video(name, path);
            videos.Add(id, video);
        }

        public void AddCoordinateDB(float lat, float lon, DateTime date)
        {
            int idProject = getIdProject(this.title);
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO Coordenada VALUES (@latitude, @longitude, @TIMESTAMP)";
            sqlComm.Parameters.Add("@latitude", SqlDbType.Float);
            sqlComm.Parameters["@latitude"].Value = lat;
            sqlComm.Parameters.Add("@longitude", SqlDbType.Float);
            sqlComm.Parameters["@longitude"].Value = lon;
            sqlComm.Parameters.Add("@TIMESTAMP", SqlDbType.DateTime);
            sqlComm.Parameters["@TIMESTAMP"].Value = date;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void AddTaskDB(string title, string note, string type)
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
            int idProject = getIdProject(this.title);
            AddTaskToDB(title, note, idState, idProject);
            int id = getTaskId();
            State state = new State(type);
            AddTask(id, title, note, state);
        }

        public void AddTask(int id, string title, string note, State state)
        {
            Task task = new Task(id,title, note, state);
            tasks.Add(id, task);
        }

        public void AddTask(string title, string description)
		{
			int id;
			if (tasks.Count() > 0)
				id = tasks.Keys.Max() + 1;
			else id = 0;

			Task task = new Task(id, title, description, state);
			tasks.Add(id, task);
		}

		public void AddTask(string title, string description, State state)
		{
			int id;
			if (tasks.Count() > 0)
				id = tasks.Keys.Max() + 1;
			else id = 0;

			Task task = new Task(id, title, description, state);
			tasks.Add(id, task);
		}

		public void AddTask(Task _task)
		{
			int id;
			if (tasks.Count() > 0)
				id = tasks.Keys.Max() + 1;
			else id = 0;

			Task task = new Task(id, _task.Title, _task.Description, _task.State);
			tasks.Add(id, task);
		}

        public void RemoveTaskDB(int index)
        {
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"DELETE FROM Tarefa WHERE idTarefa='@idTarefa'";
            sqlComm.Parameters.Add("@idTarefa", SqlDbType.Int);
            sqlComm.Parameters["@idTarefa"].Value = index;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void RemoveTask(int index)
		{
			tasks.Remove(index);
		}

		public void AddAudio(string path)
		{
			int id;
			if (audios.Count() > 0)
				id = audios.Keys.Max() + 1;
			else id = 0;

			string name = "Audio" + id;
			Audio audio = new Audio(id, name, path);
			audios.Add(id, audio);
		}

		public void AddImage(string path)
		{
			int id;
			if (images.Count() > 0)
				id = images.Keys.Max() + 1;
			else id = 0;

			string name = "Image" + id;
			Image image = new Image(id, name, path);
			images.Add(id, image);
		}

		public void AddVideo(string path)
		{
			int id;
			if (videos.Count() > 0)
				id = videos.Keys.Max() + 1;
			else id = 0;

			string name = "Video" + id;
			Video video = new Video(id, name, path);
			videos.Add(id, video);
		}

		public void AddCoordinate(int id, float lat, float lon, DateTime date)
		{
			Coordinate coordinate = new Coordinate(lat, lon, date);
			coordinates.Add(coordinate);
		}

		public void AddTimeStamp(float timestamp, int idAudio)
		{
			audios[idAudio].MarkTimestamp(timestamp);
		}

		public void AddCoordinate(float lat, float lon, DateTime date)
		{
			Coordinate coordinate = new Coordinate(lat, lon, date);
			coordinates.Add(coordinate);
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

        public int getIdCoordinate()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(latitude) FROM Coordenada;", conn);
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

        public int getIdImage()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idImagem FROM Imagem ORDER BY idImagem DESC", conn);
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

        public int getIdVideo()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idVideo FROM Video ORDER BY idVideo DESC", conn);
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

        public int getIdAudio()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idAudio FROM Audio ORDER BY Audio DESC", conn);
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

        public int getIdProject(string title)
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTrabalho FROM Trabalho WHERE titulo = '" + title + "'", conn);
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

        public void AddTaskToDB(string title, string note, int idState, int idProject)
        {
            SqlConnection sqlConn1 = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm1 = new SqlCommand();
            sqlComm1 = sqlConn1.CreateCommand();
            sqlComm1.CommandText = @"INSERT INTO Tarefa VALUES (@titulo, @descricao, @Estado_idEstado, @Trabalho_idTrabalho)";
            sqlComm1.Parameters.Add("@titulo", SqlDbType.VarChar);
            sqlComm1.Parameters["@titulo"].Value = title;
            sqlComm1.Parameters.Add("@descricao", SqlDbType.VarChar);
            sqlComm1.Parameters["@descricao"].Value = note;
            sqlComm1.Parameters.Add("@Estado_idEstado", SqlDbType.Int);
            sqlComm1.Parameters["@Estado_idEstado"].Value = idState;
            sqlComm1.Parameters.Add("@Trabalho_idTrabalho", SqlDbType.Int);
            sqlComm1.Parameters["@Trabalho_idTrabalho"].Value = idProject;
            sqlConn1.Open();
            sqlComm1.ExecuteNonQuery();
            sqlConn1.Close();
        }

        public int getTaskId()
        {
            int id = 0, i = 0;
            SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTarefa FROM Tarefa ORDER BY idTarefa DESC", conn);
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

        public int Id
		{
			get
			{
				return id;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}

			set
			{
				title = value;
			}
		}

		public string Description
		{
			get
			{
				return description;
			}

			set
			{
				description = value;
			}
		}

		public DateTime Begin
		{
			get
			{
				return begin;
			}

			set
			{
				begin = value;
			}
		}

		public DateTime End
		{
			get
			{
				return end;
			}

			set
			{
				end = value;
			}
		}

		public State State
		{
			get
			{
				return state;
			}

			set
			{
				state = value;
			}
		}

		public Dictionary<int,Task> Tasks
		{
			get
			{
				return tasks;
			}
		}

		public Dictionary<int, Audio> Audios
		{
			get
			{
				return audios;
			}
		}

		public Dictionary<int, Video> Videos
		{
			get
			{
				return videos;
			}
		}

		public Dictionary<int, Image> Images
		{
			get
			{
				return images;
			}
		}

		public List<Coordinate> Coordinates
		{
			get
			{
				return coordinates;
			}
		}

	}
}
