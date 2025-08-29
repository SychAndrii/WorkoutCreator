using System.Collections.Immutable;
using System.Text.RegularExpressions;
using BaseDomain;
using WorkoutDomain.ExerciseAggregate.Enums;

namespace WorkoutDomain.ExerciseAggregate
{
    public class Exercise : AggregateRoot<NormalizedString>
    {
        public NormalizedString Name
        {
            get;
        }
        public Difficulty Difficulty
        {
            get;
        }
        public ExerciseCategory Category
        {
            get;
        }
        public IReadOnlySet<Measurement> PossibleMeasurements
        {
            get;
        }
        public IReadOnlySet<Equipment>? RequiredEquipment
        {
            get;
        }
        public IReadOnlySet<MuscleGroup>? PrimaryMuscles
        {
            get;
        }
        public IReadOnlySet<MuscleGroup>? SecondaryMuscles
        {
            get;
        }

        public readonly static Exercise REST = new("Rest", Difficulty.Low, ExerciseCategory.Recovery, new HashSet<Measurement>
        {
            Measurement.Duration
        }, null, null, null);
        private static readonly Regex ValidNameRegex = new(@"^[A-Za-z ]+$", RegexOptions.Compiled);

        public override NormalizedString Id => Name;

        private Exercise(string name, Difficulty difficulty, ExerciseCategory category, ISet<Measurement> possibleMeasurements, ISet<Equipment>? equipment, ISet<MuscleGroup>? primaryMuscles, ISet<MuscleGroup>? secondaryMuscles)
        {
            if (!ValidNameRegex.IsMatch(name))
            {
                throw new ArgumentException($"Invalid exercise name: [{name}]. Only English letters and spaces are allowed.");
            }
            NormalizedString normalizedName = name;

            if (normalizedName.Length < 3)
            {
                throw new ArgumentException($"Invalid exercise name: [{name}]. The name must be at least 3 characters long.");
            }

            Name = normalizedName;
            Difficulty = difficulty;
            Category = category;

            if (possibleMeasurements.Count == 0)
            {
                throw new ArgumentException("There has to be at least one possible measurement for the exercise");
            }
            PossibleMeasurements = possibleMeasurements.ToImmutableHashSet();

            if (equipment != null && equipment.Count == 0)
            {
                throw new ArgumentException("Required equipment must either be not specified at all or be non-empty");
            }
            RequiredEquipment = equipment?.ToImmutableHashSet();

            if (primaryMuscles != null && primaryMuscles.Count == 0)
            {
                throw new ArgumentException("Primary muscle groups must either be not specified at all or be non-empty");
            }
            PrimaryMuscles = primaryMuscles?.ToImmutableHashSet();

            if (secondaryMuscles != null && secondaryMuscles.Count == 0)
            {
                throw new ArgumentException("Secondary muscle groups must either be not specified at all or be non-empty");
            }
            SecondaryMuscles = secondaryMuscles?.ToImmutableHashSet();

            if (PrimaryMuscles == null && SecondaryMuscles != null)
            {
                throw new ArgumentException("Secondary muscle groups must be specified only if Primary muscle groups are also specified");
            }

            if (PrimaryMuscles != null && SecondaryMuscles != null)
            {
                var samePrimaryAndSecondaryMuscles = PrimaryMuscles.Intersect(SecondaryMuscles);
                if (samePrimaryAndSecondaryMuscles.Any())
                {
                    throw new ArgumentException($"Primary muscle groups must not also be secondary muscle groups. Repeated primary and secondary muscles: [{samePrimaryAndSecondaryMuscles}]");
                }
            }

            if ((Category == ExerciseCategory.Strength || Category == ExerciseCategory.Cardio) && PrimaryMuscles == null)
            {
                throw new Exception("Strength and Cardio exercises must have at least one primary muscle group targeted");
            }
        }
    }
}
