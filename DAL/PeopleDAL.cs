using MalshinonPro.UI;
using MySql.Data.MySqlClient;
using Console = System.Console;
using  MalshinonPro.DataBase;

namespace MalshinonPro.DAL
{
    internal class PeopleDAL
    {
        static string connectionString =
            "server=localhost;" +
            "user=root;" +
            "database=Malshinon;" +
            "port=3306;";

        static MySqlConnection connection = new MySqlConnection(connectionString);
        internal static void InsertSource(Dictionary<string,object> sourceParameters)
        {
            string query =
                "INSERT INTO People (SecretCode, Name, Type,Title) VALUES (@SecretCode, @Name, @Type,@Title)";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var pair in sourceParameters)
                {
                    command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static int AnalaisisSource(int SourceReportID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query =
                @"SELECT AVG(LENGTH(Description)) AS AvgLength FROM Reports WHERE ReporterId = @SourceReportID AND Description IS NOT NULL;";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int totalChars = 0;
            while (reader.Read())
            {
                totalChars = reader.GetInt32(4);
                reader.Close();
            }
            connection.Close();

            return totalChars;
        }
        
        internal static void UpdateTitle(Dictionary<string,object> newTitle,int sourceSecretCode)
        {
            string query =
                "UPDATE Reports SET Title = Agent WHERE Id = sourceSecretCode;";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var pair in newTitle)
                {
                    command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                }
                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


