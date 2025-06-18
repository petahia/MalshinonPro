using MalshinonPro.UI;
using MySql.Data.MySqlClient;
using Console = System.Console;
using  MalshinonPro.DataBase;


namespace MalshinonPro.DAL
{
    public class AlertsDAL
    {
        static string connectionString =
            "server=localhost;" +
            "user=root;" +
            "database=Malshinon;" +
            "port=3306;";

        static MySqlConnection connection = new MySqlConnection(connectionString);
        public static int Alert(int SourceReportID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query =
                @"SELECT AVG(LENGTH(Description)) AS AvgLength FROM Reports WHERE SourceReportID = @SourceReportID AND Description IS NOT NULL;";

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int totalChars = 0;
            while (reader.Read())
            {
                totalChars = reader.GetInt32("ReportBody");
                reader.Close();
            }
            connection.Close();

            return totalChars;
        }
    }
}

