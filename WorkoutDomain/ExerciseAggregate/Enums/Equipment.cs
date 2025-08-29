using BaseDomain;

namespace WorkoutDomain.ExerciseAggregate.Enums
{
    /// <summary>
    /// Represents a type of equipment that can be required or used in an exercise.
    /// </summary>
    /// <remarks>
    /// This is a value-based enumeration derived from <see cref="Enumeration"/> that provides a strongly typed set of known equipment types.
    /// </remarks>
    public class Equipment : Enumeration
    {
        // Free Weights
        public static readonly Equipment Dumbbell = new("DUMBBELL");
        public static readonly Equipment Barbell = new("BARBELL");
        public static readonly Equipment Kettlebell = new("KETTLEBELL");
        public static readonly Equipment WeightPlate = new("WEIGHT_PLATE");
        public static readonly Equipment Sandbag = new("SANDBAG");

        // Machines
        public static readonly Equipment CableMachine = new("CABLE_MACHINE");
        public static readonly Equipment SmithMachine = new("SMITH_MACHINE");
        public static readonly Equipment LegPressMachine = new("LEG_PRESS_MACHINE");
        public static readonly Equipment LatPulldownMachine = new("LAT_PULLDOWN_MACHINE");
        public static readonly Equipment AssistedPullUpMachine = new("ASSISTED_PULLUP_MACHINE");

        // Benches & Racks
        public static readonly Equipment FlatBench = new("FLAT_BENCH");
        public static readonly Equipment InclineBench = new("INCLINE_BENCH");
        public static readonly Equipment DeclineBench = new("DECLINE_BENCH");
        public static readonly Equipment SquatRack = new("SQUAT_RACK");
        public static readonly Equipment PowerRack = new("POWER_RACK");

        // Accessories
        public static readonly Equipment ResistanceBand = new("RESISTANCE_BAND");
        public static readonly Equipment MedicineBall = new("MEDICINE_BALL");
        public static readonly Equipment StabilityBall = new("STABILITY_BALL");
        public static readonly Equipment FoamRoller = new("FOAM_ROLLER");
        public static readonly Equipment JumpRope = new("JUMP_ROPE");

        // Cardio
        public static readonly Equipment Treadmill = new("TREADMILL");
        public static readonly Equipment StationaryBike = new("STATIONARY_BIKE");
        public static readonly Equipment RowingMachine = new("ROWING_MACHINE");
        public static readonly Equipment Elliptical = new("ELLIPTICAL");

        // Other
        public static readonly Equipment PullUpBar = new("PULLUP_BAR");
        public static readonly Equipment DipBars = new("DIP_BARS");
        public static readonly Equipment StepPlatform = new("STEP_PLATFORM");
        public static readonly Equipment Box = new("BOX");
        public static readonly Equipment TRX = new("TRX");
        public static readonly Equipment YogaMat = new("YOGA_MAT");

        private Equipment(string name) : base(name)
        {
        }

        /// <summary>
        /// Returns all defined <see cref="Equipment"/> values.
        /// </summary>
        /// <returns>A collection of all equipment types.</returns>
        public static IEnumerable<Equipment> List() => GetAll<Equipment>();

        /// <summary>
        /// Parses a string into an <see cref="Equipment"/> instance.
        /// </summary>
        /// <param name="name">The string name of the equipment to parse.</param>
        /// <returns>The corresponding <see cref="Equipment"/> value.</returns>
        /// <exception cref="ArgumentException">Thrown if the name is invalid or not recognized.</exception>
        public static Equipment FromString(string name) => FromString<Equipment>(name);
    }
}
