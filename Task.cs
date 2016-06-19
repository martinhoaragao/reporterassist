using System;
namespace Shared
{
	public class Task : ICloneable {
		private int id;
		private string title;
		private string description;
		private State state;

		public Task()
		{
			id = -1;
			title = null;
			description = null;
			state = new State();
		}

		public Task(int _id, string _title) 
		{
			id = _id;
			title = _title;
			description = null;
			state = new State();
		}

		public Task(int _id, string _title, string _description)
		{
			id = _id;
			title = _title;
			description = _description;
			state = new State();
		}

		public void Update(string _title, string _description, State _state) 
		{
			title = _title;
			description = _description;
			state = _state;
		}


		// Gets and sets

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

		public object Clone()
		{
			return this;
		}

	}
}

