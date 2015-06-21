
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

            //foreach (var exam in dbContext.Exams)
            //{
            //    examsRepository.Delete(exam.ID);
            //}

            //dbContext.Exams.AddRange(exams);


            #region Exams

            IRepository<Exam> examsRepository = new Repository<Exam>(dbContext);
            examsRepository.DeleteAll();

            var exams = new List<Exam>
            {
                new Exam {ID = 0, Name = "Differential calculus", Date = new DateTime(2015, 6, 30), Duration = new TimeSpan(0, 1, 0, 0)},
                new Exam {ID = 1, Name = "Math", Date = new DateTime(2015, 6, 15), Duration = new TimeSpan(0, 1, 30, 0)},
                new Exam {ID = 2, Name = "Physics", Date = new DateTime(2015, 5, 15), Duration = new TimeSpan(0, 0, 30, 0)},
                new Exam {ID = 3, Name = "Software System Development", Date = new DateTime(2015, 6, 15), Duration = new TimeSpan(0, 1, 30, 0)}
            };

            
            examsRepository.AddRange(exams);

            #endregion


            //--------------------------------------------------------------------------------------------------------------------------

            #region Questions

            IRepository<Question> questionsRepository = new Repository<Question>(dbContext);
            questionsRepository.DeleteAll();

            //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors


            ClosedQuestion closedQuestion1 = new ClosedQuestion
            {
                Points = 5,
                Text = "What's your favorite color?",
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
                new OpenQuestion {ID = 3, Points = 10, Text = "Where are you from?", 
                    TimeToRespond = new TimeSpan(0, 0, 5, 0)},
                closedQuestion1

            };

            questionsRepository.AddRange(questions);

            #endregion


            //--------------------------------------------------------------------------------------------------------------------------
            #region ClosedAnswer

            IRepository<ClosedAnswer> closedAnswerRepository = new Repository<ClosedAnswer>(dbContext);
            closedAnswerRepository.DeleteAll();

            var colorAnswerChoices = new List<ClosedAnswer>
            {
                new ClosedAnswer {AnswerText = "blue", IsCorrect = true, ClosedQuestionID = closedQuestion1.ID},
                new ClosedAnswer {AnswerText = "red", IsCorrect = false, ClosedQuestionID = closedQuestion1.ID},
                new ClosedAnswer {AnswerText = "green", IsCorrect = false, ClosedQuestionID = closedQuestion1.ID}
            };

            closedAnswerRepository.AddRange(colorAnswerChoices);

            #endregion

            //base.Seed(dbContext);
        }
    }
}
