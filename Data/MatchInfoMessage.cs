namespace Skorbord.Data;
public class MatchInfoMessage
{
    public int ScoreboardId { get; set; } = 0;
    public string TeamName1 { get; set; } = "";
    public string TeamName2 { get; set; } = "";
    public string TeamColor1 { get; set; } = "";
    public string TeamColor2 { get; set; } = "";
    public string Tournament { get; set; } = "";
    public string BoardColor { get; set; } = "";
    public int SetInt { get; set; } = 0;
}