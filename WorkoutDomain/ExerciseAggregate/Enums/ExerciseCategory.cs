using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    public sealed class ExerciseCategory : Enumeration
    {
        public static readonly ExerciseCategory Strength = new("STRENGTH");
        public static readonly ExerciseCategory Cardio = new("CARDIO");
        public static readonly ExerciseCategory Mobility = new("MOBILITY");
        public static readonly ExerciseCategory Recovery = new("RECOVERY");
        public static readonly ExerciseCategory Breathing = new("BREATHING");

        private ExerciseCategory(string name) : base(name) { }

        public static IEnumerable<ExerciseCategory> List() => GetAll<ExerciseCategory>();
        public static ExerciseCategory FromString(string name) => FromString<ExerciseCategory>(name);
    }

}
