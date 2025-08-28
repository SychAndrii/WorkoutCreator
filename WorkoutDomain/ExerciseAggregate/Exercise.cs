using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate
{
    public class Exercise : AggregateRoot<NormalizedString>
    {
        public NormalizedString name;
        private readonly ISet<Measurement> possibleMeasurements;

        public readonly static Exercise REST = new("Rest", new HashSet<Measurement>
        {
            Measurement.Duration
        });

        public override NormalizedString Id => name;

        public Exercise(string name, ISet<Measurement> possibleMeasurements)
        {
            this.name = name;
            if (possibleMeasurements.Count == 0)
            {
                throw new ArgumentException("There has to be at least one possible measurement for the exercise");
            }
            this.possibleMeasurements = possibleMeasurements;
        }

        public bool AllowsMeasurement(Measurement type)
        {
            return possibleMeasurements.Contains(type);
        }
    }
}
