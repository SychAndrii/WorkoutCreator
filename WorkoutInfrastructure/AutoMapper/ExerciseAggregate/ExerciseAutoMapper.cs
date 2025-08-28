using AutoMapper;
using Microsoft.Extensions.Logging;
using WorkoutApplication;
using WorkoutApplication.ExerciseAggregate;
using WorkoutDomain.ExerciseAggregate;

namespace WorkoutInfrastructure.AutoMapper.ExerciseAggregate
{
    public class ExerciseAutoMapper : ApplicationMapper, ExerciseMapper
    {
        private readonly IMapper _mapper;

        public ExerciseAutoMapper()
        {
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AddExerciseContract, Exercise>()
                       .ConstructUsing(contract => new Exercise(
                           contract.exerciseName,
                           contract.measurements
                               .Select(Measurement.FromString)
                               .ToHashSet()
                       ));
            }, loggerFactory);

            _mapper = config.CreateMapper();
        }

        public Exercise FromAddExerciseContract(AddExerciseContract contract)
        {
            return TryMap(() => _mapper.Map<Exercise>(contract));
        }
    }
}
