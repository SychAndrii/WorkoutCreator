using BaseDomain;
using WorkoutDomain.ExerciseAggregate;
using WorkoutDomain.WorkoutAggregate.Entry;

namespace WorkoutDomain.WorkoutAggregate
{
    public class WorkoutComponent : Entity<Guid>
    {

        private readonly Guid _id = Guid.NewGuid();
        public override Guid Id => _id;
        private readonly Dictionary<Measurement, WorkoutEntry> goals = [];

        public WorkoutComponent(NormalizedString exerciseName)
        {
            ExerciseName = exerciseName;
        }

        public NormalizedString ExerciseName
        {
            get;
        }

        public async Task SetGoal(WorkoutEntry entry, EntryValidator entryValidator)
        {
            if (!await entryValidator.IsEntryAllowed(ExerciseName, entry))
            {
                throw new InvalidOperationException($"[{ExerciseName}] exercise cannot have a [{entry.Type}] goal");
            }

            goals[entry.Type] = entry;
        }

        public bool IsGoalSet(Measurement type)
        {
            return goals.ContainsKey(type);
        }
    }
}
