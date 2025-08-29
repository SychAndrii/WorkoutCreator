namespace WorkoutDomain.ExerciseAggregate
{
    public class InvalidExerciseException(string message) : Exception(message)
    {
    }
}
