using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Core chatbot logic: handles NLP, keyword recognition, memory, and sentiment
    public class ChatbotEngine
    {
        private string _userName = "";
        private string _lastTopic = "";
        private string _interestTopic = "";

        private readonly SentimentDetector _sentimentDetector = new();
        private readonly Random _random = new();

        // Multi-response pools for varied replies
        private readonly List<string> _phishingTips = new()
        {
            "Be cautious of emails asking for personal information — scammers impersonate trusted brands.",
            "Check the sender's email address carefully before clicking any links.",
            "Hover over links before clicking to see the real destination URL.",
            "Legitimate organisations will never ask for your password via email."
        };

        private readonly List<string> _passwordTips = new()
        {
            "Use at least 12 characters combining uppercase, lowercase, numbers, and symbols.",
            "Never reuse passwords across different sites — use a password manager.",
            "Avoid using personal details like your name or birthday in passwords.",
            "Enable two-factor authentication wherever possible for extra security."
        };

        // Main method: processes user input and returns a bot response
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "I didn't catch that. Could you please type something?";

            string lower = input.ToLower().Trim();

            // --- Name capture ---
            if (lower.Contains("my name is"))
            {
                _userName = input.Substring(input.IndexOf("is", StringComparison.OrdinalIgnoreCase) + 3).Trim();
                return $"Nice to meet you, {_userName}! How can I help you stay safe online today?";
            }

            // --- Activity log trigger ---
            if (lower.Contains("show activity log") || lower.Contains("what have you done"))
                return "__SHOW_LOG__"; // Signal to MainWindow to display the log

            // --- Quiz trigger ---
            if (lower.Contains("quiz") || lower.Contains("test me"))
                return "Head over to the 'Cyber Quiz' tab to test your cybersecurity knowledge!";

            // --- Task trigger ---
            if (lower.Contains("add task") || lower.Contains("remind me") || lower.Contains("set reminder"))
                return "Sure! Head to the 'Task Assistant' tab to add a task or set a reminder.";

            // --- Follow-up / more info ---
            if (lower.Contains("tell me more") || lower.Contains("explain more") || lower.Contains("another tip"))
            {
                return _lastTopic switch
                {
                    "phishing" => _phishingTips[_random.Next(_phishingTips.Count)],
                    "password" => _passwordTips[_random.Next(_passwordTips.Count)],
                    _ => "Could you clarify which topic you'd like more on? E.g. phishing, passwords, privacy."
                };
            }

            // --- Sentiment detection ---
            string sentiment = _sentimentDetector.Detect(lower);
            string sentimentPrefix = sentiment switch
            {
                "worried" => "It's completely understandable to feel that way. Let me help. ",
                "frustrated" => "I hear you — cybersecurity can be overwhelming. Let's work through it. ",
                "curious" => "Great curiosity! Here's what you should know: ",
                _ => ""
            };

            // --- Keyword recognition ---
            if (lower.Contains("phishing"))
            {
                _lastTopic = "phishing";
                return sentimentPrefix + _phishingTips[_random.Next(_phishingTips.Count)];
            }

            if (lower.Contains("password"))
            {
                _lastTopic = "password";
                return sentimentPrefix + _passwordTips[_random.Next(_passwordTips.Count)];
            }

            if (lower.Contains("privacy"))
            {
                _lastTopic = "privacy";
                _interestTopic = "privacy";
                string name = string.IsNullOrEmpty(_userName) ? "you" : _userName;
                return $"{sentimentPrefix}Privacy is crucial online, {name}. Review your social media privacy settings regularly and avoid oversharing personal information.";
            }

            if (lower.Contains("scam") || lower.Contains("fraud"))
            {
                _lastTopic = "scam";
                return sentimentPrefix + "Scammers often create urgency to pressure you. If something feels off, trust your instincts and verify through official channels.";
            }

            if (lower.Contains("malware") || lower.Contains("virus"))
            {
                _lastTopic = "malware";
                return sentimentPrefix + "Keep your antivirus updated and avoid downloading files from untrusted sources. Regularly back up your data.";
            }

            if (lower.Contains("vpn"))
                return "A VPN (Virtual Private Network) encrypts your internet traffic, making it harder for hackers to intercept your data — especially on public Wi-Fi.";

            if (lower.Contains("two-factor") || lower.Contains("2fa"))
                return "Two-Factor Authentication adds a second verification step beyond your password. Enable it on all your important accounts!";

            if (lower.Contains("how are you"))
                return "I'm running smoothly and ready to help you stay safe online!";

            if (lower.Contains("purpose") || lower.Contains("what can you do"))
                return "I'm your Cybersecurity Awareness Bot. Ask me about phishing, passwords, scams, privacy, malware, VPNs, and more!";

            // --- Memory recall ---
            if (!string.IsNullOrEmpty(_interestTopic) && lower.Contains(_interestTopic))
                return $"As someone interested in {_interestTopic}, remember to regularly audit your account permissions and use strong, unique passwords.";

            // --- Default fallback ---
            return "I'm not sure I understand. Try asking about phishing, passwords, scams, privacy, malware, or 2FA.";
        }
    }
}