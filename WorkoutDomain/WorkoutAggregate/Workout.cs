using BaseDomain;

namespace WorkoutDomain.WorkoutAggregate
{
    public class Workout : AggregateRoot<Guid>
    {
        private readonly List<WorkoutComponent> components = [];

        private readonly Guid _id = Guid.NewGuid();
        public override Guid Id => _id;

        internal Workout()
        {
        }

        public WorkoutComponent? GetComponent(Guid id)
        {
            return components.FirstOrDefault(c => c.Id == id);
        }

        public void AddComponent(WorkoutComponent c)
        {
            components.Add(c);
        }

        public IReadOnlyList<WorkoutComponent> GetComponents()
        {
            return components;
        }
    }
}
