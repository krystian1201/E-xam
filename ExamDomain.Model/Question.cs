
using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{
    public class Question
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
        //[DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public int Points { get; set; }

        //public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }

        
    }
}
