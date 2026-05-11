# Cybersecurity Awareness Bot

## Student Details
Student Number: ST10489537  
Module: PROG6221 Programming 2A  
Assessment: Portfolio of Evidence - Part 1 and Part 2  

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
- GitHub version control

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

## Cybersecurity Topics Covered
- Password safety
- Phishing
- Scams
- Privacy
- Safe browsing
- Two-factor authentication
- Malware

## How to Run the Project
1. Clone or download the GitHub repository.
2. Open the solution in Visual Studio.
3. Set `CyberSecurityAwarenessBotGUIApp` as the startup project.
4. Make sure the audio file is located in the `Assets` folder.
5. Build the solution.
6. Run the application.

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
- What do you know about me?

## Project Structure
```text
CyberSecurityAwarenessBotGUIApp
│
├── Assets
│   └── Greeting.wav.wav
│
├── Models
│   └── ChatMemory.cs
│
├── Services
│   ├── ChatbotEngine.cs
│   └── SentimentDetector.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── App.xaml