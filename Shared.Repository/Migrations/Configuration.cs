
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
                new Exam {ID = 2, Name = "Physics", Date = new DateTime(2015, 5, 15), Duration = new TimeSpan(0, 0, 30, 0)}
            };

            
            examsRepository.AddRange(exams);

            #endregion

            //--------------------------------------------------------------------------------------------------------------------------

            #region Questions

            IRepository<Question> questionsRepository = new Repository<Question>(dbContext);
            questionsRepository.DeleteAll();


            var questions = new List<Question>()
            {
                 new Question {Answers = null, Exam = null, ID = 0, Points = 2, Text = "What's your name?", 
                    Time = new TimeSpan(0, 0, 1, 0)},
                 new Question {Answers = null, Exam = null, ID = 1, Points = 3, Text = "How are you?", 
                    Time = new TimeSpan(0, 0, 2, 0)},
                 new Question {Answers = null, Exam = null, ID = 2, Points = 1, Text = "How old are you?", 
                    Time = new TimeSpan(0, 0, 4, 0)}

            };

            questionsRepository.AddRange(questions);

            #endregion

            base.Seed(dbContext);
        }
    }
}
