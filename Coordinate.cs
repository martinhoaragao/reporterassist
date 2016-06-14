using System;
namespace Shared
{
	public class Coordinate
	{
		private float lat;
		private float lon;

		public Coordinate(float _lat, float _lon)
		{
			lat = _lat;
			lon = _lon;
		}

		// Gets and Sets

		float Lat
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

		float Lon
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

