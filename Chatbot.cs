using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace CyberSecurityAwarenessBot
{
    public class Chatbot
    {
        private User? user;
        private ResponseHandler responseHandler;

        public Chatbot()
        {
            responseHandler = new ResponseHandler();
        }

        public void Start()
        {
            UIHelper.DisplayHeader();

            // Play voice greeting
            UIHelper.PlayGreeting();

            // Ask for user name
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                name = Console.ReadLine();
            }

            user = new User(name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nHello {user.Name}! Welcome to the Cybersecurity Awareness Bot.");
            Console.ResetColor();

            RunChat();
        }

        private void RunChat()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine() ?? "";

                // Input validation
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please enter a valid message.");
                    continue;
                }

                // Exit condition
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Bot: Goodbye! Stay safe online.");
                    break;
                }

                // Get response
                string response = responseHandler.GetResponse(input, user.Name);

                // Typing effect
                UIHelper.TypeEffect("Bot: " + response);
            }
        }
    }
}
