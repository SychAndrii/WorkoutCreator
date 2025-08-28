namespace WorkoutDomain.ExerciseAggregate
{
    public interface ExerciseRepository
    {
        Task<Exercise?> Get(string exerciseName);
        Task Add(Exercise exercise);
    }
}
