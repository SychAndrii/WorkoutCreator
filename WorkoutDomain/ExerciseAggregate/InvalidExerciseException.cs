namespace WorkoutDomain.ExerciseAggregate
{
    /// <summary>
    /// Exception thrown when an <see cref="Exercise"/> fails domain validation.
    /// </summary>
    /// <remarks>
    /// This exception is used to represent business rule violations when constructing or modifying an <see cref="Exercise"/>.
    /// It is intended to be thrown only from within the domain layer.
    /// </remarks>
    public class InvalidExerciseException(string message) : Exception(message)
    {
    }
}
