using System;
using System.Collections.Generic;

namespace Shared
{
	public class Audio : Attachment
	{
		private List<float> timestamps;

		public Audio(string name, string path) : base(name, path)
		{
			timestamps = new List<float>();
		}

		public Audio(int id, string name, string path) : base(id, name, path)
		{
			timestamps = new List<float>();
		}

		public void MarkTimestamp(float timestamp)
		{
			timestamps.Add(timestamp);
		}

		// Gets and Sets

		public List<float> Timestamps
		{
			get
			{
				return timestamps;
			}
		}



	}
}

