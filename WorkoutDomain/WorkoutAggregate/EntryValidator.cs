using BaseDomain;
using WorkoutDomain.ExerciseAggregate.Repositories;
using WorkoutDomain.WorkoutAggregate.Entry;

namespace WorkoutDomain.WorkoutAggregate
{
    public class EntryValidator
    {
        private readonly ExerciseRepository exerciseRepository;

        public EntryValidator(ExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        public async Task<bool> IsEntryAllowed(NormalizedString exerciseName, WorkoutEntry entry)
        {
            var exercise = await exerciseRepository.Get(exerciseName);
            return exercise == null
                ? throw new NullReferenceException($"Exercise [{exerciseName}] does not exist")
                : exercise.AllowsMeasurement(entry.Type);
        }
    }
}
