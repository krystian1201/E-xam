
using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using ExamDomain.Model;

namespace UserDomain.Model
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}