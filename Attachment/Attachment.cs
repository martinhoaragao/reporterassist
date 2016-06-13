using System;

namespace Shared {
	public class Attachment {
		private string name;
		private string path;

		public Attachment(string _name, string _path) {
			name = _name;
			path = _path;
		}

		public void setName(string _name) {
			name = _name;
		}

		public void setPath(string _path) {
			path = _path;
		}

		public string getName() {
			return name;
		}

		public string getPath() {
			return path;
		}

	}
}


