using Microsoft.EntityFrameworkCore;

namespace WorkoutInfrastructure.EFCore.ExerciseAggregate;

public class ExerciseDbContext : DbContext
{
    internal DbSet<ExerciseEntity> Exercises => Set<ExerciseEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=exercises.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseEntity>().HasKey(e => e.Name);

        modelBuilder.Entity<ExerciseEntity>()
            .Property(e => e.Measurements)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
    }
}
