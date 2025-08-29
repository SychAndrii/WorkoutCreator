using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    public sealed class Difficulty : Enumeration
    {
        public static readonly Difficulty Low = new("LOW");
        public static readonly Difficulty Medium = new("MEDIUM");
        public static readonly Difficulty High = new("HIGH");

        private Difficulty(string name) : base(name) { }

        public static IEnumerable<Difficulty> List() => GetAll<Difficulty>();
        public static Difficulty FromString(string name) => FromString<Difficulty>(name);
    }
}
