using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReminderDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
