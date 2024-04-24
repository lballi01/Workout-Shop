using Microsoft.EntityFrameworkCore;
using Workout_Shop.Models.Entites;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) { 
        
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor_Workout>().HasKey(
                iw => new { iw.InstructorId, iw.WorkoutId, });

            modelBuilder.Entity<Instructor_Workout>().HasOne(i => i.Workout).WithMany(iw => iw.Instructor_Workout).HasForeignKey(i => i.WorkoutId);
            modelBuilder.Entity<Instructor_Workout>().HasOne(i => i.Instructor).WithMany(iw => iw.Instructor_Workout).HasForeignKey(i => i.InstructorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Gyms> Gyms { get; set; }

        public DbSet<MainInstructor> MainInstructors { get; set; }

        public DbSet<Instructor_Workout> Instructor_Workouts { get; set; }

        public DbSet<Workout> Workouts { get; set; }
       
    }
}
