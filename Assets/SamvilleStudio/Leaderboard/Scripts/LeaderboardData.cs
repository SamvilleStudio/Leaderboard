using System.Collections.Generic;

namespace Samville.Leaderboard
{
    [System.Serializable]
    public class LeaderboardData
    {
        public List<PlayerScoreEntry> Scores = new List<PlayerScoreEntry>();
    }
}