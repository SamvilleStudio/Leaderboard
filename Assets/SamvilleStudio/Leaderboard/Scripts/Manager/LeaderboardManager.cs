using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Samville.Leaderboard
{
    public class LeaderboardManager : MonoBehaviour
    {
        public static LeaderboardManager Instance;
        public LeaderboardData Data = new LeaderboardData();

        public string FileName = "Leaderboard.json";
        public int CurrentScore = 0;

        private string _filePath => Path.Combine(Application.persistentDataPath, FileName);

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            LoadLeaderboard();
        }

        [ContextMenu("Generate Dummy Scores")]
        public void GenerateDummyScores()
        {
            Data = new LeaderboardData(); // Clear existing entries

            string[] sampleNames = { "Alex", "Jordan", "Taylor", "Morgan",
                "Casey", "Riley", "Jamie", "Drew", "Sam", "Quinn" };

            System.Random rng = new System.Random();

            for (int i = 0; i < 10; i++)
            {
                Data.Scores.Add(new PlayerScoreEntry
                {
                    playerName = sampleNames[i],
                    playerScore = rng.Next(500, 1500) // Random score between 500 and 1500
                });
            }

            SaveLeaderboard();

            Debug.Log("Generated dummy leaderboard scores.");
        }

        public bool AddEntry(string name, int score)
        {
            // Check for existing entry (case-insensitive)
            var existingEntry = Data.Scores
                .FirstOrDefault(entry => entry.playerName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existingEntry != null)
            {
                // Replace only if new score is higher
                if (score > existingEntry.playerScore)
                {
                    Debug.Log($"Updating score for {name}: {existingEntry.playerScore} → {score}");
                    existingEntry.playerScore = score;
                    SaveLeaderboard();

                    return true;
                }
                else
                {
                    Debug.Log($"New score for {name} is not higher. Ignored.");

                    return false; // Score not updated
                }
            }

            // If player doesn't exist, add new entry
            Data.Scores.Add(new PlayerScoreEntry { playerName = name, playerScore = score });

            SaveLeaderboard();

            return true;
        }

        [ContextMenu("Clear Leaderboard")]
        public void ClearLeaderboard()
        {
            Data = new LeaderboardData();
            SaveLeaderboard();
        }

        private void SaveLeaderboard()
        {
            string json = JsonUtility.ToJson(Data, true);
            File.WriteAllText(_filePath, json);
        }

        private void LoadLeaderboard()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                Data = JsonUtility.FromJson<LeaderboardData>(json);
            }
        }
    }
}