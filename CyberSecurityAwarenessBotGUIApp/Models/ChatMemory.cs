using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Models
{
    // Stores information the chatbot remembers during the conversation.
    public class ChatMemory
    {
        // Stores the user's name.
        public string UserName { get; set; } = string.Empty;

        // Stores the user's favourite cybersecurity topic.
        public string FavouriteTopic { get; set; } = string.Empty;

        // Stores the last topic discussed.
        public string LastTopic { get; set; } = string.Empty;
    }
}
