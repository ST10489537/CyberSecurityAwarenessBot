using CyberSecurityAwarenessBotGUIApp.Database;
using CyberSecurityAwarenessBotGUIApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Handles all CRUD operations for tasks stored in MySQL
    public class TaskDatabaseService
    {
        // Adds a new task to the database
        public void AddTask(TaskItem task)
        {
            try
            {
                using var connection = DatabaseService.GetConnection();
                string query = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@title, @desc, @reminder, 0)";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@desc", task.Description);
                cmd.Parameters.AddWithValue("@reminder", task.ReminderDate ?? "");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddTask Error: " + ex.Message);
            }
        }

        // Retrieves all tasks from the database
        public List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();
            try
            {
                using var connection = DatabaseService.GetConnection();
                string query = "SELECT * FROM Tasks";
                using var cmd = new MySqlCommand(query, connection);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Description = reader.GetString("Description"),
                        ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate")) ? null : reader.GetString("ReminderDate"),
                        IsCompleted = reader.GetInt32("IsCompleted") == 1
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAllTasks Error: " + ex.Message);
            }
            return tasks;
        }

        // Marks a task as completed by its ID
        public void MarkCompleted(int id)
        {
            try
            {
                using var connection = DatabaseService.GetConnection();
                string query = "UPDATE Tasks SET IsCompleted = 1 WHERE Id = @id";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("MarkCompleted Error: " + ex.Message);
            }
        }

        // Deletes a task by its ID
        public void DeleteTask(int id)
        {
            try
            {
                using var connection = DatabaseService.GetConnection();
                string query = "DELETE FROM Tasks WHERE Id = @id";
                using var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteTask Error: " + ex.Message);
            }
        }
    }
}