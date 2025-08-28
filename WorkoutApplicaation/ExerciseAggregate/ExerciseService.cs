using WorkoutDomain.ExerciseAggregate;

namespace WorkoutApplication.ExerciseAggregate
{
    public class ExerciseService
    {
        private readonly ExerciseMapper exerciseMapper;
        private readonly ExerciseRepository exerciseRepository;

        public ExerciseService(ExerciseMapper exerciseMapper, ExerciseRepository exerciseRepository)
        {
            this.exerciseMapper = exerciseMapper;
            this.exerciseRepository = exerciseRepository;
        }

        public async Task Add(AddExerciseContract dto)
        {
            Exercise exercise = exerciseMapper.FromAddExerciseContract(dto);
            await exerciseRepository.Add(exercise);
        }

        public async Task<Exercise> Get(string exerciseName)
        {
            Exercise? exercise = await exerciseRepository.Get(exerciseName);
            return exercise == null ? throw new Exception($"[{exerciseName}] exercise does not exist") : exercise;
        }
    }
}
