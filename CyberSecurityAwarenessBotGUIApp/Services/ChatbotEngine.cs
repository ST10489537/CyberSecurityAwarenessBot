using CyberSecurityAwarenessBotGUIApp.Models;
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBotGUIApp.Services
{
    // Main chatbot engine responsible for processing user input
    // and generating cybersecurity awareness responses.
    public class ChatbotEngine
    {
        // Used for selecting random responses.
        private readonly Random _random = new Random();

        // Stores user information and conversation memory.
        private readonly ChatMemory _memory = new ChatMemory();

        // Detects the user's sentiment.
        private readonly SentimentDetector _sentimentDetector =
            new SentimentDetector();

        // Cybersecurity knowledge base.
        // Each topic contains multiple responses so that
        // the chatbot can provide varied answers.
        private readonly Dictionary<string, List<string>> _responses =
            new Dictionary<string, List<string>>
        {
            {
                "password",
                new List<string>
                {
                    "Use strong passwords with numbers, symbols and uppercase letters.",
                    "Avoid using birthdays or names in passwords.",
                    "Use a password manager to store passwords securely."
                }
            },

            {
                "phishing",
                new List<string>
                {
                    "Do not click suspicious email links.",
                    "Always verify the sender before opening attachments.",
                    "Phishing attacks often create urgency or panic."
                }
            },

            {
                "scam",
                new List<string>
                {
                    "Be cautious of online prize scams.",
                    "Never share banking information with strangers.",
                    "If something sounds too good to be true, it probably is."
                }
            },

            {
                "privacy",
                new List<string>
                {
                    "Review your social media privacy settings regularly.",
                    "Avoid sharing sensitive personal information online.",
                    "Enable two-factor authentication whenever possible."
                }
            },

            {
                "browsing",
                new List<string>
                {
                    "Only enter personal information on HTTPS websites.",
                    "Avoid downloading files from unknown websites.",
                    "Keep your browser updated for better security."
                }
            },

            {
                "2fa",
                new List<string>
                {
                    "Two-factor authentication adds an extra layer of security.",
                    "2FA helps protect accounts even if passwords are stolen.",
                    "Authentication apps are generally safer than SMS verification."
                }
            },

            {
                "malware",
                new List<string>
                {
                    "Install trusted antivirus software.",
                    "Avoid downloading pirated software.",
                    "Keep your operating system updated."
                }
            },

            {
                "vpn",
                new List<string>
                {
                    "A VPN encrypts your internet traffic.",
                    "VPNs improve privacy when using public networks.",
                    "Choose a trusted VPN provider."
                }
            },

            {
                "ransomware",
                new List<string>
                {
                    "Ransomware locks files and demands payment.",
                    "Regular backups help protect against ransomware.",
                    "Never download files from untrusted sources."
                }
            },

            {
                "social engineering",
                new List<string>
                {
                    "Social engineering tricks people into revealing information.",
                    "Attackers often impersonate trusted individuals.",
                    "Always verify requests for sensitive information."
                }
            },

            {
                "wifi",
                new List<string>
                {
                    "Public Wi-Fi networks can expose your information.",
                    "Avoid online banking on public Wi-Fi.",
                    "Use a VPN when connecting to public networks."
                }
            }
        };

        // Main method that processes user input
        // and returns a chatbot response.
        public string GetResponse(string userInput)
        {
            // Prevent empty messages from being processed.
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please type a message first.";

            string input = userInput.ToLower();

            // Detect the user's sentiment.
            string sentiment =
                _sentimentDetector.Detect(input);

            // Stores the user's name in memory.
            if (input.StartsWith("my name is"))
            {
                _memory.UserName =
                    userInput.Replace(
                        "my name is",
                        "",
                        StringComparison.OrdinalIgnoreCase)
                    .Trim();

                return $"Nice to meet you, {_memory.UserName}.";
            }

            // Stores the user's favourite cybersecurity topic.
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

            // Allows users to ask for more information
            // about the previously discussed topic.
            if (input.Contains("tell me more") ||
                input.Contains("another tip"))
            {
                if (!string.IsNullOrEmpty(_memory.LastTopic))
                    return GetRandomResponse(_memory.LastTopic);

                return "Please first ask me about a cybersecurity topic.";
            }

            // =====================================================
            // PART 3 NLP (Natural Language Processing)
            // Handles different user commands and intentions.
            // =====================================================

            // Detect task-related requests.
            if (input.Contains("task") ||
                input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task"))
            {
                return "Please open the Task Assistant tab to manage your tasks.";
            }

            // Detect quiz-related requests.
            if (input.Contains("quiz") ||
                input.Contains("start quiz") ||
                input.Contains("cyber quiz"))
            {
                return "Please open the Cyber Quiz tab to begin the quiz.";
            }

            // Detect reminder-related requests.
            if (input.Contains("remind me") ||
                input.Contains("set reminder") ||
                input.Contains("reminder"))
            {
                return "Please use the Task Assistant tab to create a reminder.";
            }

            // Detect activity log requests.
            if (input.Contains("activity log") ||
                input.Contains("show log"))
            {
                return "Please open the Activity Log tab to view recent actions.";
            }

            // Searches for cybersecurity keywords
            // contained in the user's message.
            foreach (string topic in _responses.Keys)
            {
                if (input.Contains(topic))
                {
                    // Remember the last topic discussed.
                    _memory.LastTopic = topic;

                    string response =
                        GetRandomResponse(topic);

                    // Adjust responses based on the user's mood.
                    if (sentiment == "worried")
                        return "It is understandable to feel worried. " + response;

                    if (sentiment == "frustrated")
                        return "I understand your frustration. " + response;

                    if (sentiment == "curious")
                        return "That is great to be curious about. " + response;

                    return response;
                }
            }

            // Allows the chatbot to recall stored user information.
            if (input.Contains("what do you know about me"))
            {
                return $"Your name is {_memory.UserName} and you are interested in {_memory.FavouriteTopic}.";
            }

            // Default response if no keyword or command is recognised.
            return "I can help with passwords, phishing, scams, privacy, malware, ransomware, VPNs, public Wi-Fi safety, social engineering, reminders, tasks and cybersecurity quizzes.";
        }

        // Returns a random response for the selected topic.
        private string GetRandomResponse(string topic)
        {
            List<string> topicResponses =
                _responses[topic];

            int index =
                _random.Next(topicResponses.Count);

            return topicResponses[index];
        }
    }
}