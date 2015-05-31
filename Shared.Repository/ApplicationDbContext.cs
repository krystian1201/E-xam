
using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using Shared.Repository.Migrations;
using ExamDomain.Model;
using UserDomain.Model;

namespace Shared.Repository
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Course> Courses { get; set; }

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

    }
}