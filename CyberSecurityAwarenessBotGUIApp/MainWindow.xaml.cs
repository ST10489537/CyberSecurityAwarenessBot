using System.Media;
using System.Windows;

namespace CyberSecurityAwarenessBotGUIApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Plays the voice greeting when the GUI opens.
            SoundPlayer player = new SoundPlayer("Assets/Greeting.wav.wav");
            player.Play();

            // Shows the first chatbot message.
            ChatDisplay.Text = "Bot: Hello! Welcome to the Cybersecurity Awareness Bot. Please type your name to begin.";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets what the user typed.
            string userInput = UserInputTextBox.Text.Trim();

            // Checks for empty input.
            if (string.IsNullOrWhiteSpace(userInput))
            {
                ChatDisplay.Text += "\n\nBot: Please type something so I can assist you.";
                return;
            }

            // Displays the user's message.
            ChatDisplay.Text += "\n\nYou: " + userInput;

            // Temporary response for now.
            ChatDisplay.Text += "\n\nBot: Thank you. I will respond to cybersecurity questions about passwords, phishing, scams, privacy, and safe browsing.";

            // Clears the textbox.
            UserInputTextBox.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clears the chat display.
            ChatDisplay.Text = "Bot: Chat cleared. You can continue asking cybersecurity questions.";
        }
    }
}