using System;

namespace Shared {
	public class Attachment {
		private string name;
		private string path;

		public Attachment(string _name, string _path) {
			name = _name;
			path = _path;
		}

		// Gets and Sets

		string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		string Path
		{
			get
			{
				return path;
			}

			set
			{
				path = value;
			}
		}

	}
}


