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
            modelBuilder.Entity<Instructor_Plan>().HasKey(
                iw => new { iw.InstructorId, iw.PlanId, });

            modelBuilder.Entity<Instructor_Plan>().HasOne(i => i.Plan).WithMany(iw => iw.Instructor_Plan).HasForeignKey(i => i.PlanId);
            modelBuilder.Entity<Instructor_Plan>().HasOne(i => i.Instructor).WithMany(iw => iw.Instructor_Workout).HasForeignKey(i => i.InstructorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Gyms> Gyms { get; set; }

        public DbSet<MainInstructor> MainInstructors { get; set; }

        public DbSet<Instructor_Plan> Instructor_Plans { get; set; }

        public DbSet<Plan> Plans { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
