using JobApplicationForm.Areas.Identity.Data.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;
using JobApplicationForm.Models.UpdateView;

namespace JobApplicationForm.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new { Id = "1", Name = "Admin" },
            new { Id = "2", Name = "Manager" },
            new { Id = "3", Name = "Team_Lead" },
            new { Id = "4", Name = "Developer" },
            new { Id = "5", Name = "BA" },
            new { Id = "6", Name = "HR" }
        );

        builder.Entity<IdentityUser>().HasData(
            new {
                Id = "6581ebeb-2e63-4391-94af-7137ae4eed1a",
                UserName = "manil",
                NormalizedEmail = "MANIL",
                EmailConfirmed = false,
                SecurityStamp = "R5Y77KK57HYHACKQVOQY2AN7EJV3ABWT",
                ConcurrencyStamp = "1bbc9e13-786a-449d-9d03-3fbc07128065",
                Email = "manil.shah@gmail.com",
                PasswordHash = "AQAAAAIAAYagAAAAEHHNba5wWUQ/qPhBe9ouYqAtYWXL1u+H9YmNE1OVmu5obXHNDpaQF+XlqVjWSI2kXA==",
                AccessFailedCount = 0,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            }
        );

    }
    public DbSet<BasicDetails> BasicDetails { get; set; }
    public DbSet<EducationDetails> EducationDetails { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<Languages> Languages { get; set; }
    public DbSet<Technologies> Technologies { get; set; }
    public DbSet<Preferences> Preferences { get; set; }
}
