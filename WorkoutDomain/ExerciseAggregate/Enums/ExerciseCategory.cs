using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    /// <summary>
    /// Represents the category of an exercise, such as strength training, cardio, or recovery.
    /// </summary>
    /// <remarks>
    /// This is a strongly typed enumeration derived from <see cref="Enumeration"/>. 
    /// Categories help classify exercises by their primary physiological goal.
    /// </remarks>
    public sealed class ExerciseCategory : Enumeration
    {
        /// <summary>
        /// Strength-based exercise (e.g., weightlifting, resistance training).
        /// </summary>
        public static readonly ExerciseCategory Strength = new("STRENGTH");

        /// <summary>
        /// Cardiovascular exercise (e.g., running, biking, rowing).
        /// </summary>
        public static readonly ExerciseCategory Cardio = new("CARDIO");

        /// <summary>
        /// Mobility-focused exercise (e.g., dynamic stretching, joint mobility).
        /// </summary>
        public static readonly ExerciseCategory Mobility = new("MOBILITY");

        /// <summary>
        /// Recovery-focused exercise (e.g., foam rolling, cooldowns, stretching).
        /// </summary>
        public static readonly ExerciseCategory Recovery = new("RECOVERY");

        /// <summary>
        /// Breathing-focused exercise (e.g., breath control, meditative breathing).
        /// </summary>
        public static readonly ExerciseCategory Breathing = new("BREATHING");

        private ExerciseCategory(string name) : base(name) { }

        /// <summary>
        /// Returns all defined <see cref="ExerciseCategory"/> values.
        /// </summary>
        /// <returns>An enumerable list of all exercise categories.</returns>
        public static IEnumerable<ExerciseCategory> List() => GetAll<ExerciseCategory>();

        /// <summary>
        /// Parses a string into an <see cref="ExerciseCategory"/> instance.
        /// </summary>
        /// <param name="name">The name to parse.</param>
        /// <returns>The corresponding <see cref="ExerciseCategory"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the name is not a valid category.</exception>
        public static ExerciseCategory FromString(string name) => FromString<ExerciseCategory>(name);
    }

}
