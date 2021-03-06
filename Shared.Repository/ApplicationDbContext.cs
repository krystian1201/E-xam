﻿
using System.Data.Entity;
using ExamDomain.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.Repository.Migrations;
using UserDomain.Model;

namespace Shared.Repository
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<ClosedAnswer> ClosedAnswers {get; set; }


        public ApplicationDbContext()
            : base("E_xam", throwIfV1Schema: false)
        {
            //it is needed for automatic migrations to work
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClosedAnswer>()
                .HasRequired(a => a.ClosedQuestion)
                .WithMany(q => q.AnswerChoices)
                .HasForeignKey(a => a.ClosedQuestionID)
                .WillCascadeOnDelete(true);
                //.HasMany(q => q.AnswerChoices)
                //.HasOptional(q => q.AnswerChoices)
                //.WithOptionalDependent()
                //.WillCascadeOnDelete(true);

            modelBuilder.Entity<Question>()
                 .HasOptional(q => q.Exam)
                 .WithMany(e => e.Questions)
                 .HasForeignKey(q => q.ExamID)
                 .WillCascadeOnDelete(false);

        }
    }
}