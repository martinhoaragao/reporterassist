using System;
using System.Linq;
using System.Collections.Generic;

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
