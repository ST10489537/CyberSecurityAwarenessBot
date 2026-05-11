using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Detects simple emotions from the user's message.
    public class SentimentDetector
    {
        public string Detect(string input)
        {
            // Converts input to lowercase.
            input = input.ToLower();

            // Detects worried emotions.
            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";

            // Detects frustration.
            if (input.Contains("frustrated") || input.Contains("angry"))
                return "frustrated";

            // Detects curiosity.
            if (input.Contains("curious") || input.Contains("interested"))
                return "curious";

            // Default emotion.
            return "neutral";
        }
    }
}
