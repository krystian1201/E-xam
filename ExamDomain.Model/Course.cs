﻿

using System.ComponentModel;

namespace ExamDomain.Model
{
    public class Course
    {
        public int ID { get; set; }

        [DisplayName("Course name")]
        public string Name { get; set; }

        public int ECTS { get; set; }

        public int Semester { get; set; }
    }
}
