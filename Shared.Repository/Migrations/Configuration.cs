using System.Collections.Generic;
using ExamDomain.Model;

namespace Shared.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shared.Repository.ApplicationDbContext>
    {
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Shared.Repository.ApplicationDbContext";
        }

        protected override void Seed(Shared.Repository.ApplicationDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //dbContext.Exams.AddOrUpdate
            //    (
            //        e => e.ID,
            //        new Exam { ID = 0, Name = "Exam1", Date = new DateTime(2015, 6, 30), Duration = new TimeSpan(0, 1, 0, 0) },
            //        new Exam { ID = 0, Name = "Exam2", Date = new DateTime(2015, 6, 15), Duration = new TimeSpan(0, 1, 30, 0) },
            //        new Exam { ID = 0, Name = "Exam3", Date = new DateTime(2015, 5, 15), Duration = new TimeSpan(0, 0, 30, 0) },
            //        new Exam { ID = 0, Name = "Exam4", Date = new DateTime(2015, 5, 25), Duration = new TimeSpan(0, 0, 30, 0) }
            //    );

            //dbContext.SaveChanges();

            foreach (var exam in dbContext.Exams)
            {
                dbContext.Exams.Remove(exam);
            }

            var exams = new List<Exam>
            {
                new Exam {ID = 0, Name = "Exam1", Date = new DateTime(2015, 6, 30), Duration = new TimeSpan(0, 1, 0, 0)},
                new Exam {ID = 0, Name = "Exam2", Date = new DateTime(2015, 6, 15), Duration = new TimeSpan(0, 1, 30, 0)},
                new Exam {ID = 0, Name = "Exam3", Date = new DateTime(2015, 5, 15), Duration = new TimeSpan(0, 0, 30, 0)}
            };

            dbContext.Exams.AddRange(exams);


            base.Seed(dbContext);
        }
    }
}
