using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ExamDomain.Model
{
    public class ExamViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exam name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Time { get; set; }

        [DataType(DataType.Duration)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Duration { get; set; }

        //Place is an optional field
        public string Place { get; set; }

        //public virtual List<Question> Questions { get; set; }
        public virtual List<QuestionInExamViewModel> QuestionViewModels { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }


        public Dictionary<int, string> AvailableCourses
        {
            get; set; 
        } 

        public ExamViewModel()
        {
            
        }

        public ExamViewModel(Exam exam)
        {
            ID = exam.ID;
            Name = exam.Name;
            Date = exam.DateAndTime.Date;
            Time = exam.DateAndTime.TimeOfDay;
            Duration = exam.Duration;
            Place = exam.Place;
            QuestionViewModels = new List<QuestionInExamViewModel>();

            foreach (var question in exam.Questions)
            {
                QuestionViewModels.Add(new QuestionInExamViewModel(question));
            }

            Course = new Course(exam.Course); 
            CourseID = exam.CourseID;
        }


        //public ExamViewModel()
        //{
        //    Exam = new Exam();
        //}

        //public Exam Exam { get; set; }


        //public ExamViewModel(Exam exam)
        //{
        //    Exam = exam;

        //    Date = exam.DateAndTime.Date;
        //    Time = exam.DateAndTime.TimeOfDay;
        //}


        //private DateTime _date;
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime Date
        //{
        //    get
        //    {
        //        return Exam.DateAndTime.Date;
        //        //return _date;
        //    }
        //    set
        //    {
        //        Exam.DateAndTime.AddYears(value.Year);
        //        Exam.DateAndTime.AddMonths(value.Month);
        //        Exam.DateAndTime.AddDays(value.Day);
        //    }

        //    //get; 
        //    //set 
        //    //{ 
        //        //_date = value; 
        //    //}
        //}

        //private TimeSpan _time;
        //[DataType(DataType.Time)]
        //public TimeSpan Time
        //{
        //    get
        //    {
        //        //return Exam.DateAndTime.TimeOfDay;
        //        return _time;
        //    } 
            

        //    //get; 
        //    set { _time = value; }
        //}
    }
}
