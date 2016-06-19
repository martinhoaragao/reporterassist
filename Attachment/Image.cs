using System;

namespace Shared {
	public class Image : Attachment 
	{
		public Image(String name, String path) : base(name, path) { }
		public Image(int id, String name, String path) : base(id, name, path) { }
	}
}

