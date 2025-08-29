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

        public class ExerciseBuilder
        {
            private string _name;
            private Difficulty _difficulty;
            private ExerciseCategory? _category;
            private ISet<Measurement>? _measurements;
            private ISet<Equipment>? _equipment;
            private ISet<MuscleGroup>? _primaryMuscles;
            private ISet<MuscleGroup>? _secondaryMuscles;

            private ExerciseBuilder(string name, Difficulty difficulty, ExerciseCategory category)
            {
                _name = name;
                _difficulty = difficulty;
                _category = category;
            }

            public static ExerciseBuilder Create(string name, Difficulty difficulty, ExerciseCategory category)
                => new(name, difficulty, category);

            public ExerciseBuilder WithMeasurements(params Measurement[] measurements)
            {
                _measurements ??= new HashSet<Measurement>();
                foreach (var m in measurements)
                {
                    _measurements.Add(m);
                }

                return this;
            }

            public ExerciseBuilder WithEquipment(IEnumerable<Equipment> equipment)
            {
                _equipment = new HashSet<Equipment>();
                foreach (var e in equipment)
                {
                    _equipment.Add(e);
                }

                return this;
            }

            public ExerciseBuilder WithPrimaryMuscles(IEnumerable<MuscleGroup> muscles)
            {
                _primaryMuscles ??= new HashSet<MuscleGroup>();
                foreach (var m in muscles)
                {
                    _primaryMuscles.Add(m);
                }

                return this;
            }

            public ExerciseBuilder WithSecondaryMuscles(IEnumerable<MuscleGroup> muscles)
            {
                _secondaryMuscles ??= new HashSet<MuscleGroup>();
                foreach (var m in muscles)
                {
                    _secondaryMuscles.Add(m);
                }

                return this;
            }

            public Exercise Build()
            {
                return _name is null || _difficulty is null || _category is null || _measurements is null
                    ? throw new InvalidOperationException("Name, difficulty, category, and measurements must be set.")
                    : new Exercise(
                    name: _name,
                    difficulty: _difficulty,
                    category: _category,
                    possibleMeasurements: _measurements,
                    equipment: _equipment,
                    primaryMuscles: _primaryMuscles,
                    secondaryMuscles: _secondaryMuscles
                );
            }
        }
    }
}
