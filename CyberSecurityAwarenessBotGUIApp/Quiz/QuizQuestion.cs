using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Quiz
{
    // Represents one quiz question with multiple-choice options
    public class QuizQuestion
    {
        public required string Question { get; set; }
        public required List<string> Options { get; set; }
        public int CorrectAnswer { get; set; }
        public required string Explanation { get; set; }
    }
}
