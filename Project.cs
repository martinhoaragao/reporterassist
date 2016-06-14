using System;
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

		private List<Task> tasks;
		private List<Attachment> attachments;
		private List<Coordinate> coordinates;

		public Project(int _id, string _title, DateTime _begin)
		{
			id = _id;
			title = _title;
			begin = _begin;
			state = new State();
		}

		public void AddTask(Task task)
		{
			tasks.Add(task);
		}

		public void AddAttachment(Attachment attachment)
		{
			attachments.Add(attachment);
		}

		public void AddCoordinate(float lat, float lon)
		{
			coordinates.Add(new Coordinate(lat,lon));
		}


		// Gets and Set

		int Id
		{
			get
			{
				return id;
			}
		}

		string Title
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

		string Description
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

		DateTime Begin
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

		DateTime End
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

		State State
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

		List<Task> Tasks
		{
			get
			{
				return tasks;
			}
		}

		List<Attachment> Attachments
		{
			get
			{
				return attachments;
			}
		}

		List<Coordinate> Coordinates
		{
			get
			{
				return coordinates;
			}
		}
	}
}

