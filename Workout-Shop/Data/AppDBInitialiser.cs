using Workout_Shop.Data.Enums;
using Workout_Shop.Models.Entites;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Data
{
    public class AppDBInitialiser
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();

                //Gyms

                if (!context.Gyms.Any())
                {
                    context.Gyms.AddRange(new List<Gyms>(){
                        new Gyms()
                        {
                            Name = "Outside",
                            Logo = "1111",
                            Description = "You can do this workout out in the nature"
                        }
                    }
                );
                    context.SaveChanges();
                }

                //Instructors

                if (!context.Instructors.Any())
                {
                    context.Instructors.AddRange(new List<Instructor>()
                    {
                        new Instructor()
                        {
                            FullName = "Actor 1",
                            Biography = "This is the Bio of the first actor",
                            ProfilePicture = "1111"
                        }
                    });

                    context.SaveChanges();

                }

                //Creators

                if (!context.MainInstructors.Any())
                {
                    context.MainInstructors.AddRange(new List<MainInstructor>(){
                        new MainInstructor() {
                            FullName = "Producer 1",
                            Biography = "This is the Bio of the first actor",
                            ProfilePicture = "111"
                        },
                    });

                    context.SaveChanges();
                }
                //Workouts
                if (!context.Workouts.Any())
                {
                    context.Workouts.AddRange(new List<Workout>(){
                        new Workout() {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "111",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            GymId = 1,
                            MainInstructorId = 1,
                            WorkoutCategory = WorkoutCategory.Bodybuilding
                        },
                    });
                    context.SaveChanges();
                }

               //Workouts_Instructors
                if (!context.Instructor_Workouts.Any())
                {
                    context.Instructor_Workouts.AddRange(new List<Instructor_Workout>(){
                        new Instructor_Workout() {
                            InstructorId = 1,
                            WorkoutId = 1,
                        },
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}

