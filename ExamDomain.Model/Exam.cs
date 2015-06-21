
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{
    public class Exam
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exam name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        //TODO: In view there should be a separate field for date and
        //TODO: another for time - does it influence model?
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        //Place is an optional field
        public string Place { get; set; }



        //public int MaxPoints
        //{
        //    get { return 10; }
        //}

        public virtual List<Question> Questions { get; set; }

        //public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}