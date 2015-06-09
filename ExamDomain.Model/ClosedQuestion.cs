
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{
    public class ClosedQuestion : Question
    {
        [Display(Name = "Number of answers")]
        public int NumberOfAnswers { get; set; }

        public List<string> AnswerChoices { get; set; }
    }
}
