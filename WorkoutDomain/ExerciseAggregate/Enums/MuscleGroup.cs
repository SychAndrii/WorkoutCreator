using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    /// <summary>
    /// Represents a specific muscle group targeted by an exercise.
    /// </summary>
    /// <remarks>
    /// This strongly typed enumeration defines various muscle groups across the upper body, core, and lower body.
    /// It is used to classify primary and secondary muscles involved in a given exercise.
    /// </remarks>
    public class MuscleGroup : Enumeration
    {
        // Upper Body
        public static readonly MuscleGroup Chest = new("CHEST");
        public static readonly MuscleGroup Back = new("BACK");
        public static readonly MuscleGroup Shoulders = new("SHOULDERS");
        public static readonly MuscleGroup Biceps = new("BICEPS");
        public static readonly MuscleGroup Triceps = new("TRICEPS");
        public static readonly MuscleGroup Forearms = new("FOREARMS");

        // Core
        public static readonly MuscleGroup Abs = new("ABS");
        public static readonly MuscleGroup Obliques = new("OBLIQUES");
        public static readonly MuscleGroup LowerBack = new("LOWER_BACK");

        // Lower Body
        public static readonly MuscleGroup Quads = new("QUADS");
        public static readonly MuscleGroup Hamstrings = new("HAMSTRINGS");
        public static readonly MuscleGroup Glutes = new("GLUTES");
        public static readonly MuscleGroup Calves = new("CALVES");

        // Other
        public static readonly MuscleGroup HipFlexors = new("HIP_FLEXORS");
        public static readonly MuscleGroup Adductors = new("ADDUCTORS");
        public static readonly MuscleGroup Abductors = new("ABDUCTORS");
        public static readonly MuscleGroup Neck = new("NECK");

        private MuscleGroup(string name) : base(name)
        {
        }

        /// <summary>
        /// Returns all defined <see cref="MuscleGroup"/> values.
        /// </summary>
        /// <returns>A collection of all defined muscle groups.</returns>
        public static IEnumerable<MuscleGroup> List() => GetAll<MuscleGroup>();

        /// <summary>
        /// Parses a string into a <see cref="MuscleGroup"/> instance.
        /// </summary>
        /// <param name="name">The string name of the muscle group to parse.</param>
        /// <returns>The corresponding <see cref="MuscleGroup"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the name is not valid.</exception>
        public static MuscleGroup FromString(string name) => FromString<MuscleGroup>(name);
    }
}
