using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Threading;

namespace CyberSecurityAwarenessBot
{
    public static class UIHelper
    {
        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("=======================================");
            Console.WriteLine("   CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("=======================================");

            // ASCII Art
            Console.WriteLine(@"
     [  SAFE  ]
    /---------\
   |  🔒 🔒 🔒 |
    \---------/
            ");

            Console.ResetColor();
        }

        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/greeting.wav");
                player.PlaySync();
            }
            catch
            {
                Console.WriteLine("Audio file not found.");
            }
        }

        public static void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20); // typing effect
            }
            Console.WriteLine();
        }
    }
}
