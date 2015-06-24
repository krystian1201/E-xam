
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

        public virtual Course Course { get; set; }
        public int CourseID { get; set; }

        public Exam()
        {
            
        }

        public Exam(ExamViewModel examViewModel)
        {
            ID = examViewModel.ID;
            Name = examViewModel.Name;

            
            DateAndTime = new DateTime(examViewModel.Date.Year, examViewModel.Date.Month, examViewModel.Date.Day,
                examViewModel.Time.Hours, examViewModel.Time.Minutes, examViewModel.Time.Seconds);
               

            Duration = examViewModel.Duration;
            Place = examViewModel.Place;

            //Questions = examViewModel.Questions;
            Questions = new List<Question>();

            foreach (var questionViewModel in examViewModel.QuestionViewModels)
            {
                Questions.Add(new Question(questionViewModel));
            }

            CourseID = examViewModel.CourseID;
        }
    }
}