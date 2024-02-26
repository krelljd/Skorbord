using Microsoft.AspNetCore.SignalR;

namespace Skorbord.Hubs;

public class ScoreHub : Hub
{
    public async Task SendScoresMessage(int[] scores)
    {
        await Clients.All.SendAsync("UpdateScores", scores);
    }

    public async Task SendTeamsMessage(string t1, string t1Color, string t2, string t2Color)
    {
        await Clients.All.SendAsync("UpdateTeams", t1, t1Color, t2, t2Color);
    }
}