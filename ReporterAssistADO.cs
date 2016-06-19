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
        SqlConnection conn;

		ReportAssistADO(string ip)
		{
			SqlConnection conn = new SqlConnection("Server =." + ip + ";Database=reporterassist;UID=reporter;Password=a1912Adsma10321aM");
			conn.Open();

			AddUsers();
			AddProjects();
			AddTasks();
			AddAudios();
			AddImages();
			AddVideos();
			AddTimeStamps();
			AddCoordinates();

		}

        private void AddUsers()
        {
            int id;
            string name, mail, password;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Profissional", conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
            while (reader.Read())
            {
                name = reader.GetString(0);
                mail = reader.GetString(1);
                password = reader.GetString(2);
                id = reader.GetInt32(3);
                reporterAssist.AddUser(mail, password, name);
            }
            reader.Close();
            conn.Close();
        }

        private void AddProjects()
        {
            int id;
            string title, note, type, mail;
            DateTime dateI, dateF;

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

				Project project = new Project(id, title, note, dateI, dateF, new State(type));

				reporterAssist.AddProject(project);
            }
            reader.Close();
            conn.Close();
        }

        private void AddTasks()
        {
            int id, idProject;
            string title, note, type, mail;

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

				Task task = new Task(id, title, note, new State(type));

                reporterAssist.AddTask(idProject, task);
            }
            reader.Close();
            conn.Close();
        }

        private void AddAudios()
        {

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
                reporterAssist.AddAudio(path, idProject);
            }
            reader.Close();
            conn.Close();
        }

        private void AddImages()
        {

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
                reporterAssist.AddImage(path, idProject);
            }
            reader.Close();
            conn.Close();
        }

        private void AddVideos()
        {

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
                reporterAssist.AddVideo(path, idProject);
            }
            reader.Close();
            conn.Close();
        }

        private void AddTimeStamps()
        {
            int idAudio, idProject;
            string mail;
            double timestamp;

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
                reporterAssist.AddTimeStamp(time, idAudio, idProject);
            }
            reader.Close();
            conn.Close();
        }

        private void AddCoordinates()
        {
            int idProject;
            string mail;
            double lat, lon;
            DateTime date;

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
                reporterAssist.AddCoordinate(idProject, lat1, lon1, date);
            }
            reader.Close();
            conn.Close();
        }
    }
}
