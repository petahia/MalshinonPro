using MalshinonPro.UI;
using MySql.Data.MySqlClient;
using Console = System.Console;

namespace MalshinonPro.DAL
{
    public class ReportsDAL
    {
        static string connectionString =
            "server=localhost;" +
            "user=root;" +
            "database=Malshinon;" +
            "port=3306;";

        static MySqlConnection connection = new MySqlConnection(connectionString);

        internal static void InsertReport(Dictionary<string, object> rportParameters)
        {
            string query = "INSERT INTO Reports (TimeReported, SourceReporterID, TargetRepotedID, ReportBody) VALUES (@TimeReported, @SourceReporterID,@TargetRepotedID,@ReportBody)";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var pair in rportParameters)
                {
                    command.Parameters.AddWithValue($"@{pair.Key}", pair.Value);
                }

                command.ExecuteNonQuery();
                connection.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                }
            }

        }
    }
}


