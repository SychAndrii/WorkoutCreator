using BaseDomain;
using WorkoutDomain.ExerciseAggregate.Enums;

namespace WorkoutDomain.WorkoutAggregate.Entry
{
    public abstract class WorkoutEntry : ValueObject
    {
        public abstract Measurement Type
        {
            get;
        }

        protected sealed override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            foreach (var component in GetValueComponents())
            {
                yield return component;
            }
        }

        // Each subclass provides its value-specific components
        protected abstract IEnumerable<object> GetValueComponents();
    }
}
