using CyberSecurityAwarenessBotGUIApp.Models;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Main chatbot response engine.
    public class ChatbotEngine
    {
        private readonly Random _random = new Random();

        private readonly ChatMemory _memory = new ChatMemory();

        private readonly SentimentDetector _sentimentDetector = new SentimentDetector();

        // Cybersecurity responses.
        private readonly Dictionary<string, List<string>> _responses =
            new Dictionary<string, List<string>>
        {
            {
                "password",
                new List<string>
                {
                    "Use strong passwords with numbers, symbols, and uppercase letters.",
                    "Avoid using your birthday or name in passwords.",
                    "Use a password manager for safer password storage."
                }
            },

            {
                "phishing",
                new List<string>
                {
                    "Do not click suspicious email links.",
                    "Always verify the sender before opening attachments.",
                    "Phishing attacks often create panic or urgency."
                }
            },

            {
                "scam",
                new List<string>
                {
                    "Be careful of online prize scams.",
                    "Never share banking details with unknown people.",
                    "If something seems too good to be true, it probably is."
                }
            },

            {
                "privacy",
                new List<string>
                {
                    "Review your social media privacy settings regularly.",
                    "Do not share sensitive personal information online.",
                    "Enable two-factor authentication whenever possible."
                }

            },

            {
    "browsing",
    new List<string>
    {
        "Only enter personal information on secure HTTPS websites.",
        "Avoid downloading files from unknown websites.",
        "Keep your browser updated for better security and protection."
    }
},
            {
    "2fa",
    new List<string>
    {
        "Two-factor authentication adds an extra layer of protection to your accounts.",
        "2FA helps protect your account even if your password gets stolen.",
        "Using an authentication app is safer than SMS verification where possible."
    }
},

            {
    "malware",
    new List<string>
    {
        "Install trusted antivirus software to help detect malware threats.",
        "Avoid downloading cracked or pirated software because it may contain malware.",
        "Keep your operating system updated to reduce malware vulnerabilities."
    }
}

        };

        // Generates chatbot responses.
        public string GetResponse(string userInput)
        {
            // Prevents empty messages.
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a message first.";

            string input = userInput.ToLower();

            string sentiment = _sentimentDetector.Detect(input);

            // Stores user's name.
            if (input.StartsWith("my name is"))
            {
                _memory.UserName =
                    userInput.Replace("my name is", "", StringComparison.OrdinalIgnoreCase).Trim();

                return $"Nice to meet you, {_memory.UserName}.";
            }

            // Remembers favourite topic.
            if (input.Contains("interested in"))
            {
                foreach (string topic in _responses.Keys)
                {
                    if (input.Contains(topic))
                    {
                        _memory.FavouriteTopic = topic;
                        _memory.LastTopic = topic;

                        return $"I will remember that you are interested in {topic}.";
                    }
                }
            }

            // Follow-up conversation.
            if (input.Contains("tell me more") || input.Contains("another tip"))
            {
                if (!string.IsNullOrEmpty(_memory.LastTopic))
                    return GetRandomResponse(_memory.LastTopic);

                return "Please first ask me about a cybersecurity topic.";
            }

            // Keyword recognition.
            foreach (string topic in _responses.Keys)
            {
                if (input.Contains(topic))
                {
                    _memory.LastTopic = topic;

                    string response = GetRandomResponse(topic);

                    // Sentiment-based responses.
                    if (sentiment == "worried")
                        return "It is understandable to feel worried. " + response;

                    if (sentiment == "frustrated")
                        return "I understand your frustration. " + response;

                    if (sentiment == "curious")
                        return "That is great to be curious about. " + response;

                    return response;
                }
            }

            // Memory recall.
            if (input.Contains("what do you know about me"))
            {
                return $"Your name is {_memory.UserName} and you are interested in {_memory.FavouriteTopic}.";
            }

            // Default response.
            return "I can help with passwords, phishing, scams, and privacy.";
        }

        // Selects a random response.
        private string GetRandomResponse(string topic)
        {
            List<string> topicResponses = _responses[topic];

            int index = _random.Next(topicResponses.Count);

            return topicResponses[index];
        }
    }
}