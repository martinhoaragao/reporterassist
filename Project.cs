using System;
using System.Collections.Generic;

namespace Shared
{
	public class Project
	{
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
			title = null;
			begin = new DateTime();
			description = null;
			end = new DateTime();
			state = new State();
			tasks = new List<Task>();
			attachments = new List<Attachment>();
			coordinates = new List<Coordinate>();
		}


		public Project(string _title, DateTime _begin)
		{
			title = _title;
			begin = _begin;
			description = null;
			end = new DateTime();
			state = new State();

			tasks = new List<Task>();
			attachments = new List<Attachment>();
			coordinates = new List<Coordinate>();
		}

		public Project(string _title, string _description, DateTime _begin, DateTime _end)
		{
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

		public Project(string _title, string _description, DateTime _begin, DateTime _end, State _state)
		{
			title = _title;
			description = _description;
			begin = _begin;
			end = _e
			state = _state;
			tasks = new Dictionary<int, Task>();
			audios = new Dictionary<int, Audio>();
			videos = new Dictionary<int, Video>();
			images = new Dictionary<int, Image>();
			coordinates = new List<Coordinate>();
		}

		public void AddTask(int id, string title, string description)
		{
			Task task = new Task(title, description, state);
			tasks.Add(id, task);
		}

		public void AddTask(int id, string title, string description, State state)
		{
			Task task = new Task(title, description, state);
			tasks.Add(id, task);
		}

		public void RemoveTask(int index)
		{
			tasks.Remove(index);
		}

		public void AddAudio(int id, string path)
		{
			string name = "Audio" + id;
			Audio audio = new Audio(name, path);
			audios.Add(id, audio);
		}

		public void AddImage(int id, string path)
		{
			string name = "Image" + id;
			Image image = new Image(name, path);
			images.Add(id, image);
		}

		public void AddVideo(int id, string path)
		{
			string name = "Video" + id;
			Video video = new Video(name, path);
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
