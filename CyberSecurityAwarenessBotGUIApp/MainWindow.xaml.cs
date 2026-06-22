using CyberSecurityAwarenessBotGUIApp.Database;
using CyberSecurityAwarenessBotGUIApp.Logs;
using CyberSecurityAwarenessBotGUIApp.Models;
using CyberSecurityAwarenessBotGUIApp.Quiz;
using CyberSecurityAwarenessBotGUIApp.Services;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityAwarenessBotGUIApp
{
    public partial class MainWindow : Window
    {
        // ── Services ──────────────────────────────────────────────
        private readonly ChatbotEngine _chatbotEngine = new();
        private readonly QuizService _quizService = new();
        private readonly TaskDatabaseService _taskDbService = new();
        private readonly ActivityLogService _activityLog = new();

        // ── Quiz state ────────────────────────────────────────────
        private int _currentQuestion = 0;
        private int _quizScore = 0;

        // ── Constructor ───────────────────────────────────────────
        public MainWindow()
        {
            InitializeComponent();

            // Initialise the MySQL database (creates table if needed)
            DatabaseService.InitialiseDatabase();

            // Load the first quiz question
            LoadQuestion();

            // Play the welcome voice greeting
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/Greeting.wav.wav");
                player.Play();
            }
            catch
            {
                // Greeting file missing — continue without audio
            }

            // Show the initial bot message in the chat tab
            ChatDisplay.Text = "Bot: Hello! Welcome to the Cybersecurity Awareness Bot.\nPlease type 'My name is ...' to begin.";

            // Log the startup action
            _activityLog.Log("Application started.");
        }

        // ── CHAT TAB ──────────────────────────────────────────────

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = UserInputTextBox.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            // Display the user's message
            ChatDisplay.Text += $"\n\nYou: {userInput}";

            // Get the bot's response
            string botResponse = _chatbotEngine.GetResponse(userInput);

            // Handle special signal to show activity log inline
            if (botResponse == "__SHOW_LOG__")
            {
                var logs = _activityLog.GetRecentLogs();
                botResponse = "Here are your recent actions:\n" + string.Join("\n", logs);
            }

            // Display the bot's response
            ChatDisplay.Text += $"\n\nBot: {botResponse}";

            // Log the chat interaction
            _activityLog.Log($"Chat: User asked about '{userInput}'.");

            // Clear the input box and refocus
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow sending messages by pressing Enter
            if (e.Key == Key.Enter)
                SendButton_Click(sender, e);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Text = "Bot: Chat cleared. You can continue asking cybersecurity questions.";
            _activityLog.Log("Chat window cleared.");
        }

        // ── TASK ASSISTANT TAB ────────────────────────────────────

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleBox.Text.Trim();
            string description = TaskDescriptionBox.Text.Trim();
            string reminder = ReminderDatePicker.SelectedDate?.ToString("yyyy-MM-dd") ?? "";

            // Validate that a title was entered
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Build the task object and save it to the database
            var task = new TaskItem
            {
                Title = title,
                Description = string.IsNullOrEmpty(description) ? "No description provided." : description,
                ReminderDate = string.IsNullOrEmpty(reminder) ? null : reminder,
                IsCompleted = false
            };

            _taskDbService.AddTask(task);

            // Log the action
            string logMsg = string.IsNullOrEmpty(reminder)
                ? $"Task added: '{title}' (no reminder)."
                : $"Task added: '{title}' with reminder on {reminder}.";
            _activityLog.Log(logMsg);

            // Refresh the task grid and clear inputs
            RefreshTaskGrid();
            TaskTitleBox.Clear();
            TaskDescriptionBox.Clear();
            ReminderDatePicker.SelectedDate = null;

            MessageBox.Show($"Task '{title}' added successfully!", "Task Added", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Loads all tasks from the DB and binds them to the DataGrid
        private void RefreshTaskGrid()
        {
            TaskGrid.ItemsSource = null;
            TaskGrid.ItemsSource = _taskDbService.GetAllTasks();
        }

        // ── QUIZ TAB ──────────────────────────────────────────────

        private void LoadQuestion()
        {
            // Check if all questions have been answered
            if (_currentQuestion >= _quizService.Questions.Count)
            {
                string result = _quizScore >= 8 ? "🏆 Excellent! You're a cybersecurity pro!" :
                                _quizScore >= 5 ? "👍 Good effort! Keep learning to stay safe." :
                                                  "📚 Keep studying — cybersecurity knowledge saves you!";

                QuizQuestionText.Text = $"Quiz Complete!\nFinal Score: {_quizScore}/{_quizService.Questions.Count}\n\n{result}";
                QuizAnswers.Items.Clear();
                _activityLog.Log($"Quiz completed. Score: {_quizScore}/{_quizService.Questions.Count}.");
                return;
            }

            // Display the current question and its options
            var question = _quizService.Questions[_currentQuestion];
            QuizQuestionText.Text = $"Q{_currentQuestion + 1}: {question.Question}";
            QuizAnswers.Items.Clear();

            foreach (string option in question.Options)
                QuizAnswers.Items.Add(option);

            QuizFeedback.Text = "";
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (QuizAnswers.SelectedIndex == -1)
            {
                QuizFeedback.Text = "Please select an answer before submitting.";
                return;
            }

            var question = _quizService.Questions[_currentQuestion];

            // Check if the selected answer is correct
            if (QuizAnswers.SelectedIndex == question.CorrectAnswer)
            {
                _quizScore++;
                QuizFeedback.Text = "✅ Correct! " + question.Explanation;
            }
            else
            {
                QuizFeedback.Text = "❌ Incorrect. " + question.Explanation;
            }

            // Log quiz answer
            _activityLog.Log($"Quiz Q{_currentQuestion + 1} answered.");

            _currentQuestion++;
            LoadQuestion();
        }

        // ── ACTIVITY LOG TAB ─────────────────────────────────────

        private void RefreshLog_Click(object sender, RoutedEventArgs e)
        {
            // Clear and reload the activity log list
            ActivityLogList.Items.Clear();

            var logs = _activityLog.GetRecentLogs(10);

            if (logs.Count == 0)
            {
                ActivityLogList.Items.Add("No activity recorded yet.");
                return;
            }

            foreach (string entry in logs)
                ActivityLogList.Items.Add(entry);
        }
    }
}