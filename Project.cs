﻿using System;
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

		private List<Task> tasks;
		private List<Attachment> attachments;
		private List<Coordinate> coordinates;

		public Project(string _title, DateTime _begin)
		{
			title = _title;
			begin = _begin;
			state = new State();
		}

		public void AddTask(int id, string title)
		{
			Task task = new Task(id, title);
			tasks.Add(task);
		}

		public void RemoveTask(int index)
		{
			tasks.RemoveAt(index);
		}

		public void AddAudio(string name, string path)
		{
			Audio attachment = new Audio(name, path);
			attachments.Add(attachment);
		}

		public void AddImage(string name, string path)
		{
			Image attachment = new Image(name, path);
			attachments.Add(attachment);
		}

		public void AddVideo(string name, string path)
		{
			Video attachment = new Video(name, path);
			attachments.Add(attachment);
		}


		public void AddCoordinate(float lat, float lon)
		{
			Coordinate coordinate = new Coordinate(lat, lon);
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

		public List<Task> Tasks
		{
			get
			{
				return tasks;
			}
		}

		public List<Attachment> Attachments
		{
			get
			{
				return attachments;
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

