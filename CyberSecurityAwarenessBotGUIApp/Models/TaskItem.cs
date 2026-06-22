using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Models
{
    // Represents a single cybersecurity task the user creates
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? ReminderDate { get; set; }   
        public bool IsCompleted { get; set; }        
    }
}
