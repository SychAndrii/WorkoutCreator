using WorkoutDomain.ExerciseAggregate.Enums;

namespace WorkoutDomain.WorkoutAggregate.Entry
{
    public class WeightEntry : WorkoutEntry
    {
        public double ValueLBS
        {
            get;
        }

        public override Measurement Type => Measurement.Weight;

        private WeightEntry(double valueLbs)
        {
            if (valueLbs <= 0)
            {
                throw new ArgumentException("Weight must be greater than zero.");
            }

            ValueLBS = valueLbs;
        }

        public static implicit operator double(WeightEntry weight)
        {
            return weight?.ValueLBS ?? 0;
        }

        public static implicit operator WeightEntry(double lbs)
        {
            return new WeightEntry(lbs);
        }

        protected override IEnumerable<object> GetValueComponents()
        {
            yield return ValueLBS;
        }
    }
}
