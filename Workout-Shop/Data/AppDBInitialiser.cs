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

                /*if (!context.Gyms.Any())
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
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpeg"
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
                if (!context.Plans.Any())
                {
                    context.Plans.AddRange(new List<Plan>(){
                        new Plan() {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "https://prod-ne-cdn-media.puregym.com/media/819394/gym-workout-plan-for-gaining-muscle_header.jpg?quality=80",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            GymId = 1,
                            MainInstructorId = 1,
                            WorkoutCategory = WorkoutCategory.Bodybuilding
                        },
                    });
                    context.SaveChanges();
                }
*/
    
                
            }
        }
    }
}
