# Cybersecurity Awareness Bot

## Student Details
Student Number: ST10489537  
Module: PROG6221 Programming 2A  
Assessment: Portfolio of Evidence - Part 1, Part 2, and Part 3 (POE)

## Project Description
This project is a Cybersecurity Awareness Chatbot developed in C# using WPF. The chatbot is designed to educate South African citizens about cybersecurity topics such as password safety, phishing, scams, privacy, safe browsing, two-factor authentication, and malware awareness.

## Part 1 Features
- Console-based chatbot foundation
- Voice greeting
- ASCII cybersecurity logo/banner
- Personalised user greeting
- Basic cybersecurity responses
- Input validation
- Structured classes and methods
- GitHub version control and CI via GitHub Actions

## Part 2 Features
- WPF graphical user interface
- Voice greeting on application startup
- Cybersecurity-themed GUI design
- Keyword recognition
- Random cybersecurity responses
- Conversation flow using follow-up prompts
- Memory and recall
- Sentiment detection
- Error handling for empty or unknown input
- Object-oriented code structure using Models and Services

## Part 3 Features (POE)
- **Task Assistant** — Add, view, and manage cybersecurity-related tasks with optional reminder dates
- **MySQL Database Integration** — Tasks are stored and retrieved from a local MySQL database
- **Cybersecurity Quiz** — 11 multiple-choice and true/false questions covering key cybersecurity topics
- **Score Tracking** — Quiz tracks correct answers and gives feedback at the end
- **NLP Simulation** — Chatbot recognises varied phrasings using keyword detection and string manipulation
- **Activity Log** — Records all key actions (tasks added, quiz attempts, chat interactions) with timestamps
- **Sentiment Detection** — Detects worried, frustrated, or curious tone and adjusts responses accordingly
- **Full Feature Integration** — All Part 1, 2, and 3 features accessible from the same tabbed GUI

## Cybersecurity Topics Covered
- Password safety
- Phishing
- Scams and fraud
- Privacy
- Safe browsing
- Two-factor authentication (2FA)
- Malware and ransomware
- VPNs
- Social engineering

## Prerequisites
- Visual Studio 2022
- .NET 6 or later
- MySQL Server 8.4 (local)
- MySql.Data NuGet package

## Database Setup
1. Open MySQL Workbench or MySQL Command Line Client
2. Run the following command to create the database:
```sql
CREATE DATABASE IF NOT EXISTS cybersecurity_bot;
```
3. The application will automatically create the `Tasks` table on first launch
4. Update the connection string in `Database/DatabaseService.cs` if your MySQL password differs:
```csharp
"Server=localhost;Database=cybersecurity_bot;Uid=root;Pwd=YourPasswordHere;"
```

## How to Run the Project
1. Clone or download the GitHub repository
2. Open the solution in Visual Studio
3. Set `CyberSecurityAwarenessBotGUIApp` as the startup project
4. Install the `MySql.Data` NuGet package if not already installed
5. Make sure the audio file is located in the `Assets` folder
6. Set up the MySQL database (see Database Setup above)
7. Build the solution (`Ctrl + Shift + B`)
8. Run the application (`F5`)

## How to Use Each Tab

### Chat Tab
Type a message and press Send or Enter. The bot responds to cybersecurity topics.

### Task Assistant Tab
- Enter a task title and optional description
- Pick a reminder date using the date picker
- Click **Add Task** to save it to the database

### Cyber Quiz Tab
- Read each question and select an answer from the list
- Click **Submit Answer** for immediate feedback
- Your final score is shown after all questions

### Activity Log Tab
- Click **Refresh Activity Log** to see the last 10 actions the bot has taken
- Includes timestamps for each action

## Example Questions to Ask the Bot
- My name is Nkosana
- Tell me about password safety
- Tell me about phishing
- I am worried about scams
- I am frustrated about phishing
- I am interested in privacy
- Tell me more
- Another tip
- Tell me about 2FA
- Tell me about malware
- What have you done for me?
- Show activity log
- Remind me to update my password

## Project Structure
```text
CyberSecurityAwarenessBotGUIApp
│
├── Assets
│   └── Greeting.wav.wav
│
├── Database
│   └── DatabaseService.cs
│
├── Logs
│   └── ActivityLogService.cs
│
├── Models
│   ├── ChatMemory.cs
│   └── TaskItem.cs
│
├── Quiz
│   ├── QuizQuestion.cs
│   └── QuizService.cs
│
├── Services
│   ├── ChatbotEngine.cs
│   ├── SentimentDetector.cs
│   └── TaskDatabaseService.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── App.xaml
```

## GitHub Commit History
| Commit | Description |
|--------|-------------|
| 1 | Added Database, Quiz, and Logs to structure |
| 2 | Created TaskItem model and DatabaseService for MySQL |
| 3 | Implemented QuizService with 11 cybersecurity questions |
| 4 | Added ActivityLogService and SentimentDetector |
| 5 | Implemented ChatbotEngine with NLP, memory and sentiment |
| 6 | Wired all Part 3 features in MainWindow — tasks, quiz, activity log |



## References
Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review.  
*The African Journal of Information and Communication*, 28(28).  
Available at: https://www.scielo.org.za/scielo.php?pid=S2077-72132021000200003&script=sci_arttext