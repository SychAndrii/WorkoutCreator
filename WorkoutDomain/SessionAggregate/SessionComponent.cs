using BaseDomain;
using WorkoutDomain.ExerciseAggregate;
using WorkoutDomain.WorkoutAggregate.Entry;

namespace WorkoutDomain.SessionAggregate
{
    public class SessionComponent : Entity<Guid>
    {
        private Guid WorkoutComponentId
        {
            get;
        }
        private Guid WorkoutId
        {
            get;
        }
        private readonly Guid _id = Guid.NewGuid();
        public override Guid Id => _id;
        private readonly Dictionary<Measurement, WorkoutEntry> attempts = [];
        public SessionComponent(Guid workoutId, Guid workoutComponentId)
        {
            WorkoutComponentId = workoutComponentId;
            WorkoutId = workoutId;
        }

        public async Task SetAttempt(WorkoutEntry attempt, SessionAttemptValidator attemptValidator)
        {
            bool canSetAttempt = await attemptValidator.IsAttemptAllowed(WorkoutId, WorkoutComponentId, attempt);
            if (!canSetAttempt)
            {
                throw new Exception($"Cannot set an attempt for a goal [{attempt.Type}] in component with ID [{WorkoutComponentId}] because the exercise of this component does not have [{attempt.Type}] as one of the goals");
            }
            attempts[attempt.Type] = attempt;
        }
    }
}
