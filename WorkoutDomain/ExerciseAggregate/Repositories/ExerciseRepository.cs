namespace WorkoutDomain.ExerciseAggregate.Repositories
{
    /// <summary>
    /// Defines the contract for accessing and storing <see cref="Exercise"/> aggregate instances.
    /// </summary>
    /// <remarks>
    /// This repository interface abstracts the persistence logic for exercises and should be implemented
    /// by the infrastructure layer.
    /// </remarks>
    public interface ExerciseRepository
    {
        /// <summary>
        /// Retrieves an exercise by its name (the passed name is normalized).
        /// </summary>
        /// <param name="exerciseName">The name of the exercise.</param>
        /// <returns>The matching <see cref="Exercise"/>, or <c>null</c> if not found.</returns>
        Task<Exercise?> Get(string exerciseName);

        /// <summary>
        /// Adds a new exercise to the repository.
        /// </summary>
        /// <param name="exercise">The <see cref="Exercise"/> instance to add.</param>
        /// <returns>A task that completes when the operation finishes.</returns>
        Task Add(Exercise exercise);
    }
}
