﻿using System;
namespace Shared
{
	public class Task {
		private string title;
		private string description;
		private State state;

		public Task(int _id, string _title) 
		{
			title = _title;
			state = new State();
		}

		public void Update(string _title, string _description, State _state) 
		{
			title = _title;
			description = _description;
			state = _state;
		}


		// Gets and sets

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

