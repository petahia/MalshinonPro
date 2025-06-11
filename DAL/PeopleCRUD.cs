using MalshinonPro.UI;
using MySql.Data.MySqlClient;
namespace MalshinonPro.DAL
{
    internal class PeopleCRUD
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
                "INSERT INTO People (SecretCode, Name, Type) VALUES (@SecretCode, @Name, @Type)";
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
    }
}

