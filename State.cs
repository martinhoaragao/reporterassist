using System;
namespace Shared
{
	public class State
	{
		private string type;

		public State()
		{
			type = "To Do";
		}

		// Gets and Sets

		string Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
			}
		}
	}
}

