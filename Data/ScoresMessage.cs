namespace Skorbord.Data;
public class ScoresMessage
{
    public int ScoreboardId { get; set; } = 0;
    public int[] Scores { get; set; } = {0,0,0,0,0,0};
}
