using MySql.Data.MySqlClient;
using System;

namespace CyberSecurityAwarenessBotGUIApp.Database
{
    // Handles MySQL database connection and table setup
    public class DatabaseService
    {
        // Connection string — update the password to match your MySQL setup
        private const string ConnectionString =
            "Server=localhost;Database=cybersecurity_bot;Uid=root;Pwd=;";

        // Creates the tasks table if it doesn't already exist
        public static void InitialiseDatabase()
        {
            try
            {
                using var connection = new MySqlConnection(ConnectionString);
                connection.Open();

                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Title VARCHAR(200) NOT NULL,
                        Description TEXT,
                        ReminderDate VARCHAR(50),
                        IsCompleted TINYINT(1) DEFAULT 0
                    );";

                using var cmd = new MySqlCommand(createTable, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log the error — app continues even if DB is unavailable
                Console.WriteLine("DB Init Error: " + ex.Message);
            }
        }

        // Returns a new open MySQL connection for use in other services
        public static MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}