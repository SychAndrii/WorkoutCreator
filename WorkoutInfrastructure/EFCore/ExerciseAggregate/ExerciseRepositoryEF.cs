using BaseDomain;
using WorkoutDomain.ExerciseAggregate;
using WorkoutDomain.ExerciseAggregate.Repositories;

namespace WorkoutInfrastructure.EFCore.ExerciseAggregate
{
    public class ExerciseRepositoryEF : ExerciseRepository
    {
        private readonly ExerciseDbContext _db = new();

        public async Task Add(Exercise exercise)
        {
            if (await Get(exercise.name) is not null)
            {
                throw new Exception($"Exercise '{exercise.name}' already exists.");
            }

            var entity = ExerciseEntity.FromDomain(exercise);

            _db.Exercises.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Exercise?> Get(string exerciseName)
        {
            var id = new NormalizedString(exerciseName).ToString();
            var entity = await _db.Exercises.FindAsync(id);
            return entity?.ToDomain();
        }
    }

}
