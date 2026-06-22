using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Detects basic user sentiment from their message
    public class SentimentDetector
    {
        // Returns the detected sentiment: "worried", "frustrated", "curious", or "neutral"
        public string Detect(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid") || input.Contains("nervous"))
                return "worried";

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed") || input.Contains("hate"))
                return "frustrated";

            if (input.Contains("curious") || input.Contains("interesting") || input.Contains("want to know") || input.Contains("tell me more"))
                return "curious";

            return "neutral";
        }
    }
}
