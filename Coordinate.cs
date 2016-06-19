using System;
namespace Shared
{
	public class Coordinate
	{
		private float lat;
		private float lon;
        private DateTime date;

		public Coordinate(float _lat, float _lon, DateTime _date)
		{
			lat = _lat;
			lon = _lon;
            date = _date;
		}

		// Gets and Sets

		public float Lat
		{
			get
			{
				return lat;
			}

			set
			{
				lat = value;
			}
		}

		public float Lon
		{
			get
			{
				return lon;
			}

			set
			{
				lon = value;
			}
		}
	}
}

