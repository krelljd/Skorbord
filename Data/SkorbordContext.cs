using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Skorbord.Data;

// Context for the Scoreboards database.
public class ScoreboardContext : DbContext
{
    // Magic strings.
    public static readonly string ScoreboardsDb = "scoreboard";

    // Inject options.
    // options: The DbContextOptions{ScoreboardContext} for the context.
    public ScoreboardContext(DbContextOptions<ScoreboardContext> options)
        : base(options)
    {
        Debug.WriteLine($"{ContextId} context created.");
    }

    // List of Scoreboard.
    public DbSet<Scoreboard>? Scoreboards { get; set; }

    // Define the model.
    // modelBuilder: The ModelBuilder.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    // Dispose pattern.
    public override void Dispose()
    {
        Debug.WriteLine($"{ContextId} context disposed.");
        base.Dispose();
    }

    // Dispose pattern.
    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}