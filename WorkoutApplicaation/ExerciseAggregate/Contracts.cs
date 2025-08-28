namespace WorkoutApplication.ExerciseAggregate
{
    public record AddExerciseContract(string exerciseName, IEnumerable<string> measurements);
}
