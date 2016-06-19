using System;

namespace Shared {
	public class Video : Attachment {
		public Video(String name, String path) : base(name, path) { }
		public Video(int id, String name, String path) : base(id, name, path) { }
	}
}

