using CyberSecurityAwarenessBotGUIApp.Quiz;
using CyberSecurityAwarenessBotGUIApp.Services;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityAwarenessBotGUIApp
{
    public partial class MainWindow : Window
    {
        // Quiz service
        private QuizService _quizService;

        // Current question index
        private int _currentQuestion = 0;

        // User score
        private int _quizScore = 0;
        private readonly ChatbotEngine _chatbotEngine = new ChatbotEngine();

        public MainWindow()
        {
            InitializeComponent();

            _quizService = new QuizService();

            LoadQuestion();


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

        private void LoadQuestion()
        {
            if (_currentQuestion >= _quizService.Questions.Count)
            {
                QuizQuestionText.Text =
                    $"Quiz Complete! Final Score: {_quizScore}/{_quizService.Questions.Count}";

                QuizAnswers.Items.Clear();

                return;
            }

            var question =
                _quizService.Questions[_currentQuestion];

            QuizQuestionText.Text =
                question.Question;

            QuizAnswers.Items.Clear();

            foreach (string option in question.Options)
            {
                QuizAnswers.Items.Add(option);
            }

            QuizFeedback.Text = "";
        }

    
private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (QuizAnswers.SelectedIndex == -1)
            {
                QuizFeedback.Text =
                    "Please select an answer.";

                return;
            }

            var question =
                _quizService.Questions[_currentQuestion];

            if (QuizAnswers.SelectedIndex ==
                question.CorrectAnswer)
            {
                _quizScore++;

                QuizFeedback.Text =
                    "Correct! " + question.Explanation;
            }
            else
            {
                QuizFeedback.Text =
                    "Incorrect. " + question.Explanation;
            }

            _currentQuestion++;

            LoadQuestion();
        }

    }
}