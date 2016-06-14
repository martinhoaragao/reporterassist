using System;
using System.Collections.Generic;

namespace Shared {
	public class Audio : Attachment {

		private List<DateTime> timestamps;

		public Audio (String name, String path) : base(name, path) {

			timestamps = new List<DateTime>();
		}

		public void MarkTimestamp(DateTime timestamp) {
			timestamps.Add(timestamp);
		}

		// Gets and Sets

		List<DateTime> Timestamps
		{
			get
			{
				return timestamps;
			}
		}



	}
}

