using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skorbord.Data
{
    public class TeamName
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int ScoreboardId { get; set; }
        [ForeignKey("ScoreboardId")]
        public Scoreboard Scoreboard { get; set; } = null!;
    }
} 