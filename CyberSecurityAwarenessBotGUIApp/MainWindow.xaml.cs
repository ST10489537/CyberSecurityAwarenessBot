using CyberSecurityAwarenessBotGUIApp.Services;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityAwarenessBotGUIApp
{
    public partial class MainWindow : Window
    {
        private readonly ChatbotEngine _chatbotEngine = new ChatbotEngine();

        public MainWindow()
        {
            InitializeComponent();

            // Plays the voice greeting when the GUI opens.
            SoundPlayer player = new SoundPlayer("Assets/Greeting.wav.wav");
            player.Play();

            // Shows the first chatbot message.
            ChatDisplay.Text = "Bot: Hello! Welcome to the Cybersecurity Awareness Bot. Please type 'My name is ...' to begin.";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets what the user typed.
            string userInput = UserInputTextBox.Text.Trim();

            // Displays the user's message.
            ChatDisplay.Text += "\n\nYou: " + userInput;

            // Sends the user input to ChatbotEngine and receives the bot response.
            string botResponse = _chatbotEngine.GetResponse(userInput);

            // Displays the chatbot response.
            ChatDisplay.Text += "\n\nBot: " + botResponse;

            // Clears the input box after sending.
            UserInputTextBox.Clear();

            // Places the cursor back in the textbox.
            UserInputTextBox.Focus();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Sends the message when the Enter key is pressed.
            if (e.Key == Key.Enter)
            {
                SendButton_Click(sender, e);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Clears the chat window.
            ChatDisplay.Text = "Bot: Chat cleared. You can continue asking cybersecurity questions.";
        }
    }
}