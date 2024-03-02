using Microsoft.AspNetCore.SignalR;
using Skorbord.Data;

namespace Skorbord.Hubs;

public class ScoreHub : Hub
{
    public async Task SendScoresMessage(int boardId, int[] scores)
    {
        await Clients.All.SendAsync("UpdateScores", boardId, scores);
    }

    public async Task SendDisplayMessage(int boardId, string trn, string bc)
    {
        await Clients.All.SendAsync("UpdateDisplay", boardId, trn, bc);
    }

    public async Task SendActiveSetMessage(int boardId, int set)
    {
        await Clients.All.SendAsync("UpdateActiveSet", boardId, set);
    }

    public async Task SendTeamInfoMessage(int boardId, string t1, string t1c, string t2, string t2c)
    {
        await Clients.All.SendAsync("UpdateTeamInfo", boardId, t1, t1c, t2, t2c);
    }
}


// // Storing an array of integers
// int[] myArray = { 8, 4, 345, 378, 34456, 7 };
// string arrayString = string.Join(",", myArray);
// // Insert 'arrayString' into the SQLite database

// // Retrieving the data
// // Assume 'value' contains the string from the database
// string[] tokens = value.Split(',');
// int[] retrievedArray = Array.ConvertAll(tokens, int.Parse);
