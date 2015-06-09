
using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{
    public class Question
    {
        public int ID { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Time to respond")]
        public TimeSpan TimeToRespond { get; set; }

        [Required]
        [Display(Name = "Questions text")]
        public string Text { get; set; }

        public decimal Points { get; set; }

        //public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }

        
    }
}
