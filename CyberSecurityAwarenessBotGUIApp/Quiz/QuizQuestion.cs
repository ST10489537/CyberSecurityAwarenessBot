using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityAwarenessBotGUIApp.Quiz
{
    public class QuizQuestion
    {
        public string Question { get; set; }

        public string[] Options { get; set; }

        public int CorrectAnswer { get; set; }

        public string Explanation { get; set; }
    }
}