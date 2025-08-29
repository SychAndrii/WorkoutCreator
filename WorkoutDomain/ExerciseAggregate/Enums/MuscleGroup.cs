using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    public class MuscleGroup : Enumeration
    {
        public static readonly MuscleGroup Chest = new("CHEST");
        public static readonly MuscleGroup Back = new("BACK");
        public static readonly MuscleGroup Shoulders = new("SHOULDERS");
        public static readonly MuscleGroup Biceps = new("BICEPS");
        public static readonly MuscleGroup Triceps = new("TRICEPS");
        public static readonly MuscleGroup Forearms = new("FOREARMS");

        public static readonly MuscleGroup Abs = new("ABS");
        public static readonly MuscleGroup Obliques = new("OBLIQUES");
        public static readonly MuscleGroup LowerBack = new("LOWER_BACK");

        public static readonly MuscleGroup Quads = new("QUADS");
        public static readonly MuscleGroup Hamstrings = new("HAMSTRINGS");
        public static readonly MuscleGroup Glutes = new("GLUTES");
        public static readonly MuscleGroup Calves = new("CALVES");

        public static readonly MuscleGroup HipFlexors = new("HIP_FLEXORS");
        public static readonly MuscleGroup Adductors = new("ADDUCTORS");
        public static readonly MuscleGroup Abductors = new("ABDUCTORS");
        public static readonly MuscleGroup Neck = new("NECK");

        private MuscleGroup(string name) : base(name)
        {
        }

        public static IEnumerable<MuscleGroup> List() => GetAll<MuscleGroup>();
        public static MuscleGroup FromString(string name) => FromString<MuscleGroup>(name);
    }
}
