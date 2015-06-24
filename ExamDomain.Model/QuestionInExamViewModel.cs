
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{

    public class QuestionInExamViewModel
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        [Display(Name = "Time to respond")]
        public TimeSpan TimeToRespond { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Questions text cannot be longer than 50 characters.")]
        [Display(Name = "Question text")]
        public string Text { get; set; }

        [Required]
        [Range(1, 100)]
        //[DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public int Points { get; set; }


        public int ExamID { get; set; }

        [DisplayName("Question type")]
        public QuestionType QuestionType { get; set; }

        public bool ToBeDeleted { get; set; }


        public QuestionInExamViewModel()
        {
            
        }

        public QuestionInExamViewModel(Question question)
        {
            ID = question.ID;
            TimeToRespond = question.TimeToRespond;
            Text = question.Text;
            Points = question.Points;
            ExamID = question.Exam.ID;

            if (question is ClosedQuestion)
            {
                QuestionType = QuestionType.Closed;
            }
            else if (question is OpenQuestion)
            {
                QuestionType = QuestionType.Open;
            }
        }
    }


    public enum QuestionType
    {
        Open, Closed
    }
}
