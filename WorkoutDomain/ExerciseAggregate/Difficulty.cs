using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate
{
    public sealed class Difficulty : Enumeration
    {
        public static readonly Difficulty Low = new("LOW");
        public static readonly Difficulty Medium = new("MEDIUM");
        public static readonly Difficulty High = new("HIGH");

        private Difficulty(string name) : base(name) { }

        public static IEnumerable<Difficulty> List() => GetAll<Difficulty>();
    }
}
