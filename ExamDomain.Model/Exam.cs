
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamDomain.Model
{
    public class Exam
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

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