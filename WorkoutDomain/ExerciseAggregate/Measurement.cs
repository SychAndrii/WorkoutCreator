using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate
{

    public class Measurement : ValueObject
    {
        public static readonly Measurement Weight = new("WEIGHT");
        public static readonly Measurement Reps = new("REPS");
        public static readonly Measurement Duration = new("DURATION");
        public static readonly Measurement Distance = new("DISTANCE");

        public NormalizedString Name
        {
            get;
        }

        private Measurement(string name)
        {
            Name = new NormalizedString(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public override string ToString() => Name.ToString();

        public static IEnumerable<Measurement> List() =>
        [
            Weight, Reps, Duration, Distance
        ];

        public static Measurement FromString(string name)
        {
            return List().FirstOrDefault(x => x.Name.ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                   ?? throw new ArgumentException($"Invalid MeasurementType: {name}");
        }
    }
}
