using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ReportAssistADO
    {
        private static ReporterAssist reporterAssist = new ReporterAssist();
        //SqlConnection conn;

		public ReportAssistADO()
		{
			SqlConnection conn = new SqlConnection("Server =10.0.2.5;Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
			conn.Open();

			AddUsers(conn);
			AddProjects(conn);
			AddTasks(conn);
			AddAudios(conn);
			AddImages(conn);
			AddVideos(conn);
			AddTimeStamps(conn);
			AddCoordinates(conn);
		}

        static void AddUsers(SqlConnection conn)
        {
            //int id;
            string name, mail, password;
            //conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Profissional", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                name = reader.GetString(0);
                mail = reader.GetString(1);
                password = reader.GetString(2);
                reporterAssist.AddUser(mail, password, name);
            }
            reader.Close();
            conn.Close();
        }

        static void AddProjects(SqlConnection conn)
        {
            int id;
            string title, note, type, mail;
            DateTime dateI, dateF;
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Trabalho AS T INNER JOIN Estado as E ON " +
                "T.Estado_idEstado = E.idEstado INNER JOIN Profissional " +
                "AS P ON T.Profissional_idProfissional = P.idProfissional", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                title = reader.GetString(1);
                note = reader.GetString(2);
                dateI = reader.GetDateTime(5);
                dateF = reader.GetDateTime(6);
                type = reader.GetString(8);
                mail = reader.GetString(10);
                reporterAssist.AddProject(id, title, note, dateI, dateF, type, mail);
				//Console.WriteLine("Title ->" + title);
            	
			}
			Console.WriteLine("Nr de proje " + reporterAssist.Projects.Count);
			reader.Close();
            conn.Close();
        }

        static void AddTasks(SqlConnection conn)
        {
            int id, idProject;
            string title, note, type, mail;
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Tarefa AS T INNER JOIN Estado as E ON " +
                "T.Estado_idEstado = E.idEstado INNER JOIN Trabalho AS " +
                "P ON T.Trabalho_idTrabalho = P.idTrabalho INNER JOIN " +
                "Profissional AS PR ON P.Profissional_idProfissional = PR.idProfissional", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
                title = reader.GetString(1);
                note = reader.GetString(2);
                idProject = reader.GetInt32(4);
                type = reader.GetString(6);
                mail = reader.GetString(15);
                reporterAssist.AddTask(id, idProject, title, note, type, mail);
            }
            reader.Close();
            conn.Close();
        }

        static void AddAudios(SqlConnection conn)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Audio INNER JOIN Trabalho AS T " +
                "ON Audio.Trabalho_idTrabalho = T.idTrabalho INNER JOIN PROFISSIONAL AS P " +
                "ON T.Profissional_idProfissional = P.idProfissional", conn);
            // Writes the BLOB to a file (*.bmp).
            FileStream stream;
            // Streams the BLOB to the FileStream object.
            BinaryWriter writer;
            // Size of the BLOB buffer.
            int bufferSize = 100;
            // The BLOB byte[] buffer to be filled by GetBytes.
            byte[] outByte = new byte[bufferSize];
            // The bytes returned from GetBytes.
            long retval;
            // The starting position in the BLOB output.
            long startIndex = 0;
            // The publisher id to use in the file name.
            int id;
            int idProject;
            string mail;

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                // Get the publisher id, which must occur before getting the logo.
                id = reader.GetInt32(0);

                // Create a file to hold the output.
                stream = new FileStream("Audio" + id + ".mp3", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryWriter(stream);

                // Reset the starting byte for the new BLOB.
                startIndex = 0;

                // Read bytes into outByte[] and retain the number of bytes returned.
                retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    writer.Write(outByte);
                    writer.Flush();

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
                }

                // Write the remaining buffer.
                writer.Write(outByte, 0, (int)retval - 1);
                writer.Flush();

                // Close the output file.
                string path = Directory.GetCurrentDirectory();
                writer.Close();
                stream.Close();
                idProject = reader.GetInt32(2);
                mail = reader.GetString(11);
                reporterAssist.AddAudio(id, path, idProject, mail);
            }
            reader.Close();
            conn.Close();
        }

        static void AddImages(SqlConnection conn)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Imagem INNER JOIN Trabalho AS T " +
                "ON Imagem.Trabalho_idTrabalho = T.idTrabalho INNER JOIN PROFISSIONAL AS P " +
                "ON T.Profissional_idProfissional = P.idProfissional", conn);
            // Writes the BLOB to a file (*.bmp).
            FileStream stream;
            // Streams the BLOB to the FileStream object.
            BinaryWriter writer;
            // Size of the BLOB buffer.
            int bufferSize = 100;
            // The BLOB byte[] buffer to be filled by GetBytes.
            byte[] outByte = new byte[bufferSize];
            // The bytes returned from GetBytes.
            long retval;
            // The starting position in the BLOB output.
            long startIndex = 0;
            // The publisher id to use in the file name.
            int id;
            int idProject;
            string mail;

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                // Get the publisher id, which must occur before getting the logo.
                id = reader.GetInt32(0);

                // Create a file to hold the output.
                stream = new FileStream("Audio" + id + ".bmp", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryWriter(stream);

                // Reset the starting byte for the new BLOB.
                startIndex = 0;

                // Read bytes into outByte[] and retain the number of bytes returned.
                retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    writer.Write(outByte);
                    writer.Flush();

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
                }

                // Write the remaining buffer.
                writer.Write(outByte, 0, (int)retval - 1);
                writer.Flush();

                // Close the output file.
                string path = Directory.GetCurrentDirectory();
                writer.Close();
                stream.Close();
                idProject = reader.GetInt32(2);
                mail = reader.GetString(11);
                reporterAssist.AddImage(id, path, idProject, mail);
            }
            reader.Close();
            conn.Close();
        }

        static void AddVideos(SqlConnection conn)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Video INNER JOIN Trabalho AS T " +
                "ON Video.Trabalho_idTrabalho = T.idTrabalho INNER JOIN PROFISSIONAL AS P " +
                "ON T.Profissional_idProfissional = P.idProfissional", conn);
            // Writes the BLOB to a file (*.bmp).
            FileStream stream;
            // Streams the BLOB to the FileStream object.
            BinaryWriter writer;
            // Size of the BLOB buffer.
            int bufferSize = 100;
            // The BLOB byte[] buffer to be filled by GetBytes.
            byte[] outByte = new byte[bufferSize];
            // The bytes returned from GetBytes.
            long retval;
            // The starting position in the BLOB output.
            long startIndex = 0;
            // The publisher id to use in the file name.
            int id;
            int idProject;
            string mail;

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                // Get the publisher id, which must occur before getting the logo.
                id = reader.GetInt32(0);

                // Create a file to hold the output.
                stream = new FileStream("Audio" + id + ".bmp", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryWriter(stream);

                // Reset the starting byte for the new BLOB.
                startIndex = 0;

                // Read bytes into outByte[] and retain the number of bytes returned.
                retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    writer.Write(outByte);
                    writer.Flush();

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
                }

                // Write the remaining buffer.
                writer.Write(outByte, 0, (int)retval - 1);
                writer.Flush();

                // Close the output file.
                string path = Directory.GetCurrentDirectory();
                writer.Close();
                stream.Close();
                idProject = reader.GetInt32(2);
                mail = reader.GetString(11);
                reporterAssist.AddVideo(id, path, idProject, mail);
            }
            reader.Close();
            conn.Close();
        }

        static void AddTimeStamps(SqlConnection conn)
        {
            int idAudio, idProject;
            string mail;
            double timestamp;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TIMESTAMP AS TI INNER JOIN " +
                "Audio AS A ON TI.Audio_idAudio = A.idAudio INNER JOIN Trabalho AS T " +
                "ON A.Trabalho_idTrabalho = T.idTrabalho INNER JOIN PROFISSIONAL AS " +
                "P ON T.Profissional_idProfissional = P.idProfissional", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                timestamp = reader.GetDouble(0);
                idAudio = reader.GetInt32(1);
                idProject = reader.GetInt32(4);
                mail = reader.GetString(13);
                float time = (float)timestamp;
                reporterAssist.AddTimeStamp(time, idAudio, idProject, mail);
            }
            reader.Close();
            conn.Close();
        }

        static void AddCoordinates(SqlConnection conn)
        {
            int idProject;
            string mail;
            double lat, lon;
            DateTime date;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Coordenada AS C " +
                "INNER JOIN Trabalho AS T " +
                "ON C.Trabalho_idTrabalho = T.idTrabalho " +
                "INNER JOIN Profissional AS P " +
                "ON T.Profissional_idProfissional = P.idProfissional", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                idProject = reader.GetInt32(0);
                lat = reader.GetDouble(1);
                lon = reader.GetDouble(2);
                date = reader.GetDateTime(3);
                mail = reader.GetString(12);
                float lat1 = (float)lat;
                float lon1 = (float)lon;
                reporterAssist.AddCoordinate(idProject, lat1, lon1, date, mail);
            }
            reader.Close();
            conn.Close();
        }

		public ReporterAssist ReporterAssist
		{
			get
			{
				return reporterAssist;
			}
		}
    }
}
