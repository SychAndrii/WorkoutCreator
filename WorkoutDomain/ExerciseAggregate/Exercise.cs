using System.Text.RegularExpressions;
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
        private static readonly Regex ValidNameRegex = new(@"^[A-Za-z ]+$", RegexOptions.Compiled);

        public override NormalizedString Id => name;

        public Exercise(string name, ISet<Measurement> possibleMeasurements)
        {
            if (!ValidNameRegex.IsMatch(name))
            {
                throw new ArgumentException($"Invalid exercise name: [{name}]. Only English letters and spaces are allowed.");
            }
            NormalizedString normalizedName = name;

            if (normalizedName.Length < 3)
            {
                throw new ArgumentException($"Invalid exercise name: [{name}]. The name must be at least 3 characters long.");
            }
            this.name = normalizedName;

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
