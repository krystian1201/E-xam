
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ExamDomain.Model;

namespace Shared.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Shared.Repository.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            
            //dbContext.Exams.AddOrUpdate
            //    (
            //        e => e.ID,
            //        new Exam { ID = 0, Name = "Exam1", Date = new DateTime(2015, 6, 30), Duration = new TimeSpan(0, 1, 0, 0) },
            //        new Exam { ID = 0, Name = "Exam2", Date = new DateTime(2015, 6, 15), Duration = new TimeSpan(0, 1, 30, 0) },
            //        new Exam { ID = 0, Name = "Exam3", Date = new DateTime(2015, 5, 15), Duration = new TimeSpan(0, 0, 30, 0) },
            //        new Exam { ID = 0, Name = "Exam4", Date = new DateTime(2015, 5, 25), Duration = new TimeSpan(0, 0, 30, 0) }
            //    );

            //dbContext.SaveChanges();

            

            #region Courses

            IRepository<Question> questionsRepository = new Repository<Question>(dbContext);
            questionsRepository.DeleteAll();

            IRepository<Exam> examsRepository = new Repository<Exam>(dbContext);
            examsRepository.DeleteAll();

            IRepository<Course> coursesRepository = new Repository<Course>(dbContext);
            coursesRepository.DeleteAll();

            var courses = new List<Course>
            {
                new Course
                {
                    Name = "Software System Development",
                    ECTS = 5,
                    Semester = 2
                },
                new Course
                {
                    Name = "Math",
                    ECTS = 2,
                    Semester = 1
                },
                new Course
                {
                    Name = "Physics",
                    ECTS = 3,
                    Semester = 3
                },
                new Course
                {
                    Name = "English B2",
                    ECTS = 1,
                    Semester = 1
                },
                new Course
                {
                    Name = "Computer Science",
                    ECTS = 4,
                    Semester = 1
                },
                new Course
                {
                    Name = "Modelling and Analysis of Web",
                    ECTS = 2,
                    Semester = 2
                },
                new Course
                {
                    Name = "Foundation of Knowledge Engineering",
                    ECTS = 3,
                    Semester = 2
                }
            };

            coursesRepository.AddRange(courses);


            #endregion

            //--------------------------------------------------------------------------------------------------------------------------

            #region Questions

            

            var closedQuestion1 = new ClosedQuestion
            {
                Points = 5,
                Text = "What's your favorite color?",
                TimeToRespond = new TimeSpan(0, 0, 5, 0)
            };

            var closedQuestion2 = new ClosedQuestion
            {
                Points = 2,
                Text = "What's your favorite city?",
                TimeToRespond = new TimeSpan(0, 0, 5, 0)
            };

            var closedQuestion3 = new ClosedQuestion
            {
                Points = 100,
                Text = "Is Elvis alive?",
                TimeToRespond = new TimeSpan(0, 0, 5, 0)
            };

            var questions = new List<Question>()
            {
                 new OpenQuestion {Exam = null, ID = 0, Points = 2, Text = "What's your name?", 
                    TimeToRespond = new TimeSpan(0, 0, 1, 0)},
                 new OpenQuestion {Exam = null, ID = 1, Points = 3, Text = "How are you?", 
                    TimeToRespond = new TimeSpan(0, 0, 2, 0)},
                 new OpenQuestion {Exam = null, ID = 2, Points = 1, Text = "How old are you?", 
                    TimeToRespond = new TimeSpan(0, 0, 4, 0)},
                new OpenQuestion {Points = 10, Text = "Where are you from?", 
                    TimeToRespond = new TimeSpan(0, 0, 5, 0)},
                new OpenQuestion {Points = 10, Text = "When is your birthday?", 
                    TimeToRespond = new TimeSpan(0, 0, 5, 0)},
                new OpenQuestion {Points = 10, Text = "Your mother maiden name?", 
                    TimeToRespond = new TimeSpan(0, 0, 5, 0)},
                new OpenQuestion {Points = 3, Text = "What's your favorite sports club?", 
                    TimeToRespond = new TimeSpan(0, 0, 1, 0)},
                new OpenQuestion {Points = 2, Text = "What's your favorite food?", 
                    TimeToRespond = new TimeSpan(0, 0, 2, 0)},
                new OpenQuestion {Points = 9, Text = "What's your favorite band?", 
                    TimeToRespond = new TimeSpan(0, 0, 1, 0)},
                new OpenQuestion {Points = 3, Text = "What's your favorite music genre?", 
                    TimeToRespond = new TimeSpan(0, 0, 2, 0)},
                new OpenQuestion {Points = 3, Text = "What's the biggest city in Poland?", 
                    TimeToRespond = new TimeSpan(0, 0, 1, 0)},
                new OpenQuestion {Points = 3, Text = "What's the biggest country in the world?", 
                    TimeToRespond = new TimeSpan(0, 0, 3, 0)},
                new OpenQuestion {Points = 3, Text = "What's the longest river in the world?", 
                    TimeToRespond = new TimeSpan(0, 0, 5, 0)},
                new OpenQuestion {Points = 3, Text = "Who killed Kennedy?", 
                    TimeToRespond = new TimeSpan(0, 0, 1, 0)},
                closedQuestion1,
                closedQuestion2,
                closedQuestion3
            };

            questionsRepository.AddRange(questions);

            #endregion


            //--------------------------------------------------------------------------------------------------------------------------

            #region Exams

            //IRepository<Exam> examsRepository = new Repository<Exam>(dbContext);
            //examsRepository.DeleteAll();

            var exams = new List<Exam>
            {
                new Exam
                {
                    Name = "Differential calculus", Course = courses.FirstOrDefault(c => c.Name == "Math"),
                    DateAndTime = new DateTime(2015, 6, 30, 15, 30, 0), Duration = new TimeSpan(0, 1, 0, 0),
                    Place = "A1, 30", Questions = questions
                },
                new Exam
                {
                    Name = "Integrals", Course = courses.FirstOrDefault(c => c.Name == "Math"),
                    DateAndTime = new DateTime(2015, 6, 15, 13, 0, 0), Duration = new TimeSpan(0, 1, 30, 0),
                    Place = "D20, 105"
                },
                new Exam
                {
                    Name = "Exam 2", Course = courses.FirstOrDefault(c => c.Name == "Physics"),
                    DateAndTime = new DateTime(2015, 5, 15, 12, 15, 0), Duration = new TimeSpan(0, 0, 30, 0),
                    Place = "C3, 205"
                },
                new Exam
                {
                    Name = "Final Exam", Course = courses.FirstOrDefault(c => c.Name == "Software System Development"),
                    DateAndTime = new DateTime(2015, 6, 15, 17, 5, 0), Duration = new TimeSpan(0, 1, 30, 0),
                    Place = "C5, 301"
                },
                new Exam
                {
                    Name = "Exam 3", Course = courses.FirstOrDefault(c => c.Name == "Computer Science"), 
                    DateAndTime = new DateTime(2015, 6, 23, 11, 0, 0), Duration = new TimeSpan(0, 2, 30, 0),
                     Place = "C7, 501"
                },
                new Exam
                {
                    Name = "Vocabulary exam", Course = courses.FirstOrDefault(c => c.Name == "English B2"), 
                    DateAndTime = new DateTime(2015, 6, 24, 9, 30, 0), Duration = new TimeSpan(0, 1, 15, 0),
                     Place = "C13, 301"
                },
                new Exam
                {
                    Name = "Grammar exam", Course = courses.FirstOrDefault(c => c.Name == "English B2"), 
                    DateAndTime = new DateTime(2015, 6, 25, 11, 15, 0), Duration = new TimeSpan(0, 1, 0, 0),
                    Place = "C13, 301"
                },
                new Exam
                {
                    Name = "Quantum physics", Course = courses.FirstOrDefault(c => c.Name == "Physics"), 
                    DateAndTime = new DateTime(2015, 6, 25, 13, 15, 0), Duration = new TimeSpan(0, 2, 0, 0),
                    Place = "C1, 205"
                },
                new Exam
                {
                    Name = "Algebra", Course = courses.FirstOrDefault(c => c.Name == "Math"), 
                    DateAndTime = new DateTime(2015, 7, 5, 13, 15, 0), Duration = new TimeSpan(0, 2, 30, 0),
                    Place = "D1, 200"
                }
            };

            
            examsRepository.AddRange(exams);

            #endregion


            
            #region ClosedAnswer

            IRepository<ClosedAnswer> closedAnswerRepository = new Repository<ClosedAnswer>(dbContext);
            closedAnswerRepository.DeleteAll();

            var colorAnswerChoices = new List<ClosedAnswer>
            {
                new ClosedAnswer {AnswerText = "blue", IsCorrect = true, ClosedQuestionID = closedQuestion1.ID},
                new ClosedAnswer {AnswerText = "red", IsCorrect = false, ClosedQuestionID = closedQuestion1.ID},
                new ClosedAnswer {AnswerText = "green", IsCorrect = false, ClosedQuestionID = closedQuestion1.ID},
                new ClosedAnswer {AnswerText = "black", IsCorrect = false, ClosedQuestionID = closedQuestion1.ID}
            };

            closedAnswerRepository.AddRange(colorAnswerChoices);

            var cityAnswerChoices = new List<ClosedAnswer>
            {
                new ClosedAnswer{AnswerText = "Wroclaw", IsCorrect = true, ClosedQuestionID = closedQuestion2.ID},
                new ClosedAnswer{AnswerText = "London", IsCorrect = false, ClosedQuestionID = closedQuestion2.ID},
                new ClosedAnswer{AnswerText = "New York", IsCorrect = false, ClosedQuestionID = closedQuestion2.ID}
            };

            closedAnswerRepository.AddRange(cityAnswerChoices);

            var elvisAnswerChoices = new List<ClosedAnswer>
            {
                new ClosedAnswer{AnswerText = "Yes, of course!", IsCorrect = true, ClosedQuestionID = closedQuestion3.ID},
                new ClosedAnswer{AnswerText = "No, man, what a bullshit!", IsCorrect = false, ClosedQuestionID = closedQuestion3.ID},
               
            };

            closedAnswerRepository.AddRange(elvisAnswerChoices);
            

            #endregion

            //base.Seed(dbContext);
        }
    }
}
