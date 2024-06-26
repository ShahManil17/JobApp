using JobApplicationForm.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CourseId });
            

            //modelBuilder.Entity<EducationDetails>().HasNoKey();

        }

        //public ActionResult demo()
        //{
        //    return  new JsonResult(new { id = 1 });
        //}

        public DbSet<BasicDetails> BasicDetails { get; set; }
        public DbSet<EducationDetails> EducationDetails { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<References> References { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
    }
}
