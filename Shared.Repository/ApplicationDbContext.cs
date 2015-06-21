
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
                .HasOptional(a => a.ClosedQuestion)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);


            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}