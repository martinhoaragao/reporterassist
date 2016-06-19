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


