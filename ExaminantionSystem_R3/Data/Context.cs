using ExaminantionSystem_R3.Data.EntityMapping;
using ExaminantionSystem_R3.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ExaminationSystem.Data
{
    public class Context : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamQuestion> ExamsQuestions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }
        public DbSet<StudentsExams> StudentsExams { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source =.;initial catalog = ExaminationSystem_R3; integrated security = true; trust server certificate=true")
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Console.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new QuestionMapping())
                .ApplyConfiguration(new ChoiceMapping());

            modelBuilder.Entity<Course>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Choice>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Exam>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<ExamQuestion>().HasQueryFilter(x => !x.isDeleted);
            modelBuilder.Entity<Question>().HasQueryFilter(x => !x.isDeleted);

          


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {

                var foreignKeys = entityType.GetForeignKeys();
                foreach (var fk in foreignKeys)
                {
                    fk.DeleteBehavior = DeleteBehavior.NoAction;
                }
            }
            modelBuilder.Entity<ExamQuestion>()
               .HasKey(eq => new { eq.ExamID, eq.QuestionID });




        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Question>()
        //        .HasOne(q => q.Course)
        //        .WithMany(c => c.questions)
        //        .HasForeignKey(q => q.CourseID)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevents cascading delete

        //    modelBuilder.Entity<Question>()
        //        .Property(q => q.CourseID)
        //        .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Throw); // Prevents updating FK

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
