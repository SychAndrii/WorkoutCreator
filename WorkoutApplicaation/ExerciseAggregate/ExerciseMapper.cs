using WorkoutDomain.ExerciseAggregate;

namespace WorkoutApplication.ExerciseAggregate
{
    public interface ExerciseMapper
    {
        Exercise FromAddExerciseContract(AddExerciseContract contract);
    }
}
