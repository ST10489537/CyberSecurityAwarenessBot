using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Quiz
{
    public class QuizService
    {
        public List<QuizQuestion> Questions { get; set; }

        public QuizService()
        {
            Questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new[]
                    {
                        "A type of fishing",
                        "A scam to steal information",
                        "A computer game",
                        "A password manager"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Phishing is a scam designed to steal sensitive information."
                },

                new QuizQuestion
                {
                    Question = "Which password is strongest?",
                    Options = new[]
                    {
                        "password123",
                        "12345678",
                        "P@ssw0rd!",
                        "T#9kL@7zQ!2"
                    },
                    CorrectAnswer = 3,
                    Explanation = "Long, complex passwords are more secure."
                },

                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    Options = new[]
                    {
                        "Two-Factor Authentication",
                        "Two File Access",
                        "Fast Access",
                        "Two Form Approval"
                    },
                    CorrectAnswer = 0,
                    Explanation = "2FA adds an extra layer of security."
                },

                new QuizQuestion
                {
                    Question = "What should you do with suspicious emails?",
                    Options = new[]
                    {
                        "Open attachments",
                        "Reply immediately",
                        "Report or delete them",
                        "Forward them"
                    },
                    CorrectAnswer = 2,
                    Explanation = "Suspicious emails should be reported or deleted."
                },

                new QuizQuestion
                {
                    Question = "What is malware?",
                    Options = new[]
                    {
                        "Security software",
                        "Malicious software",
                        "Email software",
                        "A browser"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Malware is software designed to damage systems."
                },

                new QuizQuestion
                {
                    Question = "Is public Wi-Fi always safe?",
                    Options = new[]
                    {
                        "Yes",
                        "No",
                        "Only at airports",
                        "Only with Windows"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Public Wi-Fi can expose your data."
                },

                new QuizQuestion
                {
                    Question = "What is social engineering?",
                    Options = new[]
                    {
                        "Building websites",
                        "Manipulating people to reveal information",
                        "Coding software",
                        "Computer repair"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Social engineering exploits human trust."
                },

                new QuizQuestion
                {
                    Question = "Why should software be updated?",
                    Options = new[]
                    {
                        "For security patches",
                        "To slow down the PC",
                        "To remove files",
                        "To change passwords"
                    },
                    CorrectAnswer = 0,
                    Explanation = "Updates often fix security vulnerabilities."
                },

                new QuizQuestion
                {
                    Question = "What is ransomware?",
                    Options = new[]
                    {
                        "A backup tool",
                        "A type of malware that locks files",
                        "An antivirus",
                        "A firewall"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Ransomware encrypts files and demands payment."
                },

                new QuizQuestion
                {
                    Question = "Why are backups important?",
                    Options = new[]
                    {
                        "To recover lost data",
                        "To increase viruses",
                        "To reduce storage",
                        "To disable software"
                    },
                    CorrectAnswer = 0,
                    Explanation = "Backups help restore important information."
                },

                new QuizQuestion
                {
                    Question = "What is identity theft?",
                    Options = new[]
                    {
                        "Stealing hardware",
                        "Using someone's personal information fraudulently",
                        "Deleting files",
                        "Installing updates"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Identity theft involves misuse of personal information."
                },

                new QuizQuestion
                {
                    Question = "What should you do before clicking a link?",
                    Options = new[]
                    {
                        "Click immediately",
                        "Verify the source",
                        "Share it",
                        "Ignore it"
                    },
                    CorrectAnswer = 1,
                    Explanation = "Always verify links before clicking."
                }
            };
        }
    }
}
