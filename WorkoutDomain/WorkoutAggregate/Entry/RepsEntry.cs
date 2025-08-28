using WorkoutDomain.ExerciseAggregate;

namespace WorkoutDomain.WorkoutAggregate.Entry
{
    public class RepsEntry : WorkoutEntry
    {
        public int Value
        {
            get;
        }

        public override Measurement Type => Measurement.Reps;

        private RepsEntry(int reps)
        {
            if (reps <= 0)
            {
                throw new ArgumentException("Repetitions must be greater than zero.");
            }

            Value = reps;
        }

        public static implicit operator int(RepsEntry reps)
        {
            return reps?.Value ?? throw new Exception("Reps value is 0");
        }

        public static implicit operator RepsEntry(int reps)
        {
            return new RepsEntry(reps);
        }

        protected override IEnumerable<object> GetValueComponents()
        {
            yield return Value;
        }
    }
}
