﻿
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ExamDomain.Model
{
    public class ClosedAnswer
    {
        public int ID { get; set; }

        [DisplayName("Correct?")]
        [Required]
        public bool IsCorrect { get; set; }

        [DisplayName("Answer")]
        [Required]
        public string AnswerText { get; set; }

        public bool ToBeDeleted { get; set; }

        public int ClosedQuestionID { get; set; }

        //[Required]
        public virtual ClosedQuestion ClosedQuestion { get; set; }
    }
}
