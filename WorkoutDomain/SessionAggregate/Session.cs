using BaseDomain;
using WorkoutDomain.WorkoutAggregate;

namespace WorkoutDomain.SessionAggregate
{
    public class Session : AggregateRoot<Guid>
    {
        private readonly Guid _id = Guid.NewGuid();
        public override Guid Id => _id;
        private IList<SessionComponent> sessionComponents = [];
        private int currentComponentIndex = -1;

        public static Session CreateFromWorkout(Workout workout)
        {
            var components = workout.GetComponents();
            if (components.Count == 0)
            {
                throw new ArgumentException("Cannot create a workout session from an empty workout (workout without any components)");
            }

            var sessionComponents = new List<SessionComponent>();
            foreach (var component in components)
            {
                sessionComponents.Add(new SessionComponent(workout.Id, component.Id));
            }

            return new Session(sessionComponents);
        }

        public void NextComponent()
        {
            if (currentComponentIndex == sessionComponents.Count - 1)
            {
                throw new Exception("Workout session does not have any other components");
            }
            currentComponentIndex++;
        }

        public SessionComponent? CurrentComponent()
        {
            return currentComponentIndex >= 0 && currentComponentIndex < sessionComponents.Count ? sessionComponents[currentComponentIndex] : null;
        }

        private Session(IList<SessionComponent> sessionComponents)
        {
            this.sessionComponents = sessionComponents;
        }
    }
}
