using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate
{
    public class ExerciseBuilder
    {
        private NormalizedString? _name;
        private ISet<Measurement> _possibleMeasurements;

        public ExerciseBuilder()
        {
            Reset();
        }

        public ExerciseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ExerciseBuilder AddPossibleMeasurement(Measurement measurement)
        {
            _possibleMeasurements.Add(measurement);
            return this;
        }

        public Exercise Build()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new InvalidOperationException("Name must be provided.");
            }

            return _possibleMeasurements.Count == 0
                ? throw new InvalidOperationException("At least one measurement must be provided.")
                : new Exercise(_name, _possibleMeasurements);
        }

        public void Reset()
        {
            _name = null;
            _possibleMeasurements = new HashSet<Measurement>();
        }
    }
}
