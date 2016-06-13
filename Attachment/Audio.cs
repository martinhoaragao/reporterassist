using System;
using System.Collections.Generic;

namespace Shared {
	public class Audio : Attachment {

		private List<DateTime> timestamps;

		public Audio (String name, String path) : base(name, path) {

			timestamps = new List<DateTime>();
		}

		public void markTimestamp(DateTime timestamp) {
			timestamps.Add(timestamp);
		}

		public List<DateTime> getTimestamps()
		{
			return timestamps;
		}



	}
}

