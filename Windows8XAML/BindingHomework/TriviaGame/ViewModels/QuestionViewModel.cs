using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriviaGame.Models;

namespace TriviaGame.ViewModels
{
    public class QuestionViewModel
    {
        public string Content { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}
