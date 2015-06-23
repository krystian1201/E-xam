
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


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAndTime { get; set; }


        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        //Place is an optional field
        public string Place { get; set; }


        public virtual List<Question> Questions { get; set; }

        //public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int CourseID { get; set; }

        public Exam()
        {
            
        }

        public Exam(ExamViewModel examViewModel)
        {
            ID = examViewModel.ID;
            Name = examViewModel.Name;

            //var zeroDateTime = new DateTime(0, 0, 0);
            DateAndTime = new DateTime(examViewModel.Date.Year, examViewModel.Date.Month, examViewModel.Date.Day,
                examViewModel.Time.Hours, examViewModel.Time.Minutes, examViewModel.Time.Seconds);
                //);
                //zeroDateTime.AddYears(examViewModel.Date.Year)
                //    .AddMonths(examViewModel.Date.Month)
                //    .AddDays(examViewModel.Date.Day);

            Duration = examViewModel.Duration;
            Place = examViewModel.Place;
            Questions = examViewModel.Questions;
            CourseID = examViewModel.CourseID;
        }
    }
}