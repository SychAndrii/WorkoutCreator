using BaseDomain;
using WorkoutDomain.ExerciseAggregate;

namespace WorkoutInfrastructure.EFCore.ExerciseAggregate
{
    internal class ExerciseEntity
    {
        public string Name { get; set; } = default!;
        public List<string> Measurements { get; set; } = [];

        // Maps entity → domain
        public Exercise ToDomain()
        {
            var normalizedName = new NormalizedString(Name);
            var domainMeasurements = Measurements
                .Select(Measurement.FromString)
                .ToHashSet();

            return new Exercise(normalizedName, domainMeasurements);
        }

        // Static method to map domain → entity
        public static ExerciseEntity FromDomain(Exercise exercise)
        {
            return new ExerciseEntity
            {
                Name = exercise.name.ToString(),
                Measurements = Measurement.List()
                    .Where(exercise.AllowsMeasurement)
                    .Select(m => m.ToString())
                    .ToList()
            };
        }
    }
}
