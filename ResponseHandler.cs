using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBot
{
    public class ResponseHandler
    {
        public string GetResponse(string input, string userName)
        {
            input = input.ToLower();

            // Basic responses
            if (input.Contains("how are you"))
                return "I am just a bot, but I am here to help you stay safe online!";

            if (input.Contains("purpose"))
                return "My purpose is to educate you about cybersecurity and keep you safe online.";

            if (input.Contains("what can i ask"))
                return "You can ask me about passwords, phishing, and safe browsing.";

            // Cybersecurity topics
            if (input.Contains("password"))
                return "Use strong passwords with letters, numbers, and symbols. Do not reuse passwords.";

            if (input.Contains("phishing"))
                return "Be careful of emails asking for personal info. Always verify the sender.";

            if (input.Contains("safe browsing"))
                return "Only visit trusted websites and avoid clicking suspicious links.";

            // Default response
            return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}
