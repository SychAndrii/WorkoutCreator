using WorkoutDomain.ExerciseAggregate;

namespace WorkoutDomain.WorkoutAggregate.Entry
{
    public class DurationEntry : WorkoutEntry
    {
        public TimeSpan Value
        {
            get;
        }

        public override Measurement Type => Measurement.Duration;

        private DurationEntry(TimeSpan duration)
        {
            if (duration < TimeSpan.FromSeconds(10))
            {
                throw new ArgumentException("Duration must be at least 10 seconds long");
            }

            Value = duration;
        }

        public static implicit operator TimeSpan(DurationEntry duration)
        {
            return duration?.Value ?? throw new Exception("Duration value is 0 seconds");
        }

        public static implicit operator DurationEntry(TimeSpan timeSpan)
        {
            return new DurationEntry(timeSpan);
        }

        protected override IEnumerable<object> GetValueComponents()
        {
            yield return Value;
        }
    }
}
