using WorkoutDomain.WorkoutAggregate;
using WorkoutDomain.WorkoutAggregate.Entry;

namespace WorkoutDomain.SessionAggregate
{
    public class SessionAttemptValidator
    {
        private readonly WorkoutRepository workoutRepository;

        public SessionAttemptValidator(WorkoutRepository workoutRepository)
        {
            this.workoutRepository = workoutRepository;
        }

        public async Task<bool> IsAttemptAllowed(Guid workoutId, Guid componentId, WorkoutEntry attempt)
        {
            Workout? workout = await workoutRepository.Get(workoutId);
            if (workout == null)
            {
                throw new NullReferenceException($"Workout with ID [{workoutId}] does not exist");
            }
            WorkoutComponent? workoutComponent = workout.GetComponent(componentId);

            return workoutComponent == null
                ? throw new NullReferenceException($"Workout Component with ID [{componentId}] does not exist within Workout with ID [{workoutId}]")
                : workoutComponent.IsGoalSet(attempt.Type);
        }
    }
}
