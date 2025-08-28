namespace WorkoutDomain.WorkoutAggregate
{
    public interface WorkoutRepository
    {
        Task<Workout?> Get(Guid id);
    }
}
