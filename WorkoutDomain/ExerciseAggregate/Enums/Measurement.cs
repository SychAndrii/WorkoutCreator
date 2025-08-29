using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    /// <summary>
    /// Represents the type of measurement used to track exercise performance.
    /// </summary>
    /// <remarks>
    /// This strongly typed enumeration defines how a particular exercise is measured — 
    /// such as by weight lifted, repetitions completed, time duration, or distance covered.
    /// </remarks>
    public class Measurement : Enumeration
    {
        /// <summary>
        /// Weight-based measurement (e.g., 100 kg lifted).
        /// </summary>
        public static readonly Measurement Weight = new("WEIGHT");

        /// <summary>
        /// Repetition-based measurement (e.g., 10 reps).
        /// </summary>
        public static readonly Measurement Reps = new("REPS");

        /// <summary>
        /// Duration-based measurement (e.g., 30 seconds).
        /// </summary>
        public static readonly Measurement Duration = new("DURATION");

        /// <summary>
        /// Distance-based measurement (e.g., 400 meters).
        /// </summary>
        public static readonly Measurement Distance = new("DISTANCE");

        private Measurement(string name) : base(name) { }

        /// <summary>
        /// Returns all defined <see cref="Measurement"/> values.
        /// </summary>
        /// <returns>A collection of all measurement types.</returns>
        public static IEnumerable<Measurement> List() => GetAll<Measurement>();

        /// <summary>
        /// Parses a string into a <see cref="Measurement"/> instance.
        /// </summary>
        /// <param name="name">The name of the measurement to parse.</param>
        /// <returns>The corresponding <see cref="Measurement"/> value.</returns>
        /// <exception cref="ArgumentException">Thrown if the name is invalid or not recognized.</exception>
        public static Measurement FromString(string name) => FromString<Measurement>(name);
    }
}
