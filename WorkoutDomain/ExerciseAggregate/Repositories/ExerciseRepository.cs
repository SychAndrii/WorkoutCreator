namespace WorkoutDomain.ExerciseAggregate.Repositories
{
    public interface ExerciseRepository
    {
        Task<Exercise?> Get(string exerciseName);
        Task Add(Exercise exercise);
    }
}
