using System;
using System.ComponentModel.DataAnnotations;


namespace ExamDomain.Model
{
    public class ExamViewModel
    {
        public Exam Exam { get; set; }

        public ExamViewModel(Exam exam)
        {
            Exam = exam;
        }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date
        {
            get { return Exam.DateAndTime.Date; }
            //set { Exam.DateAndTime. = value; }
        }

        [DataType(DataType.Time)]
        public TimeSpan Time
        {
            get { return Exam.DateAndTime.TimeOfDay; } 
            //set;
        }
    }
}
