namespace Skorbord.Data;

public class ScoreArray
{
    public ScoreArray(string jsonString)
    {
        SetScoresFromJsonString(jsonString);
    }

    public ScoreArray(int[] scoreArray)
    {
        Scores = scoreArray;
    }

    public int[] Scores { get; set; } = { 0, 0, 0, 0, 0, 0 };

    public override string ToString()
    {
        return string.Join(",", Scores);
    }

    public void SetScoresFromJsonString(string jsonString)
    {
        string[] tokens = jsonString.Split(',');
        Scores = Array.ConvertAll(tokens, int.Parse);
    }
}
