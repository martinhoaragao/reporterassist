using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

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

        public void MarkTimestampDBlist()
        {
            timestamps.ForEach(delegate (float timestamp)
            {
                MarkTimestampDB(timestamp);
            });
        }

        public void MarkTimestampDB(float timestamp)
        {
            string idAudio = base.Name;
            idAudio = idAudio.Substring(5, idAudio.Length - 5);
            int idAud = Int32.Parse(idAudio);
            SqlConnection sqlConn = new SqlConnection("Server =10.0.2.5; Database = reporterassist; UID = reporter; Password = a1912Adsma10321aM");
            SqlCommand sqlComm = new SqlCommand();
            sqlComm = sqlConn.CreateCommand();
            sqlComm.CommandText = @"INSERT INTO TIMESTAMP VALUES (@TIME, @Audio_idAudio)";
            sqlComm.Parameters.Add("@TIME", SqlDbType.Float);
            sqlComm.Parameters["@TIME"].Value = timestamp;
            sqlComm.Parameters.Add("@Audio_idAudio", SqlDbType.Int);
            sqlComm.Parameters["@Audio_idAudio"].Value = idAud;
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
            MarkTimestamp(timestamp);
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

