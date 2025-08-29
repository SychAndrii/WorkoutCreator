using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{

    public class Measurement : Enumeration
    {
        public static readonly Measurement Weight = new("WEIGHT");
        public static readonly Measurement Reps = new("REPS");
        public static readonly Measurement Duration = new("DURATION");
        public static readonly Measurement Distance = new("DISTANCE");

        private Measurement(string name) : base(name) { }

        public static IEnumerable<Measurement> List() => GetAll<Measurement>();
        public static Measurement FromString(string name) => FromString<Measurement>(name);
    }
}
