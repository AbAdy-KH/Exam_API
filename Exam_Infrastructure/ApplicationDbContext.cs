using Exam_Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam_Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<SelectedAnswer> SelectedAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 🔹 Fix cascade delete issues:
            builder.Entity<Exam>()
                .HasOne(e => e.CreatedBy)
                .WithMany() // لا نريد قائمة Exams داخل ApplicationUser
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ExamResult>()
                .HasOne(er => er.Exam)
                .WithMany()
                .HasForeignKey(er => er.ExamId)
                .OnDelete(DeleteBehavior.Restrict); // <-- يمنع الحلقة

            builder.Entity<ExamResult>()
                .HasOne(er => er.CreatedBy)
                .WithMany()
                .HasForeignKey(er => er.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // <-- يمنع double cascade

            // 🔹 Seed Data (تقدر تحتفظ به أو تعدله كما تحب)
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    FullName = "Administrator",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEBT5+zvXf2qvnwDkQyYTh...", // قيمة ثابتة
                    SecurityStamp = "STATIC-SECURITY-STAMP",
                    ConcurrencyStamp = "STATIC-CONCURRENCY-STAMP"
                }
            );

            builder.Entity<Subject>().HasData(
                new Subject { Id = "1", Name = "Math" },
                new Subject { Id = "2", Name = "Programming" },
                new Subject { Id = "3", Name = "Network" }
            );

            builder.Entity<Exam>().HasData(
                new Exam { Id = "1", Title = "Math Exam 1", SubjectId = "1", Notes = "This is a math exam.", CreatedById = "1" },
                new Exam { Id = "2", Title = "Programming Exam 1", SubjectId = "2", Notes = "This is a programming exam.", CreatedById = "1" },
                new Exam { Id = "3", Title = "Network Exam 1", SubjectId = "3", Notes = "This is a network exam.", CreatedById = "1" }
            );

            builder.Entity<Question>().HasData(
                new Question { Id = "1", Text = "What is 2 + 2?", ExamId = "1" },
                new Question { Id = "2", Text = "What is the capital of France?", ExamId = "1" },
                new Question { Id = "3", Text = "What is a class in OOP?", ExamId = "2" },
                new Question { Id = "4", Text = "What is an IP address?", ExamId = "3" }
            );

            builder.Entity<Option>().HasData(
                new Option { Id = "1", Text = "3", IsCorrect = false, QuestionId = "1" },
                new Option { Id = "2", Text = "4", IsCorrect = true, QuestionId = "1" },
                new Option { Id = "3", Text = "5", IsCorrect = false, QuestionId = "1" },

                new Option { Id = "4", Text = "London", IsCorrect = false, QuestionId = "2" },
                new Option { Id = "5", Text = "Berlin", IsCorrect = false, QuestionId = "2" },
                new Option { Id = "6", Text = "Paris", IsCorrect = true, QuestionId = "2" },

                new Option { Id = "7", Text = "A blueprint for creating objects", IsCorrect = true, QuestionId = "3" },
                new Option { Id = "8", Text = "A type of function", IsCorrect = false, QuestionId = "3" },
                new Option { Id = "9", Text = "A variable", IsCorrect = false, QuestionId = "3" },

                new Option { Id = "10", Text = "A unique identifier for a device on a network", IsCorrect = true, QuestionId = "4" },
                new Option { Id = "11", Text = "A type of protocol", IsCorrect = false, QuestionId = "4" },
                new Option { Id = "12", Text = "A network device", IsCorrect = false, QuestionId = "4" }
            );
        }
    }
}
