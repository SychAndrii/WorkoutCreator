using WorkoutApplication.ExerciseAggregate;
using WorkoutDomain.ExerciseAggregate;

namespace WorkoutPresentation;

public class ExerciseCli
{
    private readonly ExerciseService _exerciseService;

    public ExerciseCli(ExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("=== Add New Exercise ===");
        var contract = ParseContract();

        try
        {
            await AddAndRetrieveExerciseAsync(contract);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add exercise: {ex.Message}");
        }
    }

    private async Task AddAndRetrieveExerciseAsync(AddExerciseContract contract)
    {
        await _exerciseService.Add(contract);
        Console.WriteLine("\nExercise added successfully!");

        var addedExercise = await _exerciseService.Get(contract.exerciseName);
        if (addedExercise is not null)
        {
            Console.WriteLine("\n=== Stored Exercise ===");
            Console.WriteLine($"Name: {addedExercise.name}");
            Console.WriteLine("Measurements: " + string.Join(", ", GetMeasurementNames(addedExercise)));
        }
        else
        {
            Console.WriteLine("Failed to retrieve the added exercise.");
        }
    }

    private AddExerciseContract ParseContract()
    {
        // Get and validate name
        string? name;
        do
        {
            Console.Write("Enter exercise name: ");
            name = Console.ReadLine()?.Trim();
        } while (string.IsNullOrWhiteSpace(name));

        // Get and parse measurements
        Console.Write("Enter measurements (comma-separated): ");
        var input = Console.ReadLine();
        var measurements = input?
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(m => m.Trim())
            .Where(m => !string.IsNullOrWhiteSpace(m))
            ?? Enumerable.Empty<string>();

        return new AddExerciseContract(name, measurements);
    }

    private static IEnumerable<string> GetMeasurementNames(Exercise exercise)
    {
        var knownMeasurements = Measurement.List();
        return knownMeasurements.Where(m => exercise.AllowsMeasurement(m)).Select(m => m.ToString());
    }
}
