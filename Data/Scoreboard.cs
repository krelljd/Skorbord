using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Skorbord.Data;
public class Scoreboard
{
    public int ScoreboardId { get; set; }
    public string TeamName1 { get; set; } = "Team 1";
    public string TeamName2 { get; set; } = "Team 2";
    public string Tournament { get; set; } = "Tournament";
    public string Scores { get; set; } = string.Empty;
    public string TeamColor1 { get; set; } = "#FFFFFF";
    public string TeamColor2 { get; set; } = "#000000";
    public string BoardColor { get; set; } = "#D9D9D9";
    public int ActiveSet { get; set; } = 1;
}