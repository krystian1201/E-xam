using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        [Display(Name = "Questions text")]
        public string Text { get; set; }

        [Required]
        [Range(1, 100)]
        //[DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public int Points { get; set; }

        public int ExamID { get; set; }


        public QuestionInExamViewModel(Question question)
        {
            ID = question.ID;
            TimeToRespond = question.TimeToRespond;
            Text = question.Text;
            Points = question.Points;
            ExamID = question.Exam.ID;

        }
    }
}
