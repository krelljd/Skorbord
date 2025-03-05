using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class ScoreboardContext : DbContext
	{
		public DbSet<Scoreboard> Scoreboards { get; set; } = null!;
		public DbSet<TeamName> TeamNames { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=skorbord.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TeamName>()
				.HasIndex(t => new { t.Name, t.ScoreboardId })
				.IsUnique();

			modelBuilder.Entity<TeamName>()
				.HasOne(t => t.Scoreboard)
				.WithMany()
				.HasForeignKey(t => t.ScoreboardId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
} 