using Microsoft.AspNetCore.SignalR;

namespace Skorbord.Hubs;

public class ScoreHub : Hub
{
    public async Task SendScoresMessage(int[] scores)
    {
        await Clients.All.SendAsync("UpdateScores", scores);
    }

    public async Task SendMatchInfoMessage(string t1, string t1Color, string t2, string t2Color, string tName, string sbColor)
    {
        await Clients.All.SendAsync("UpdateMatchInfo", t1, t1Color, t2, t2Color, tName, sbColor);
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
