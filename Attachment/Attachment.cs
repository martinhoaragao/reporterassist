using System;

namespace Shared {
	public class Attachment {
		private int id;
		private string name;
		private string path;

		public Attachment(string _name, string _path) {
			id = 0;
			name = _name;
			path = _path;
		}

		public Attachment(int _id, string _name, string _path)
		{
			id = _id;
			name = _name;
			path = _path;
		}

		// Gets and Sets

		int Id
		{
			get
			{
				return id;
			}
		}

		public string Name
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

		public string Path
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


