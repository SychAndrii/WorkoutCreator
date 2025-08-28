using WorkoutApplication.ExerciseAggregate;
using WorkoutDomain.ExerciseAggregate;
using WorkoutInfrastructure.AutoMapper.ExerciseAggregate;
using WorkoutInfrastructure.EFCore.ExerciseAggregate;
using WorkoutPresentation;

namespace WorkoutComposition
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using var db = new ExerciseDbContext();
            db.Database.EnsureCreated();

            // Manually wire infrastructure
            ExerciseMapper mapper = new ExerciseAutoMapper();
            ExerciseRepository repository = new ExerciseRepositoryEF();

            ExerciseService exerciseService = new(mapper, repository);

            // Manually wire presentation
            var cli = new ExerciseCli(exerciseService);

            // Run app
            await cli.RunAsync();
        }
    }
}
