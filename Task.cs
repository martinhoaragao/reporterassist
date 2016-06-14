using System;
namespace Shared
{
	public class Task {
		private int idTask;
		private string title;
		private string description;
		private State state;

		public Task(int _idTask, string _title) 
		{
			idTask = _idTask;
			title = _title;
			state = new State();
		}

		public void update(string _title, string _description, State _state) 
		{
			title = _title;
			description = _description;
			state = _state;
		}


		// Gets and sets

		int IdTask
		{
			get
			{
				return idTask;
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


	}
}

