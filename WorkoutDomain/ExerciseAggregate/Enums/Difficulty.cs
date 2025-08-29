using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    /// <summary>
    /// Represents the difficulty level of an exercise.
    /// </summary>
    /// <remarks>
    /// This is a strongly typed enumeration based on the <see cref="Enumeration"/> base class.
    /// It allows associating string identifiers with difficulty levels and provides useful utilities
    /// for parsing and listing defined values.
    /// </remarks>
    public sealed class Difficulty : Enumeration
    {
        public static readonly Difficulty Low = new("LOW");
        public static readonly Difficulty Medium = new("MEDIUM");
        public static readonly Difficulty High = new("HIGH");

        private Difficulty(string name) : base(name) { }

        /// <summary>
        /// Returns all defined <see cref="Difficulty"/> values.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Difficulty}"/> containing all defined difficulties.</returns>
        public static IEnumerable<Difficulty> List() => GetAll<Difficulty>();

        /// <summary>
        /// Parses a string into a <see cref="Difficulty"/> instance.
        /// </summary>
        /// <param name="name">The name of the difficulty level to parse.</param>
        /// <returns>The corresponding <see cref="Difficulty"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown if the name does not match any defined difficulty.</exception>
        public static Difficulty FromString(string name) => FromString<Difficulty>(name);
    }
}
