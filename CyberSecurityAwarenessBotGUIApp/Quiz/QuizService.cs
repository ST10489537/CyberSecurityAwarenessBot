using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Quiz
{
    // Loads and provides all quiz questions for the cybersecurity quiz
    public class QuizService
    {
        public List<QuizQuestion> Questions { get; private set; }

        public QuizService()
        {
            Questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "A) Reply with your password", "B) Delete the email", "C) Report it as phishing", "D) Ignore it" },
                    CorrectAnswer = 2,
                    Explanation = "Always report phishing emails to help protect others."
                },
                new QuizQuestion
                {
                    Question = "Which of the following is the strongest password?",
                    Options = new List<string> { "A) password123", "B) John1990", "C) P@ssw0rd!", "D) Xk#9mL!2vQ$" },
                    CorrectAnswer = 3,
                    Explanation = "Long passwords with mixed characters are hardest to crack."
                },
                new QuizQuestion
                {
                    Question = "What does 2FA stand for?",
                    Options = new List<string> { "A) Two-Factor Authentication", "B) Two-File Access", "C) Trusted Firewall Application", "D) None of the above" },
                    CorrectAnswer = 0,
                    Explanation = "2FA adds an extra layer of security beyond just a password."
                },
                new QuizQuestion
                {
                    Question = "True or False: Public Wi-Fi is safe to use for online banking.",
                    Options = new List<string> { "A) True", "B) False" },
                    CorrectAnswer = 1,
                    Explanation = "Public Wi-Fi can be intercepted. Use a VPN or mobile data for banking."
                },
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string> { "A) A type of malware", "B) A trick to steal personal info via fake messages", "C) A firewall technique", "D) Safe browsing software" },
                    CorrectAnswer = 1,
                    Explanation = "Phishing uses deceptive emails/sites to steal your credentials."
                },
                new QuizQuestion
                {
                    Question = "How often should you update your passwords?",
                    Options = new List<string> { "A) Never", "B) Every 5 years", "C) Every 3–6 months", "D) Only when hacked" },
                    CorrectAnswer = 2,
                    Explanation = "Regular password changes reduce the risk of unauthorised access."
                },
                new QuizQuestion
                {
                    Question = "What should you check before clicking a link in an email?",
                    Options = new List<string> { "A) The email font", "B) The sender's address and URL", "C) The email subject only", "D) Nothing, just click" },
                    CorrectAnswer = 1,
                    Explanation = "Always verify sender and hover over links before clicking."
                },
                new QuizQuestion
                {
                    Question = "True or False: Antivirus software eliminates all cyber threats.",
                    Options = new List<string> { "A) True", "B) False" },
                    CorrectAnswer = 1,
                    Explanation = "Antivirus helps but cannot catch every threat — good habits matter too."
                },
                new QuizQuestion
                {
                    Question = "What is social engineering in cybersecurity?",
                    Options = new List<string> { "A) Building secure networks", "B) Manipulating people to reveal confidential info", "C) Installing firewalls", "D) Encrypting data" },
                    CorrectAnswer = 1,
                    Explanation = "Social engineering exploits human psychology, not technical vulnerabilities."
                },
                new QuizQuestion
                {
                    Question = "Which action best protects your online accounts?",
                    Options = new List<string> { "A) Using the same password everywhere", "B) Sharing passwords with trusted friends", "C) Enabling 2FA and using unique passwords", "D) Writing passwords on sticky notes" },
                    CorrectAnswer = 2,
                    Explanation = "Unique passwords + 2FA is the gold standard for account security."
                },
                new QuizQuestion
                {
                    Question = "What is ransomware?",
                    Options = new List<string> { "A) Software that speeds up your PC", "B) Malware that encrypts files and demands payment", "C) A type of antivirus", "D) A browser extension" },
                    CorrectAnswer = 1,
                    Explanation = "Ransomware locks your data and demands a ransom to restore it."
                }
            };
        }
    }
}
